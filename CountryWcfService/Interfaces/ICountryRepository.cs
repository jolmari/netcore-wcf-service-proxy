using System.Collections.Generic;
using WcfServices.DTO;

namespace WcfServices.Interfaces
{
    public interface ICountryRepository
    {
        void Clear();
        void AddCountry(CountryDto country);
        IEnumerable<CountryDto> GetCountries();
    }
}
