using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Void olmayıp bir değer döndüren metotlar için.
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
