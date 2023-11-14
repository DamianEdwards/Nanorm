# Nanorm

A tiny data-access helper library for ADO.NET. Trimming and native AOT friendly.

It supports:

- Any ADO.NET data provider via [`System.Data.Common`](https://learn.microsoft.com/dotnet/api/system.data.common)
- PostgreSQL via [`Npgsql`](https://www.npgsql.org/)
- [SQLite](https://www.sqlite.org/) via [`Microsoft.Data.SQLite`](https://learn.microsoft.com/dotnet/standard/data/sqlite/)

## Benchmarks

Results of latest benchmarks 

|                            Method |     Mean |     Error |    StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |---------:|----------:|----------:|------:|--------:|----------:|------------:|
|                            AdoNet | 2.513 ms | 0.0498 ms | 0.0553 ms |  1.00 |    0.00 |   3.23 KB |        1.00 |
|                    AdoNetDbCommon | 2.506 ms | 0.0319 ms | 0.0283 ms |  0.99 |    0.03 |   3.52 KB |        1.09 |
|                            Dapper | 2.499 ms | 0.0461 ms | 0.0431 ms |  0.99 |    0.03 |   3.35 KB |        1.04 |
|                NanormDbParameters | 2.532 ms | 0.0496 ms | 0.0488 ms |  1.01 |    0.02 |   3.39 KB |        1.05 |
|         NanormStringInterpolation | 2.478 ms | 0.0220 ms | 0.0183 ms |  0.98 |    0.02 |   3.41 KB |        1.06 |
|          NanormDbCommonParameters | 2.515 ms | 0.0484 ms | 0.0475 ms |  1.00 |    0.02 |   3.57 KB |        1.11 |
| NanormDbCommonStringInterpolation | 2.515 ms | 0.0319 ms | 0.0283 ms |  1.00 |    0.02 |   3.84 KB |        1.19 |
