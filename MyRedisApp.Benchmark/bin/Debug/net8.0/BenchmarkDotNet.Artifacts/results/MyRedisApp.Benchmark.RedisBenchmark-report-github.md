```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.6 (22G120) [Darwin 22.6.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.100-preview.6.23330.14
  [Host]     : .NET 8.0.0 (8.0.23.32907), Arm64 RyuJIT AdvSIMD DEBUG
  DefaultJob : .NET 8.0.0 (8.0.23.32907), Arm64 RyuJIT AdvSIMD


```
| Method                                     | Mean     | Error    | StdDev   |
|------------------------------------------- |---------:|---------:|---------:|
| &#39;Benchmark for Set operation in Redis.&#39;    | 76.77 μs | 1.516 μs | 3.776 μs |
| &#39;Benchmark for Get operation in Redis.&#39;    | 77.09 μs | 1.532 μs | 3.871 μs |
| &#39;Benchmark for Delete operation in Redis.&#39; | 74.74 μs | 1.483 μs | 2.928 μs |
