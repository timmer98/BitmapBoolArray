# MemorySavingBoolArray
This bool array implementation only need 1/8 in RAM compared to the standard "new bool[n]". This is archived by using a byte array internally and shifting bits. A normal bool struct in C# normally needs a byte of RAM. This implementation uses only one bit per boolean saved boolean array. But this comes at a cost though: Get and set operations take roughly twice the time compared to the standard boolean array.

The project is more or less for educational purposes, because the real world use cases for such a data structure are probably rather limited. The project contains 4 iterations of the same structure from a ```MemorySavingBoolArray``` that was the first idea to the ```AggressiveInlinedMemorySavingBoolArray``` which uses a faster modulus technique and makes use of aggressive inlining. All implementations are roughly tested and their performance is compared thruogh the ```ArrayBenchmark.cs```. The benchmark proves that the memory need for the data structure is indeed reduced to roughly 1/8. The indexing on the other side takes in the fastest way roughly twice the time. A use case for the data structure could in the processing of a really large bitmap on a system with limited memory. In the following you can see the complete results of the benchmarks.

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|                              Method |    Size |       Mean |    Error |   StdDev |     Median |   Allocated |
|------------------------------------ |-------- |-----------:|---------:|---------:|-----------:|------------:|
|           Set_MemorySavingBoolArray | 1000000 | 1,456.1 μs |  5.29 μs |  4.95 μs | 1,454.1 μs |      122 KB |
| Set_FastModuloMemorySavingBoolArray | 1000000 | 1,208.3 μs | 22.14 μs | 57.16 μs | 1,182.9 μs |      122 KB |
|                 Set_NormalBoolArray | 1000000 |   699.7 μs | 12.83 μs | 12.00 μs |   700.0 μs |      977 KB |
|     Set_AggressiveInliningBoolArray | 1000000 | 1,198.4 μs | 15.24 μs | 25.47 μs | 1,192.3 μs |      122 KB |
|    Set_IntegerMemorySavingBoolArray | 1000000 | 1,215.2 μs |  2.90 μs |  2.84 μs | 1,214.9 μs |      122 KB |
|           Get_MemorySavingBoolArray | 1000000 | 1,623.1 μs |  8.93 μs |  6.97 μs | 1,621.2 μs |      122 KB |
| Get_FastModuloMemorySavingBoolArray | 1000000 | 1,360.5 μs | 13.38 μs | 12.52 μs | 1,362.3 μs |      122 KB |
|                 Get_NormalBoolArray | 1000000 |   237.9 μs |  1.30 μs |  1.15 μs |   237.6 μs |      977 KB |
|     Get_AggressiveInliningBoolArray | 1000000 |   442.0 μs |  0.88 μs |  0.83 μs |   441.8 μs |      122 KB |
|    Get_IntegerMemorySavingBoolArray | 1000000 |   441.9 μs |  1.26 μs |  1.18 μs |   441.3 μs |      122 KB |
