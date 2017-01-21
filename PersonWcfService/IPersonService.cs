using System.Collections.Generic;
using System.ServiceModel;
using PersonWcfService.DTO;

namespace PersonWcfService
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        List<PersonDto> GetPersons();

        [OperationContract]
        void SavePerson(PersonDto person);

        [OperationContract]
        void Clear();
    }
}
