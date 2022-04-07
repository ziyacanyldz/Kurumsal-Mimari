using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationCleim> operationCleims);
        //Kullanıcı adını ve parolasını yazıp düğmeye basınca eğer doğruysa bu interfacede yazdığımız CreateToken operasyonumuz çalışacak.
        //İlgili kullanıcı için veri tabanına gidecek, bu kullanıcının claimlerini bulacak , JWT üretecek ve onları karşıya verecek.
    }
}
