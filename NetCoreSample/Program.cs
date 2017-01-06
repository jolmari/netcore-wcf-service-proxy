using System;
using System.Linq;
using WcfProxy;
using WcfProxy.CountryServiceReference;

namespace NetCoreSample
{
    public static class Program
    {
        private static CountryServiceWrapper proxy;

        public static void Main(string[] args)
        {
            proxy = new CountryServiceWrapper();
            OutputCountries();
            proxy.SaveCountry(new Country { Code = "RUS", Name = "Russia" });
            OutputCountries();
            Console.ReadKey();
        }

        private static void OutputCountries()
        {
            Console.WriteLine("List of countries");
            var countries = proxy.GetCountries();
            countries.ToList().ForEach(country => Console.WriteLine($"{country.Code}: {country.Name}"));
        }
    }
}
