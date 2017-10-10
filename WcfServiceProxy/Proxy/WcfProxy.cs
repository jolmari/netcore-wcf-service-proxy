using System;
using System.ServiceModel;

namespace WcfServiceProxy.Proxy
{
    public class WcfProxy<T> : IWcfProxy<T> where T : class, ICommunicationObject
    {
        private T client;
        private bool disposed;
        
        public WcfProxy(string endpointUrl)
        {
            if(string.IsNullOrWhiteSpace(endpointUrl))
            {
                throw new ArgumentException("Endpoint cannot be empty.");
            }

            client = CreateChannel(new EndpointAddress(endpointUrl));
        }

        /// <summary>
        /// Implicit disposal: garbage collector calls finalizer and the dispose method through it.
        /// </summary>
        ~WcfProxy()
        {
            Dispose(false);
        }

        /// <summary>
        /// Explicit disposal: manual call to dispose and suppression of further garbage collection calls.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Do not repeat dispose if called more than once.
            if(!disposed)
            {
                var closedSuccessfully = false;

                try
                {
                    // Attempt to close client connection only if it is not in a faulted state.
                    if(client.State != CommunicationState.Faulted)
                    {
                        client.Close();
                        closedSuccessfully = true;
                    }
                }
                finally
                {
                    // Force transition to closed if closing was unsuccessful.
                    if (!closedSuccessfully)
                    {
                        client.Abort();
                    }
                }

                client = null;
                disposed = true;
            }
        }

        private static T CreateChannel(EndpointAddress endpointAddress)
        {
            var binding = new BasicHttpBinding();
            var factory = new ChannelFactory<T>(binding, endpointAddress);
            return factory.CreateChannel();
        }

        public void Execute(Action<T> function)
        {
            function(client);
        }

        public TResult Execute<TResult>(Func<T, TResult> function)
        {
            return function(client);
        }
    }
}