using System.Collections.Generic;
using CountryWcfService.DTO;

namespace CountryWcfService
{
    public class CountryService : ICountryService
    {
        private static readonly List<CountryDto> Store = new List<CountryDto>
        {
            new CountryDto { Code = "FIN", Name = "Finland" },
            new CountryDto { Code = "USA", Name = "United States of America" },
            new CountryDto { Code = "SWE", Name = "Sweden" },
            new CountryDto { Code = "DNK", Name = "Denmark" },
            new CountryDto { Code = "DEU", Name = "Germany" },
            new CountryDto { Code = "RUS", Name = "Russia" },
            new CountryDto { Code = "NOR", Name = "Norway" },
            new CountryDto { Code = "UKR", Name = "Ukraine" },
            new CountryDto { Code = "EST", Name = "Estonia" },
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
