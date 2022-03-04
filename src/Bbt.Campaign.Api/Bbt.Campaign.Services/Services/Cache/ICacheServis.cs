namespace Bbt.Campaign.Services.Services.Cache
{
    public interface ICacheServis
    {
        Task CacheRedisTemizle(string token);
    }
}
