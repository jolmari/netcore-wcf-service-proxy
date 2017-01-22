using WcfProxy.Interfaces;

namespace WcfProxy
{
    public class ServiceWrapperFactory : IServiceWrapperFactory
    {
        public ServiceWrapperFactory()
        {
        }

        public CountryServiceWrapper CreateCountryServiceWrapper(string endpointUrl)
        {
            return new CountryServiceWrapper(endpointUrl);
        }

        public PersonServiceWrapper CreatePersonServiceWrapper(string endpointUrl)
        {
            return new PersonServiceWrapper(endpointUrl);
        }
    }
}
