using System;
using System.ServiceModel;

namespace WcfProxy.Proxy
{
    public class WcfProxy<T> : IWcfProxy<T> where T : class
    {
        private readonly string endpointUrl;
        
        public WcfProxy(string endpointUrl)
        {
            this.endpointUrl = endpointUrl;
        }

        private T CreateChannel()
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(endpointUrl);
            var factory = new ChannelFactory<T>(binding, endpoint);
            return factory.CreateChannel();
        }

        public void Execute(Action<T> action)
        {
            var clientProxy = CreateChannel();

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
            var clientProxy = CreateChannel();

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