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

        public Task<Country[]> GetCountriesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SaveCountry(Country country)
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            clientProxy.Execute(client => client.SaveCountry(country));
        }

        public Task SaveCountryAsync(Country country)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            var clientProxy = new Proxy.WcfProxy<ICountryService>(endpointUrl);
            clientProxy.Execute(client => client.Clear());
        }

        public Task ClearAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
