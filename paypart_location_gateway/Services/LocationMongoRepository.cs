using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using paypart_location_gateway.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paypart_location_gateway.Services
{
    public class LocationMongoRepository : ILocationMongoRepository
    {
        private readonly LocationMongoContext _context = null;

        public LocationMongoRepository(IOptions<Settings> settings)
        {
            _context = new LocationMongoContext(settings);
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _context.countries.Find(_ => true).ToListAsync();
        }

        public async Task<Country> GetCountry(string id)
        {
            var filter = Builders<Country>.Filter.Eq("_id", id);
            return await _context.countries
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Country>> GetCountryByTitle(string title)
        {
            var filter = Builders<Country>.Filter.Eq(b => b.title, title);
            return await _context.countries
                                 .Find(filter)
                                 .ToListAsync();
        }

        public async Task<Country> AddCountry(Country item)
        {
            await _context.countries.InsertOneAsync(item);
            return await GetCountry(item.id.ToString());
        }

        public async Task<DeleteResult> RemoveCountry(string id)
        {
            return await _context.countries.DeleteOneAsync(
                         Builders<Country>.Filter.Eq(s => s.id.ToString(), id));
        }

        public async Task<UpdateResult> UpdateCountry(string id, string title)
        {
            var filter = Builders<Country>.Filter.Eq(s => s.id.ToString(), id);
            var update = Builders<Country>.Update
                                .Set(s => s.title, title)
                                .CurrentDate(s => s.created_on);
            return await _context.countries.UpdateOneAsync(filter, update);
        }

        public async Task<ReplaceOneResult> UpdateCountry(string id, Country item)
        {
            return await _context.countries
                                 .ReplaceOneAsync(n => n.id.Equals(id)
                                                     , item
                                                     , new UpdateOptions { IsUpsert = true });
        }

        public async Task<DeleteResult> RemoveAllCountries()
        {
            return await _context.countries.DeleteManyAsync(new BsonDocument());
        }



        public async Task<List<State>> GetAllStates()
        {
            return await _context.states.Find(_ => true).ToListAsync();
        }

        public async Task<State> GetState(string id)
        {
            var filter = Builders<State>.Filter.Eq("_id", id);
            return await _context.states
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<State>> GetStateByTitle(string title)
        {
            var filter = Builders<State>.Filter.Eq(b => b.title, title);
            return await _context.states
                                 .Find(filter)
                                 .ToListAsync();
        }

        public async Task<State> AddState(State item)
        {
            await _context.states.InsertOneAsync(item);
            return await GetState(item.id.ToString());
        }

        public async Task<DeleteResult> RemoveState(string id)
        {
            return await _context.states.DeleteOneAsync(
                         Builders<State>.Filter.Eq(s => s.id.ToString(), id));
        }

        public async Task<UpdateResult> UpdateState(string id, string title)
        {
            var filter = Builders<State>.Filter.Eq(s => s.id.ToString(), id);
            var update = Builders<State>.Update
                                .Set(s => s.title, title)
                                .CurrentDate(s => s.created_on);
            return await _context.states.UpdateOneAsync(filter, update);
        }

        public async Task<ReplaceOneResult> UpdateState(string id, State item)
        {
            return await _context.states
                                 .ReplaceOneAsync(n => n.id.Equals(id)
                                                     , item
                                                     , new UpdateOptions { IsUpsert = true });
        }

        public async Task<DeleteResult> RemoveAllStates()
        {
            return await _context.states.DeleteManyAsync(new BsonDocument());
        }
    }
}
