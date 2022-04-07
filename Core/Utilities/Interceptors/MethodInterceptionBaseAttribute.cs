using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Öncelik - hangi attribute önce çalışsın. Önce validation sonra loglama gibi.

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
