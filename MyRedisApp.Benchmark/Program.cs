using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace MyRedisApp.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = DefaultConfig.Instance.WithOptions(ConfigOptions.DisableOptimizationsValidator);
            var summary = BenchmarkRunner.Run<RedisBenchmark>(config);
        }
    }
}