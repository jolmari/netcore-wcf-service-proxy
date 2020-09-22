using System.Reflection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using WcfServices.Interfaces;
using WcfServices.Repositories;

namespace WcfServices
{
    public static class Bootstrapper
    {
        public static readonly Container Container;

        static Bootstrapper()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register WCF services.
            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            container.Register<ICountryRepository, CountryRepository>();
            container.Register<IPersonRepository, PersonRepository>();

            container.Verify();
            Container = container;
        }
    }
}