using System.Collections.Generic;
using System.ServiceModel;
using WcfServices.DTO;

namespace WcfServices.Interfaces
{
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        IEnumerable<CountryDto> GetCountries();

        [OperationContract]
        void SaveCountry(CountryDto country);

        [OperationContract]
        void Clear();
    }
}
