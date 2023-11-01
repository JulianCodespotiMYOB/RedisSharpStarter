using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using MyRedisApp.Interfaces;
using MyRedisApp.Models;
using MyRedisApp.Services;

namespace MyRedisApp.Benchmark
{
    public class SqlBenchmark
    {
        private List<string> _dummyKeys;
        private ISqlDatabaseService _sqlService;
        private readonly int dummyDataCount = 10000;

        [GlobalSetup]
        public void Setup()
        {
            _sqlService = new SqlService(new SqlConnectionService("Server=localhost,1433;Database=BenchmarkDb;User Id=sa;Password=SQLDatabase123;"));
            Cleanup();
            
            _dummyKeys = new List<string>();
            
            for (var i = 0; i < dummyDataCount; i++)
            {
                var key = $"key_{i}";
                _dummyKeys.Add(key);
                
                _sqlService.Set(new ValueModel
                {
                    Key = key,
                    Value = $"BenchmarkDotNet test value {i}"
                });
            }
        }
        
        int _counter = 0;

        [Benchmark(Description = "Benchmark for Set operation in SQL.")]
        public void Benchmark_SqlSetOperation()
        {
            _sqlService.Set(new ValueModel
            {
                Key = _counter.ToString(),
                Value = "BenchmarkDotNet test value"
            });
            
            _counter++;
        }

        [Benchmark(Description = "Benchmark for Get operation in SQL.")]
        public void Benchmark_SqlGetOperation()
        {
            _sqlService.Get(_dummyKeys[50]);
        }

        [Benchmark(Description = "Benchmark for Delete operation in SQL.")]
        public void Benchmark_SqlDeleteOperation()
        {
            _sqlService.Delete(_dummyKeys[75]);
        }

        [GlobalCleanup]
        public void Cleanup()
        {

            _sqlService.DeleteAll();
            // if(_dummyKeys != null && _sqlService != null)
            // {
            //     foreach (var key in _dummyKeys) _sqlService.Delete(key);
            // }
        }

    }
}