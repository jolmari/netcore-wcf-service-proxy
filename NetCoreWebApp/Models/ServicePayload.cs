using System.Collections.Generic;
using WcfServiceProxy.Models;

namespace NetCoreWebApp.Models
{
    public class ServicePayload
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Person> Persons { get; set; }
    }
}
