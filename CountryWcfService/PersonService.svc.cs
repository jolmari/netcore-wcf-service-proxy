using System.Collections.Generic;
using WcfServices.DTO;
using WcfServices.Interfaces;

namespace WcfServices
{
    public class PersonWcfService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonWcfService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public IEnumerable<PersonDto> GetPersons()
        {
            return personRepository.GetPersons();
        }

        public void SavePerson(PersonDto person)
        {
            personRepository.AddPerson(person);
        }

        public void Clear()
        {
            personRepository.Clear();
        }
    }
}
