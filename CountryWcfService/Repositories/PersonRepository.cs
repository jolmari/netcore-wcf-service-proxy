using System;
using System.Collections.Generic;
using WcfServices.DTO;
using WcfServices.Interfaces;

namespace WcfServices.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private static readonly List<PersonDto> Persons = new List<PersonDto>
        {
            new PersonDto { FirstName = "Michael", LastName = "Smithers", Phone= "0500123123", Email = "mick.smithers@mail.com", CountryCode= "USA" },
            new PersonDto { FirstName = "Lisa", LastName = "Anderson", Phone= "0500232323", Email = "liz1324@mail.com", CountryCode = "USA" },
            new PersonDto { FirstName = "Matti", LastName = "Meikäläinen", Phone= "0501231111", Email = "matti.meikäläinen@mail.com", CountryCode = "FIN" },
            new PersonDto { FirstName = "Ule", LastName = "Sundkvist", Phone= "0100778899", Email = "sunde@mail.com", CountryCode = "SVE" },
            new PersonDto { FirstName = "Kalle", LastName = "LindStröm", Phone= "0100112233", Email = "kalle.lindström@mail.com", CountryCode = "SVE" },
            new PersonDto { FirstName = "Ville", LastName = "Heinonen", Phone= "0700123123", Email = "ville.heinone12@mail.com", CountryCode = "FIN" }
        };

        public IEnumerable<PersonDto> GetPersons()
        {
            return Persons;
        }

        public void Clear()
        {
            Persons.Clear();
        }

        public void AddPerson(PersonDto person)
        {
            Persons.Add(person);
        }
    }
}