using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WcfProxy.PersonServiceReference;
using WcfServiceProxy.Interfaces;
using WcfServiceProxy.Models;
using WcfServiceProxy.Proxy;

namespace WcfServiceProxy
{
    public class PersonServiceWrapper : IPersonServiceWrapper
    {
        private readonly IWcfProxy<IPersonService> clientProxy;

        public PersonServiceWrapper(string endpointUrl)
        {
            clientProxy = new WcfProxy<IPersonServiceChannel>(endpointUrl);
        }

        public IEnumerable<Person> GetPersons()
        {
            var request = new GetPersonsRequest();
            var result = clientProxy.Execute(client => client.GetPersons(request));
            return result.GetPersonsResult.AsEnumerable().Select(MapPersonDtoToPerson);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            var request = new GetPersonsRequest();
            var result = await clientProxy.Execute(client => client.GetPersonsAsync(request));
            return result.GetPersonsResult.AsEnumerable().Select(MapPersonDtoToPerson);
        }

        public void SavePerson(Person person)
        {
            var request = new SavePersonRequest(MapPersonToPersonDto(person));
            clientProxy.Execute(client => client.SavePerson(request));
        }

        public async Task SavePersonAsync(Person person)
        {
            var request = new SavePersonRequest(MapPersonToPersonDto(person));
            await clientProxy.Execute(client => client.SavePersonAsync(request));
        }

        public void Clear()
        {
            var request = new ClearRequest();
            clientProxy.Execute(client => client.Clear(request));
        }

        public async Task ClearAsync()
        {
            var request = new ClearRequest();
            await clientProxy.Execute(client => client.ClearAsync(request));
        }

        private PersonDto MapPersonToPersonDto(Person person)
        {
            return new PersonDto
            {
                CountryCode = person.CountryCode,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.Phone,
                Email = person.Email
            };
        }

        private Person MapPersonDtoToPerson(PersonDto person)
        {
            return new Person
            {
                CountryCode = person.CountryCode,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.Phone,
                Email = person.Email
            };
        }
    }
}
