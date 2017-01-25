using Microsoft.AspNetCore.Mvc;
using NetCoreWebApp.Models;
using WcfProxy;
using WcfProxy.Interfaces;

namespace NetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private const string CountryEndpointUrl = "http://localhost:59546/CountryService.svc";
        private const string PersonEndpointUrl = "http://localhost:61820/PersonService.svc";
        private static ICountryServiceWrapper countryProxy;
        private static IPersonServiceWrapper personProxy;

        public IActionResult Index()
        {
            var factory = new ServiceWrapperFactory();
            countryProxy = factory.CreateCountryServiceWrapper(CountryEndpointUrl);
            personProxy = factory.CreatePersonServiceWrapper(PersonEndpointUrl);

            var result = new ServicePayload
            {
                Countries = countryProxy.GetCountries(),
                Persons = personProxy.GetPersons()
            };

            return View(result);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
