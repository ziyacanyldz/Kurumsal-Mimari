using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection; ////GetService gelmesi için

namespace Core.Aspect.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //Biz süre vermezsek veri 60dk default olarak cache de duracak.
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); 
            //Aspect olduğu için injection yapamadık ServiceTool kullandık. Caching altyapısını değiştirirsek bu kısıma dokunmayacağız.
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); //Metodun namespace + sınıf ismini verir. Keyi verir.
            var arguments = invocation.Arguments.ToList(); //Metodun parametrelerini listeye çevir.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //Parametre değeri varsa keyin içerisine yazar. Parametre yoksa default null. 
            if (_cacheManager.IsAdd(key)) //Bellekte böyle bir cache var mı?
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return; //invocation.ReturnValue metodu hiç çalıştırmadan geri dön demek.
            }
            invocation.Proceed(); //Metodu çalıştır , devam ettir demek.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
            //Eğer bu key daha önce varsa direk cache den al , yoksa veri tabanından al ama cache ye ekle.
        }
    }
}
