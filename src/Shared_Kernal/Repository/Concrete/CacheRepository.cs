using ecommerce_shared.Repository.interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.Concrete
{
    public class CacheRepository : ICacheRepository
    {
        IDatabase RedisDB;

        public CacheRepository()
        {

            var redis = ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false");
            RedisDB=redis.GetDatabase();

        }
        public T GetData<T>(string key)
        {

            var value=RedisDB.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {


                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public object RemoveData(string key)
        {
         
            var exists=RedisDB.KeyExists(key);
            if(exists) { 
            
                return RedisDB.KeyDelete(key);
            }

            return false;

        }

        public bool SetData<T>(string key, T Data, DateTimeOffset ExpiredAt)
        {

            var ExpiredTime = ExpiredAt.Subtract(DateTime.Now);
            var IsSet = RedisDB.StringSet(key,JsonSerializer.Serialize(Data),ExpiredTime);
            return IsSet;



        }
    }
}
