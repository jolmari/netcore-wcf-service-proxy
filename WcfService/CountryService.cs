using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        List<Country> GetCountries();

        [OperationContract]
        void SaveCountry(Country country);

        [OperationContract]
        void Clear();
    }

    [DataContract]
    public class Country
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
