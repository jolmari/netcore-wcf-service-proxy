using SimpleInjector;
using SimpleInjector.Integration.Wcf;
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
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            container.Register<ICountryRepository, CountryRepository>();
            container.Register<IPersonRepository, PersonRepository>();

            container.Verify();
            Container = container;

        }
    }
}