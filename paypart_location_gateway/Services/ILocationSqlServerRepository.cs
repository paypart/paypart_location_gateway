using System.Collections.Generic;
using paypart_location_gateway.Models;
using System.Threading.Tasks;

namespace paypart_location_gateway.Services
{
    public interface ILocationSqlServerRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountry(string id);
        Task<List<Country>> GetCountryByTitle(string title);
        Task<Country> AddCountry(Country item);
        //Task<DeleteResult> RemoveBiller(string id);
        //Task<UpdateResult> UpdateBiller(string id, string title);

        // demo interface - full document update
        //Task<ReplaceOneResult> UpdateBiller(string id, Biller item);

        // should be used with high cautious, only in relation with demo setup
        //Task<DeleteResult> RemoveAllBillers();


        Task<List<State>> GetAllStates();
        Task<State> GetState(string id);
        Task<List<State>> GetStateByTitle(string title);
        Task<List<State>> GetStatesByCountryId(int id);
        Task<State> AddState(State item);
        //Task<DeleteResult> RemoveBiller(string id);
        //Task<UpdateResult> UpdateBiller(string id, string title);

        // demo interface - full document update
        //Task<ReplaceOneResult> UpdateBiller(string id, Biller item);

        // should be used with high cautious, only in relation with demo setup
        //Task<DeleteResult> RemoveAllBillers();
    }
}
