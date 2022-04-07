using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection; //GetService gelmesi için

namespace Core.Aspect.Autofac.Caching
{
    //Datamız bozulduğu zaman yeni data eklenirse , data güncellenirse , data silinirse uygulanır.
    //Mesela getall cachede olduğu zaman data ekleyince getall'ı cacheden kaldırmak gerekir. Çünkü listelenecek datalat değişir.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation) //Metod başarılı olduğunda çalışır.
        {
            _cacheManager.RemoveByPattern(_pattern); //patterne göre silme işlemi yapıyor.
        }
    }
}
