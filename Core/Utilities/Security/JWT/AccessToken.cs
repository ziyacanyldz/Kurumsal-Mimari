using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //Kullanıcı , kullanıcı adı ve parolasını verecek bizde ona bir tane token vereceğiz ve ne zaman sonlanacağının bilgisini vereceğiz.
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
