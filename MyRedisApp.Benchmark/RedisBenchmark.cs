using BenchmarkDotNet.Attributes;
using MyRedisApp.Interfaces;
using MyRedisApp.Models;
using MyRedisApp.Services;
using StackExchange.Redis;

namespace MyRedisApp.Benchmark;

public class RedisBenchmark
{
    private List<string> _dummyKeys;
    private ConnectionMultiplexer _redis;
    private IRedisConnection _redisConnection;
    private RedisService _service;
    private readonly int dummyDataCount = 10000;

    [GlobalSetup]
    public void Setup()
    {
        _redis = ConnectionMultiplexer.Connect("localhost");
        _redis.GetDatabase();
        _redisConnection = new RedisConnection("localhost");
        _service = new RedisService(_redisConnection);

        _dummyKeys = new List<string>();

        for (var i = 0; i < dummyDataCount; i++)
        {
            var key = $"key_{i}";
            _dummyKeys.Add(key);

            _service.Set(new ValueModel
            {
                Key = key,
                Value = $"BenchmarkDotNet test value {i}"
            });
        }
    }

    [Benchmark(Description = "Benchmark for Set operation in Redis.")]
    public void Benchmark_SetOperation()
    {
        _service.Set(new ValueModel
        {
            Key = "test_key",
            Value = "BenchmarkDotNet test value"
        });
    }

    [Benchmark(Description = "Benchmark for Get operation in Redis.")]
    public void Benchmark_GetOperation()
    {
        _service.Get(_dummyKeys[50]); // Using the 51st key as an example
    }

    [Benchmark(Description = "Benchmark for Delete operation in Redis.")]
    public void Benchmark_DeleteOperation()
    {
        _service.Delete(_dummyKeys[75]); // Using the 76th key as an example
    }

    [Benchmark(Description = "Benchmark for Fuzzy Search operation in Redis.")]
    public void Benchmark_FuzzySearchOperation()
    {
        _service.FuzzySearch("test value");
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        foreach (var key in _dummyKeys) _service.Delete(key);

        _redis.Close();
        _redis.Dispose();
    }
}