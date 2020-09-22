using Microsoft.AspNetCore.Mvc;
using NetCoreWebApp.Models;
using WcfServiceProxy.Interfaces;

namespace NetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryServiceWrapper _countryServiceWrapper;
        private readonly IPersonServiceWrapper _personServiceWrapper;

        public HomeController(ICountryServiceWrapper countryServiceWrapper, IPersonServiceWrapper personServiceWrapper)
        {
            _countryServiceWrapper = countryServiceWrapper;
            _personServiceWrapper = personServiceWrapper;
        }

        public IActionResult Index()
        {
            var result = new ServicePayload
            {
                Countries = _countryServiceWrapper.GetCountries(),
                Persons = _personServiceWrapper.GetPersons()
            };

            return View(result);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}