﻿using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation çalıştırmak istediğimiz metod. Mesela Add metodu.
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) 
        {
            var isSuccess = true;
            OnBefore(invocation); //Metodun başında çalışır.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //Hata aldığında çalışır.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //Metod başarılı olduğunda çalışır.
                }
            }
            OnAfter(invocation); //Metoddan sonra çalışır.
            //Bunların hepsinin içi boş aspect te hangidini doldurursak o çalışır.
        }
    }
}
