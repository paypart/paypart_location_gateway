using MongoDB.Driver;
using System.Collections.Generic;
using paypart_location_gateway.Models;
using System.Threading.Tasks;

namespace paypart_location_gateway.Services
{
    public interface ILocationMongoRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountry(string id);
        Task<List<Country>> GetCountryByTitle(string title);
        Task<Country> AddCountry(Country item);
        Task<DeleteResult> RemoveCountry(string id);
        Task<UpdateResult> UpdateCountry(string id, string title);

        // demo interface - full document update
        Task<ReplaceOneResult> UpdateCountry(string id, Country item);

        // should be used with high cautious, only in relation with demo setup
        Task<DeleteResult> RemoveAllCountries();

        Task<List<State>> GetAllStates();
        Task<State> GetState(string id);
        Task<List<State>> GetStateByTitle(string title);
        Task<State> AddState(State item);
        Task<DeleteResult> RemoveState(string id);
        Task<UpdateResult> UpdateState(string id, string title);

        // demo interface - full document update
        Task<ReplaceOneResult> UpdateState(string id, State item);

        // should be used with high cautious, only in relation with demo setup
        Task<DeleteResult> RemoveAllStates();

    }
}
