using System.Collections.Generic;
using System.ServiceModel;
using CountryWcfService.DTO;

namespace CountryWcfService
{
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        List<CountryDto> GetCountries();

        [OperationContract]
        void SaveCountry(CountryDto country);

        [OperationContract]
        void Clear();
    }
}
