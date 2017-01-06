using System;

namespace Etera.Yel.Verkkopalvelu.Service.Proxy
{
    public interface IWcfProxy<out T>
    {
        void Execute(Action<T> action);
        TResult Execute<TResult>(Func<T, TResult> function);
    }
}
