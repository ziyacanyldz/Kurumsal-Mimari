using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //Classın attributelerini oku
                (true).ToList(); 
            var methodAttributes = type.GetMethod(method.Name) //Metodun attributelerini oku. Validation , Log , Cache gibi olabilir.
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes); //Listeye ekle.

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //Çalışma sırasını öncelik derecesine göre sırala.
        }
    }
}
