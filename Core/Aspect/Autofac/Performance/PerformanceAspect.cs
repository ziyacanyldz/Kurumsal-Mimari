using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Castle.DynamicProxy;

namespace Core.Aspect.Autofac.Performance
{
    //[PerformanceAspect(5)] Bu şekilde kullanılır. Bu metodun çalışması 5 saniyeyi geçerse beni uyar demek.
    //Performans zaafiyetine sebep olan metod hangisi diye araştırırken AspectInterceptorSelector sınıfına eklersek bütün metodlara eklenir.
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch; //Timer , kronometre. CoreModule de instance oluşturduk.

        public PerformanceAspect(int interval) //Süre parametresi girilir. Örn 5 saniye.
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation) 
        {
            _stopwatch.Start(); //Metodun önünde kronometre başlıyor.
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval) //O ana kadar geçen süre verdiğimiz süreden büyükmü.
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
