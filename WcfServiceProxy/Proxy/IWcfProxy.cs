using System;

namespace WcfServiceProxy.Proxy
{
    /// <summary>
    /// Defines required operations for executing synchronous Func-delegates using a proxy wcf client.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IWcfProxy<out T> : IDisposable
    {
        /// <summary>
        /// Executes a synchronous action-delegate by using the contained client proxy.
        /// </summary>
        /// <param name="action">Action used on the client.</param>
        void Execute(Action<T> action);

        /// <summary>
        /// Executes a synchronous func-delegate by using the contained client proxy.
        /// </summary>
        /// <param name="function">Func used on the client.</param>
        /// <typeparam name="TResult">Type of the return value supplied by the called wcf service method.</typeparam>
        /// <returns>Returns value returne by the called service method.</returns>
        TResult Execute<TResult>(Func<T, TResult> function);
    }
}
