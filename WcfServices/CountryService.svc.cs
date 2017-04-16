using System.Collections.Generic;
using WcfServices.DTO;
using WcfServices.Interfaces;

namespace WcfServices
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        
        public IEnumerable<CountryDto> GetCountries()
        {
            return countryRepository.GetCountries();
        }

        public void SaveCountry(CountryDto country)
        {
            countryRepository.AddCountry(country);
        }

        public void Clear()
        {
            countryRepository.Clear();
        }
    }
}
