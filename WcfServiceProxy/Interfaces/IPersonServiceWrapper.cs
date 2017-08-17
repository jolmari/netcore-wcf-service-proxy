using System.Collections.Generic;
using System.Threading.Tasks;
using WcfServiceProxy.Models;

namespace WcfServiceProxy.Interfaces
{
    public interface IPersonServiceWrapper
    {
        IEnumerable<Person> GetPersons();
        Task<IEnumerable<Person>> GetPersonsAsync();
        void SavePerson(Person person);
        Task SavePersonAsync(Person person);
        void Clear();
        Task ClearAsync();
    }
}
