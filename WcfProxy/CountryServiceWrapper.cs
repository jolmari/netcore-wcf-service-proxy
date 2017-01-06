using System.Threading.Tasks;
using WcfProxy.CountryServiceReference;

namespace WcfProxy
{
    public class CountryServiceWrapper : ICountryService
    {
        private string endpointUrl = "http://localhost:59546/ICountryService.svc";

        public CountryServiceWrapper()
        {
        }
        
        public Country[] GetCountries()
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            return clientProxy.Execute(client => client.GetCountries());
        }

        public async Task<Country[]> GetCountriesAsync()
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            return await clientProxy.Execute(client => client.GetCountriesAsync());
        }

        public void SaveCountry(Country country)
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            clientProxy.Execute(client => client.SaveCountry(country));
        }

        public async Task SaveCountryAsync(Country country)
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            await clientProxy.Execute(client => client.SaveCountryAsync(country));
        }

        public void Clear()
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            clientProxy.Execute(client => client.Clear());
        }

        public async Task ClearAsync()
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            await clientProxy.Execute(client => client.ClearAsync());
        }
    }
}
