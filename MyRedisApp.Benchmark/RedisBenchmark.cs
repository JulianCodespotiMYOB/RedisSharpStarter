using MyRedisApp.Interfaces;
using MyRedisApp.Models;
using MyRedisApp.Services;
using BenchmarkDotNet.Attributes;
using StackExchange.Redis;

namespace MyRedisApp.Benchmark
{
    public class RedisBenchmark
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;
        private RedisService _service;
        private IRedisConnection _redisConnection;

        [GlobalSetup]
        public void Setup()
        {
            _redis = ConnectionMultiplexer.Connect("localhost");
            _db = _redis.GetDatabase();
            _redisConnection = new RedisConnection("localhost");
            _service = new RedisService(_redisConnection);
        }

        [Benchmark(Description = "Benchmark for Set operation in Redis.")]
        public void Benchmark_SetOperation()
        {
            _service.Set(new ValueModel
            {
                Key = Guid.NewGuid().ToString(),
                Value = "BenchmarkDotNet test value"
            });
        }

        [Benchmark(Description = "Benchmark for Get operation in Redis.")]
        public void Benchmark_GetOperation()
        {
            _service.Get("some_known_key");
        }

        [Benchmark(Description = "Benchmark for Delete operation in Redis.")]
        public void Benchmark_DeleteOperation()
        {
            _service.Delete("some_known_key");
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _redis.Close();
            _redis.Dispose();
        }
    }
}