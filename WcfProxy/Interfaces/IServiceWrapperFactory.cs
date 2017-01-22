using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfProxy.Interfaces
{
    public interface IServiceWrapperFactory
    {
        CountryServiceWrapper CreateCountryServiceWrapper(string endpointUrl);
        PersonServiceWrapper CreatePersonServiceWrapper(string endpointUrl);
    }
}
