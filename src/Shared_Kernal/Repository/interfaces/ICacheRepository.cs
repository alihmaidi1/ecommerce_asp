using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.interfaces
{
    public interface ICacheRepository
    {

        public T GetData<T>(string key);

        bool SetData<T>(string key, T Data,DateTimeOffset ExpiredAt);

        object RemoveData(string key);

        public bool IsExists(string key);

    }
}
