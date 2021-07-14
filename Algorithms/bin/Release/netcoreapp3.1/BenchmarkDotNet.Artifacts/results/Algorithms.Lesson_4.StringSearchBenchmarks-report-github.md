``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1083 (2004/May2020Update/20H1)
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.201
  [Host]     : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT


```
|                Method |      Mean |     Error |    StdDev |
|---------------------- |----------:|----------:|----------:|
|    LinearSearchString | 30.498 μs | 0.1594 μs | 0.1413 μs |
| SearchStringByHashSet |  1.703 μs | 0.0112 μs | 0.0105 μs |
