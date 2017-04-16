using System.Collections.Generic;
using WcfServices.DTO;

namespace WcfServices.Interfaces
{
    public interface IPersonRepository
    {
        void Clear();
        void AddPerson(PersonDto person);
        IEnumerable<PersonDto> GetPersons();
    }
}
