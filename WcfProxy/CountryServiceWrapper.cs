using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WcfProxy.CountryServiceReference;
using WcfProxy.Interfaces;
using WcfProxy.Models;
using WcfProxy.Proxy;

namespace WcfProxy
{
    public class CountryServiceWrapper : ICountryServiceWrapper
    {
        private readonly string endpointUrl;

        public CountryServiceWrapper(string endpointUrl)
        {
            this.endpointUrl = endpointUrl;
        }

        public IEnumerable<Country> GetCountries()
        {
            var clientProxy = new WcfProxy<ICountryService>(endpointUrl);

            var request = new GetCountriesRequest();
            var result = clientProxy.Execute(client => client.GetCountries(request));
            return result.GetCountriesResult.AsEnumerable().Select(MapCountryDtoToCountry);
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var clientProxy = new WcfProxy<ICountryService>(endpointUrl);

            var request = new GetCountriesRequest();
            var result = await clientProxy.Execute(client => client.GetCountriesAsync(request));
            return result.GetCountriesResult.AsEnumerable().Select(MapCountryDtoToCountry);
        }

        public void SaveCountry(Country country)
        {
            var clientProxy = new WcfProxy<ICountryService>(endpointUrl);

            var request = new SaveCountryRequest(MapCountryToCountryDto(country));
            clientProxy.Execute(client => client.SaveCountry(request));
        }

        public async Task SaveCountryAsync(Country country)
        {
            var clientProxy = new WcfProxy<ICountryService>(endpointUrl);

            var request = new SaveCountryRequest(MapCountryToCountryDto(country));
            await clientProxy.Execute(client => client.SaveCountryAsync(request));
        }

        public void Clear()
        {
            var clientProxy = new WcfProxy<ICountryService>(endpointUrl);

            var request = new ClearRequest();
            clientProxy.Execute(client => client.Clear(request));
        }

        public async Task ClearAsync()
        {
            var clientProxy = new WcfProxy<ICountryService>(endpointUrl);

            var request = new ClearRequest();
            await clientProxy.Execute(client => client.ClearAsync(request));
        }

        private CountryDto MapCountryToCountryDto(Country country)
        {
            return new CountryDto
            {
                Code = country.Code,
                Name = country.Name
            };
        }
        private Country MapCountryDtoToCountry(CountryDto country)
        {
            return new Country
            {
                Code = country.Code,
                Name = country.Name
            };
        }

    }
}
