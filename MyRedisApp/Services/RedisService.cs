using StackExchange.Redis;
using MyRedisApp.Models;
using MyRedisApp.Interfaces;

namespace MyRedisApp.Services
{
    public class RedisService : IDatabaseService
    {
        private readonly IRedisConnection _redisConnection;

        public RedisService(IRedisConnection redisConnection)
        {
            _redisConnection = redisConnection;
        }

        public bool Set(ValueModel model)
        {
            var db = _redisConnection.GetDatabase();
            return db.StringSet(model.Key, model.Value);
        }

        public string Get(string key)
        {
            var db = _redisConnection.GetDatabase();
            return db.StringGet(key);
        }

        public bool Delete(string key)
        {
            var db = _redisConnection.GetDatabase();
            return db.KeyDelete(key);
        }
    }
}