using System.Collections.Generic;
using System.ServiceModel;
using WcfServices.DTO;

namespace WcfServices.Interfaces
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        IEnumerable<PersonDto> GetPersons();

        [OperationContract]
        void SavePerson(PersonDto person);

        [OperationContract]
        void Clear();
    }
}
