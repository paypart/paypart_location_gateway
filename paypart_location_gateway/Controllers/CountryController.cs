using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paypart_location_gateway.Models;
using Microsoft.AspNetCore.Mvc;
using paypart_location_gateway.Services;
using Microsoft.Extensions.Options;
using System.Threading;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;

namespace paypart_location_gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class countryController : Controller
    {
        IOptions<Settings> settings;
        IDistributedCache cache;

        private readonly ILocationSqlServerRepository locateSqlRepo;

        public countryController(IOptions<Settings> _settings, ILocationSqlServerRepository _locateSqlRepo, IDistributedCache _cache)
        {
            settings = _settings;
            locateSqlRepo = _locateSqlRepo;
            cache = _cache;
        }

        [HttpGet("getAllCountries")]
        [ProducesResponseType(typeof(List<Country>), 200)]
        [ProducesResponseType(typeof(LocationError), 400)]
        [ProducesResponseType(typeof(LocationError), 500)]
        public async Task<IActionResult> getAllCountries()
        {
            LocationError e = new LocationError();
            List<Country> countries = new List<Country>();

            Redis redis = new Redis(settings, cache);
            string key = "all_countries";

            CancellationTokenSource cts;
            cts = new CancellationTokenSource();
            cts.CancelAfter(settings.Value.redisCancellationToken);

            // validate request
            if (!ModelState.IsValid)
            {
                var modelErrors = new List<LocationError>();
                var eD = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        eD.Add(modelError.ErrorMessage);
                    }
                }
                e.error = ((int)HttpStatusCode.BadRequest).ToString();
                e.errorDetails = eD;

                return BadRequest(e);
            }

            try
            {
                //countries = await redis.getcountries(key, cts.Token);

                if (countries != null && countries.Count > 0)
                {
                    return CreatedAtAction("getAllCountries", countries);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            try
            {
                countries = await locateSqlRepo.GetAllCountries();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            //Write to Redis
            try
            {
                //if (countries != null && countries.Count > 0)
                    //await redis.setcountries(key, countries, cts.Token);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return CreatedAtAction("getAllCountries", countries);
        }
    }
}