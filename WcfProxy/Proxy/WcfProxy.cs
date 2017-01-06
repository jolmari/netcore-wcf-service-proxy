using System;
using System.ServiceModel;

namespace Etera.Yel.Verkkopalvelu.Service.Proxy
{
    public class WcfProxy<T> : IWcfProxy<T> where T : class
    {
        private readonly ChannelFactory<T> channelFactory;

        public WcfProxy(string endpointUrl)
        {
            var binding = new BasicHttpsBinding();
            var endpoint = new EndpointAddress(endpointUrl);
            channelFactory = new ChannelFactory<T>(binding, endpoint);
        }

        public void Execute(Action<T> action)
        {
            var clientProxy = channelFactory.CreateChannel();

            try
            {
                action(clientProxy);
                ((ICommunicationObject)clientProxy).Close();
            }
            finally
            {
                ((ICommunicationObject)clientProxy).Abort();
            }
        }

        public TResult Execute<TResult>(Func<T, TResult> function)
        {
            var clientProxy = channelFactory.CreateChannel();

            try
            {
                var result = function(clientProxy);
                ((ICommunicationObject)clientProxy).Close();
                return result;
            }
            finally
            {
                ((ICommunicationObject)clientProxy).Abort();
            }
        }
    }
}