using System;
using System.Collections.Generic;
using WcfServices.DTO;
using WcfServices.Interfaces;

namespace WcfServices.Repositories
{
    public class CountryRepository : ICountryRepository
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

        public IEnumerable<CountryDto> GetCountries()
        {
            return Store;
        }

        public void Clear()
        {
            Store.Clear();
        }

        public void AddCountry(CountryDto country)
        {
            Store.Add(country);
        }
    }
}