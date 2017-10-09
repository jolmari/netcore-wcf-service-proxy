using System;
using System.ServiceModel;

namespace WcfServiceProxy.Proxy
{
    public class WcfProxy<T> : IWcfProxy<T> where T : class, ICommunicationObject
    {
        private T _client;
        private bool _disposed;
        
        public WcfProxy(string endpointUrl)
        {
            if(string.IsNullOrWhiteSpace(endpointUrl))
            {
                throw new ArgumentException("Endpoint cannot be empty.");
            }

            _client = CreateChannel(new EndpointAddress(endpointUrl));
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
            if(!_disposed)
            {
                var closedSuccessfully = false;

                try
                {
                    // Attempt to close client connection only if it is not in a faulted state.
                    if(_client.State != CommunicationState.Faulted)
                    {
                        _client.Close();
                        closedSuccessfully = true;
                    }
                }
                finally
                {
                    // Force transition to closed if closing was unsuccessful.
                    if (!closedSuccessfully)
                    {
                        _client.Abort();
                    }
                }

                _client = null;
                _disposed = true;
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
            function(_client);
        }

        public TResult Execute<TResult>(Func<T, TResult> function)
        {
            return function(_client);
        }
    }
}