```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, macOS Ventura 13.6 (22G120) [Darwin 22.6.0]
Apple M1 Pro 2.40GHz, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.100-preview.6.23330.14
  [Host]     : .NET 8.0.0 (8.0.23.32907), Arm64 RyuJIT AdvSIMD DEBUG
  DefaultJob : .NET 8.0.0 (8.0.23.32907), Arm64 RyuJIT AdvSIMD


```
| Method                                   | Mean     | Error    | StdDev    |
|----------------------------------------- |---------:|---------:|----------:|
| &#39;Benchmark for Set operation in SQL.&#39;    | 885.7 μs | 38.83 μs | 113.88 μs |
| &#39;Benchmark for Get operation in SQL.&#39;    | 442.4 μs | 17.16 μs |  50.33 μs |
| &#39;Benchmark for Delete operation in SQL.&#39; | 409.9 μs | 16.46 μs |  48.01 μs |
