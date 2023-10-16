using MyRedisApp.Interfaces;
using StackExchange.Redis;

namespace MyRedisApp.Services
{
    public class RedisConnection : IRedisConnection
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisConnection(string connectionString)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }

        public IDatabase GetDatabase()
        {
            return _connectionMultiplexer.GetDatabase();
        }
    }
}