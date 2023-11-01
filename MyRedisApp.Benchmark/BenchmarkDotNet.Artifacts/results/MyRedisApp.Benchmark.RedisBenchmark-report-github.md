```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.6 (22G120) [Darwin 22.6.0]
Apple M1 Pro 2.40GHz, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.100-preview.6.23330.14
  [Host]     : .NET 8.0.0 (8.0.23.32907), Arm64 RyuJIT AdvSIMD DEBUG
  DefaultJob : .NET 8.0.0 (8.0.23.32907), Arm64 RyuJIT AdvSIMD


```
| Method                                           | Mean     | Error    | StdDev   | Median   |
|------------------------------------------------- |---------:|---------:|---------:|---------:|
| &#39;Benchmark for Set operation in Redis.&#39;          | 70.59 μs | 1.412 μs | 4.163 μs | 70.48 μs |
| &#39;Benchmark for Get operation in Redis.&#39;          | 68.79 μs | 1.350 μs | 2.757 μs | 67.89 μs |
| &#39;Benchmark for Delete operation in Redis.&#39;       | 69.26 μs | 1.378 μs | 2.995 μs | 67.92 μs |
| &#39;Benchmark for Fuzzy Search operation in Redis.&#39; | 69.37 μs | 1.376 μs | 3.134 μs | 68.36 μs |
