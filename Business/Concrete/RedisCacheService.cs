using Bussines.Abstract;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Bussines.Concrete
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public void SetString(string key, string value)
        {
            _distributedCache.SetString(key, value);
        }

        public void SetList(string key, int[] arrayNumbers)
        {
            var strArrayNumber = System.Text.Json.JsonSerializer.Serialize(arrayNumbers);
            _distributedCache.SetString(key, strArrayNumber);
        }

        public string GetValue(string key)
        {
            return _distributedCache.GetString(key);
        }
    }
}
