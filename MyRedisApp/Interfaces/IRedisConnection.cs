using StackExchange.Redis;

namespace MyRedisApp.Interfaces
{
    public interface IRedisConnection
    {
        IDatabase GetDatabase();
    }
}