using System.Collections.Generic;
using PersonWcfService.DTO;

namespace PersonWcfService
{
    public class PersonWcfService : IPersonService
    {
        private static readonly List<PersonDto> Persons = new List<PersonDto>
        {
            new PersonDto { FirstName = "Michael", LastName = "Smithers", CountryCode = "USA" },
            new PersonDto { FirstName = "Lisa", LastName = "Anderson", CountryCode = "USA" },
            new PersonDto { FirstName = "Matti", LastName = "Meikäläinen", CountryCode = "FIN" },
            new PersonDto { FirstName = "Ule", LastName = "Sundkvist", CountryCode = "SVE" },
            new PersonDto { FirstName = "Kalle", LastName = "LindStröm", CountryCode = "SVE" },
            new PersonDto { FirstName = "Ville", LastName = "Heinonen", CountryCode = "FIN" }
        };

        public List<PersonDto> GetPersons()
        {
            return Persons;
        }

        public void SavePerson(PersonDto person)
        {
            Persons.Add(person);
        }

        public void Clear()
        {
            Persons.Clear();
        }
    }
}
