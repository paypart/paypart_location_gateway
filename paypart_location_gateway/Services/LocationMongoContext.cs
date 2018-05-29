using Microsoft.Extensions.Options;
using MongoDB.Driver;
using paypart_location_gateway.Models;

namespace paypart_location_gateway.Services
{
    public class LocationMongoContext
    {
        private readonly IMongoDatabase _database = null;

        public LocationMongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.connectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.database);
        }

        public IMongoCollection<Country> countries
        {
            get
            {
                return _database.GetCollection<Country>("countries");
            }
        }
        public IMongoCollection<State> states
        {
            get
            {
                return _database.GetCollection<State>("states");
            }
        }
    }
}
