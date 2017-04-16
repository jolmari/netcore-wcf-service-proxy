using System;
using System.ServiceModel;
using SimpleInjector.Integration.Wcf;

namespace WcfServices
{
    public class WcfServiceFactory : SimpleInjectorServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new SimpleInjectorServiceHost(Bootstrapper.Container,serviceType,baseAddresses);
        }
    }
}