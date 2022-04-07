using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager //CoreModule de MemoryCacheManage instance verdik. İleride mesela redis kullanırsak onu instance verebiliriz.
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //Cache de var mı
        void Remove(string key); //Cache den uçurma
        void RemoveByPattern(string pattern); //Belirli bir patterne sahip olanları uçur.
    }
}
