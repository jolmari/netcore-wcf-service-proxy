using System.Collections.Generic;
using WcfProxy.Models;

namespace NetCoreWebApp.Models
{
    public class ServicePayload
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Person> Persons { get; set; }
    }
}
