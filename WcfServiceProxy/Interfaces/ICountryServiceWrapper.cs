using System.Collections.Generic;
using System.Threading.Tasks;
using WcfServiceProxy.Models;

namespace WcfServiceProxy.Interfaces
{
    public interface ICountryServiceWrapper
    {
        IEnumerable<Country> GetCountries();
        Task<IEnumerable<Country>> GetCountriesAsync();
        void SaveCountry(Country country);
        Task SaveCountryAsync(Country country);
        void Clear();
        Task ClearAsync();
    }
}
