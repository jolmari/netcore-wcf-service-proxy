using System;

namespace WcfServiceProxy.Proxy
{
    public interface IWcfProxy<out T>
    {
        void Execute(Action<T> action);
        TResult Execute<TResult>(Func<T, TResult> function);
    }
}
