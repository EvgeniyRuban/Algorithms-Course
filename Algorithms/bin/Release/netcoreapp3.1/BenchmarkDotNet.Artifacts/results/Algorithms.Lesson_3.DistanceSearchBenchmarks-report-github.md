``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1083 (2004/May2020Update/20H1)
AMD Ryzen 5 2600, 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.201
  [Host]     : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT


```
|                   Method |     Mean |    Error |   StdDev |
|------------------------- |---------:|---------:|---------:|
|           RefTypeByFloat | 67.49 ns | 1.052 ns | 0.932 ns |
|         ValueTypeByFloat | 26.96 ns | 0.083 ns | 0.077 ns |
|        ValueTypeInDouble | 18.04 ns | 0.083 ns | 0.069 ns |
| ValueTypeInFloatSqrtless | 24.98 ns | 0.077 ns | 0.068 ns |
