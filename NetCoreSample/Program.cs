using System;
using System.Linq;
using WcfProxy;

namespace NetCoreSample
{
    public static class Program
    {
        private const string EndpointUrl = "http://localhost:59546/ICountryService.svc";
        private static CountryServiceWrapper proxy;

        public static void Main(string[] args)
        {
            //proxy = new CountryServiceWrapper(EndpointUrl);
            //OutputCountries();
            //proxy.SaveCountry(new Country { Code = "RUS", Name = "Russia" });
            //OutputCountries();
            //Console.ReadKey();
        }

        private static void OutputCountries()
        {
            //Console.WriteLine("List of countries");
            //var countries = proxy.GetCountries();
            //countries.ToList().ForEach(country => Console.WriteLine($"{country.Code}: {country.Name}"));
        }
    }
}
