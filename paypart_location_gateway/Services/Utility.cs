using Microsoft.Extensions.Options;
using paypart_location_gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace paypart_location_gateway.Services
{
    public class Utility
    {
        private readonly IOptions<Settings> settings;
        private readonly ILocationSqlServerRepository locateSqlRepo;
        public Utility(IOptions<Settings> _settings, ILocationSqlServerRepository _locateSqlRepo)
        {
            settings = _settings;
            locateSqlRepo = _locateSqlRepo;
        }
        public async Task<IEnumerable<State>> getStates(string key, CancellationToken ctx)
        {
            IEnumerable<State> states = new List<State>();
            try
            {
                //billers = await 
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return states;
        }
        public async Task<IEnumerable<Country>> getCountries()
        {
            IEnumerable<Country> countries = new List<Country>();
            try
            {
                //billers = await 
                countries = await locateSqlRepo.GetAllCountries();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return countries;
        }
    }
}
