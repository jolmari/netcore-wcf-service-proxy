using Microsoft.AspNetCore.Mvc;
using NetCoreWebApp.Models;
using WcfServiceProxy.Interfaces;

namespace NetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryServiceWrapper countryServiceWrapper;
        private readonly IPersonServiceWrapper personServiceWrapper;

        public HomeController(ICountryServiceWrapper countryServiceWrapper, IPersonServiceWrapper personServiceWrapper)
        {
            this.countryServiceWrapper = countryServiceWrapper;
            this.personServiceWrapper = personServiceWrapper;
        }

        public IActionResult Index()
        {
            var result = new ServicePayload
            {
                Countries = countryServiceWrapper.GetCountries(),
                Persons = personServiceWrapper.GetPersons()
            };

            return View(result);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
