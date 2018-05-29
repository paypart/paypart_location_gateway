using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using paypart_location_gateway.Models;
using paypart_location_gateway.Services;
using Microsoft.Extensions.Options;
using System.Net;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading;

namespace paypart_location_gateway.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class stateController : Controller
    {
        IOptions<Settings> settings;
        IDistributedCache cache;
        private readonly ILocationSqlServerRepository locateSqlRepo;

        public stateController(IOptions<Settings> _settings, ILocationSqlServerRepository _locateSqlRepo, IDistributedCache _cache)
        {
            settings = _settings;
            cache = _cache;
            locateSqlRepo = _locateSqlRepo;
        }

        [HttpGet("getAllStates")]
        [ProducesResponseType(typeof(List<State>), 200)]
        [ProducesResponseType(typeof(LocationError), 400)]
        [ProducesResponseType(typeof(LocationError), 500)]
        public async Task<IActionResult> getAllStates()
        {
            LocationError e = new LocationError();
            List<State> states = new List<State>();

            Redis redis = new Redis(settings, cache);
            string key = "all_states";

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
                //states = await redis.getstates(key, cts.Token);

                if (states != null && states.Count > 0)
                {
                    return CreatedAtAction("getAllStates", states);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            try
            {
                states = await locateSqlRepo.GetAllStates();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            //Write to Redis
            try
            {
                //if (states != null && states.Count > 0)
                    //await redis.setstates(key, states, cts.Token);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return CreatedAtAction("getAllStates", states);
        }

        [HttpGet("getStatesByCountryId/{id}")]
        [ProducesResponseType(typeof(List<State>), 200)]
        [ProducesResponseType(typeof(LocationError), 400)]
        [ProducesResponseType(typeof(LocationError), 500)]
        public async Task<IActionResult> getStatesByCountryId(int id)
        {
            LocationError e = new LocationError();
            List<State> states = new List<State>();

            Redis redis = new Redis(settings, cache);
            string key = "country_" + id;

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
                //states = await redis.getstates(key, cts.Token);

                if (states != null && states.Count > 0)
                {
                    return CreatedAtAction("getStatesByCountryId", states);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            try
            {
                states = await locateSqlRepo.GetStatesByCountryId(id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            //Write to Redis
            try
            {
                //if (states != null && states.Count > 0)
                //await redis.setstates(key, states, cts.Token);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return CreatedAtAction("getStatesByCountryId", states);
        }
    }
}