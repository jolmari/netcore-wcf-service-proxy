using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WcfProxy.Interfaces;
using WcfProxy.Models;
using WcfProxy.PersonServiceReference;
using WcfProxy.Proxy;

namespace WcfProxy
{
    public class PersonServiceWrapper : IPersonServiceWrapper
    {
        private readonly string endpointUrl;

        public PersonServiceWrapper(string endpointUrl)
        {
            this.endpointUrl = endpointUrl;
        }

        public IEnumerable<Person> GetPersons()
        {
            var clientProxy = new WcfProxy<IPersonService>(endpointUrl);

            var request = new GetPersonsRequest();
            var result = clientProxy.Execute(client => client.GetPersons(request));
            return result.GetPersonsResult.AsEnumerable().Select(MapPersonDtoToPerson);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            var clientProxy = new WcfProxy<IPersonService>(endpointUrl);

            var request = new GetPersonsRequest();
            var result = await clientProxy.Execute(client => client.GetPersonsAsync(request));
            return result.GetPersonsResult.AsEnumerable().Select(MapPersonDtoToPerson);
        }

        public void SavePerson(Person person)
        {
            var clientProxy = new WcfProxy<IPersonService>(endpointUrl);

            var request = new SavePersonRequest(MapPersonToPersonDto(person));
            clientProxy.Execute(client => client.SavePerson(request));
        }

        public async Task SavePersonAsync(Person person)
        {
            var clientProxy = new WcfProxy<IPersonService>(endpointUrl);

            var request = new SavePersonRequest(MapPersonToPersonDto(person));
            await clientProxy.Execute(client => client.SavePersonAsync(request));
        }

        public void Clear()
        {
            var clientProxy = new WcfProxy<IPersonService>(endpointUrl);

            var request = new ClearRequest();
            clientProxy.Execute(client => client.Clear(request));
        }

        public async Task ClearAsync()
        {
            var clientProxy = new WcfProxy<IPersonService>(endpointUrl);

            var request = new ClearRequest();
            await clientProxy.Execute(client => client.ClearAsync(request));
        }

        private PersonDto MapPersonToPersonDto(Person person)
        {
            return new PersonDto
            {
                CountryCode = person.CountryCode,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
        }

        private Person MapPersonDtoToPerson(PersonDto person)
        {
            return new Person
            {
                CountryCode = person.CountryCode,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
        }
    }
}
