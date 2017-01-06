using System;
using System.Collections.Generic;

namespace WcfService
{
    public class CountryService : ICountryService
    {
        private static readonly List<Country> Store = new List<Country>
        {
            new Country { Code = "FIN", Name = "Finland" },
            new Country { Code = "SWE", Name = "Sweden" },
            new Country { Code = "DNK", Name = "Denmark" },
            new Country { Code = "DEU", Name = "Germany" }
        };
        
        public List<Country> GetCountries()
        {
            return Store;
        }

        public void SaveCountry(Country country)
        {
            Store.Add(country);
        }

        public void Clear()
        {
            Store.Clear();
        }
    }
}
