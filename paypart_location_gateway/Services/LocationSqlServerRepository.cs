using paypart_location_gateway.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace paypart_location_gateway.Services
{
    public class LocationSqlServerRepository : ILocationSqlServerRepository
    {
        private readonly LocationSqlServerContext _context = null;

        public LocationSqlServerRepository(LocationSqlServerContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<Country> GetCountry(string id)
        {
            return await _context.Country.Where(c => c.id.ToString() == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Country>> GetCountryByTitle(string title)
        {
            return await _context.Country.Where(c => c.title == title)
                                 .ToListAsync();
        }

        public async Task<Country> AddCountry(Country item)
        {
            await _context.Country.AddAsync(item);
            await _context.SaveChangesAsync();
            return await GetCountry(item.id.ToString());
        }

        //public async Task<DeleteResult> RemoveBiller(string id)
        //{
        //    return await _context.Billers.Remove(
        //                 Builders<Biller>.Filter.Eq(s => s._id, id));
        //}

        //public async Task<UpdateResult> UpdateBiller(string id, string title)
        //{
        //    var filter = Builders<Biller>.Filter.Eq(s => s._id.ToString(), id);
        //    var update = Builders<Biller>.Update
        //                        .Set(s => s.title, title)
        //                        .CurrentDate(s => s.createdOn);
        //    return await _context.Billers.UpdateOneAsync(filter, update);
        //}

        //public async Task<ReplaceOneResult> UpdateBiller(string id, Biller item)
        //{
        //    return await _context.Billers
        //                         .ReplaceOneAsync(n => n._id.Equals(id)
        //                                             , item
        //                                             , new UpdateOptions { IsUpsert = true });
        //}

        //public async Task<DeleteResult> RemoveAllBillers()
        //{
        //    return await _context.Billers.DeleteManyAsync(new BsonDocument());
        //}


        public async Task<List<State>> GetAllStates()
        {
            return await _context.State.ToListAsync();
        }

        public async Task<State> GetState(string id)
        {
            return await _context.State.Where(c => c.id.ToString() == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<State>> GetStateByTitle(string title)
        {
            return await _context.State.Where(c => c.title == title)
                                 .ToListAsync();
        }

        public async Task<State> AddState(State item)
        {
            await _context.State.AddAsync(item);
            await _context.SaveChangesAsync();
            return await GetState(item.id.ToString());
        }

        public async Task<List<State>> GetStatesByCountryId(int id)
        {
            return await _context.State.Where(c => c.countryid == id)
                                 .ToListAsync();
        }

        //public async Task<DeleteResult> RemoveBiller(string id)
        //{
        //    return await _context.Billers.Remove(
        //                 Builders<Biller>.Filter.Eq(s => s._id, id));
        //}

        //public async Task<UpdateResult> UpdateBiller(string id, string title)
        //{
        //    var filter = Builders<Biller>.Filter.Eq(s => s._id.ToString(), id);
        //    var update = Builders<Biller>.Update
        //                        .Set(s => s.title, title)
        //                        .CurrentDate(s => s.createdOn);
        //    return await _context.Billers.UpdateOneAsync(filter, update);
        //}

        //public async Task<ReplaceOneResult> UpdateBiller(string id, Biller item)
        //{
        //    return await _context.Billers
        //                         .ReplaceOneAsync(n => n._id.Equals(id)
        //                                             , item
        //                                             , new UpdateOptions { IsUpsert = true });
        //}

        //public async Task<DeleteResult> RemoveAllBillers()
        //{
        //    return await _context.Billers.DeleteManyAsync(new BsonDocument());
        //}
    }
}
