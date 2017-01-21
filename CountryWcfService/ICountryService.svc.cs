using System.Collections.Generic;
using CountryWcfService.DTO;

namespace CountryWcfService
{
    public class CountryService : ICountryService
    {
        private static readonly List<CountryDto> Store = new List<CountryDto>
        {
            new CountryDto { Code = "FIN", Name = "Finland" },
            new CountryDto { Code = "SWE", Name = "Sweden" },
            new CountryDto { Code = "DNK", Name = "Denmark" },
            new CountryDto { Code = "DEU", Name = "Germany" }
        };
        
        public List<CountryDto> GetCountries()
        {
            return Store;
        }

        public void SaveCountry(CountryDto country)
        {
            Store.Add(country);
        }

        public void Clear()
        {
            Store.Clear();
        }
    }
}
