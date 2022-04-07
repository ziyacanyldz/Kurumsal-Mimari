using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //Her istek için bir http context oluşur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // Virgülle ayırdığımız rolleri arraye atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)  //MethodInterception dan gelen OnBefore yi override ediyor. Metot çalışmadan önce çalışacak.
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return; //Yetkiler eşleşiyorsa çalışmaya devam et.
                }
            }
            throw new Exception(Massages.AuthorizationDenied); //Yetkin yok hatası.
        }
    }
}
