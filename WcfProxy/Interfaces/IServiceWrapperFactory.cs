namespace WcfProxy.Interfaces
{
    public interface IServiceWrapperFactory
    {
        CountryServiceWrapper CreateCountryServiceWrapper(string endpointUrl);
        PersonServiceWrapper CreatePersonServiceWrapper(string endpointUrl);
    }
}
