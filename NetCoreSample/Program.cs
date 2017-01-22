using System;
using System.Linq;
using WcfProxy;
using WcfProxy.Interfaces;
using WcfProxy.Models;

namespace NetCoreSample
{
    public static class Program
    {
        private const string CountryEndpointUrl = "http://localhost:59546/CountryService.svc";
        private const string PersonEndpointUrl = "http://localhost:61820/PersonService.svc";
        private static ICountryServiceWrapper countryProxy;
        private static IPersonServiceWrapper personProxy;

        public static void Main(string[] args)
        {
            var factory = new ServiceWrapperFactory();
            countryProxy = factory.CreateCountryServiceWrapper(CountryEndpointUrl);
            personProxy = factory.CreatePersonServiceWrapper(PersonEndpointUrl);

            OutputCountries();
            OutputPersons();

            countryProxy.SaveCountry(new Country { Code = "RUS", Name = "Russia" });
            personProxy.SavePerson(new Person { CountryCode = "RUS", FirstName = "Vladimir", LastName = "Ulianov"});

            OutputCountries();
            OutputPersons();
            Console.ReadKey();
        }

        private static void OutputCountries()
        {
            Console.WriteLine("List of countries");
            var countries = countryProxy.GetCountries();
            countries.ToList().ForEach(country => Console.WriteLine($"{country.Code}: {country.Name}"));
        }

        private static void OutputPersons()
        {
            Console.WriteLine("List of persons");
            var persons = personProxy.GetPersons();
            persons.ToList().ForEach(person => Console.WriteLine($"{person.CountryCode}: {person.FirstName} {person.LastName}"));
        }
    }
}
