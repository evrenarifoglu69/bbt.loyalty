using Bbt.Campaign.EntityFrameworkCore.Redis;
using Bbt.Campaign.Shared.ServiceDependencies;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Bbt.Campaign.Services.Services.Cache
{
    public class CacheServis : ICacheServis, IScopedService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IRedisDatabaseProvider _redisDatabaseProvider;

        public CacheServis( IRedisDatabaseProvider redisDatabaseProvider, IMemoryCache memoryCache)
        {
            _redisDatabaseProvider = redisDatabaseProvider;
            _memoryCache = memoryCache;
        }

        public async Task CacheRedisTemizle(string token)
        {
            PropertyInfo prop = _memoryCache.GetType().GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public);
            object innerCache = prop.GetValue(_memoryCache);
            MethodInfo clearMethod = innerCache.GetType().GetMethod("Clear", BindingFlags.Instance | BindingFlags.Public);
            clearMethod.Invoke(innerCache, null);

            await _redisDatabaseProvider.FlushDatabase();
        }
    }
}
