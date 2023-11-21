# Nanorm

A tiny data-access helper library for ADO.NET. Trimming and native AOT friendly.

It supports:

- [PostgreSQL](https://www.postgresql.org/) via [`Npgsql`](https://www.npgsql.org/)
- [SQLite](https://www.sqlite.org/) via [`Microsoft.Data.SQLite`](https://learn.microsoft.com/dotnet/standard/data/sqlite/)
- Any ADO.NET data provider via [`System.Data.Common`](https://learn.microsoft.com/dotnet/api/system.data.common)

## How to use

Nanorm supports .NET 6+, with special support for .NET 7+ thanks to [static virtual members on interfaces](https://learn.microsoft.com/dotnet/csharp/whats-new/tutorials/static-virtual-interface-members) and source generators.

### Getting started

1. Install the `Nanorm` package that's suitable for the ADO.NET provider (i.e. database) you're using. Using the `dotnet` command line in the project directory:
    - PostgreSQL:

        ```shell
        dotnet add package Nanorm.Npgsql --prerelease
        ```

    - SQLite:

        ```shell
        dotnet add package Nanorm.Sqlite --prerelease
        ```

    - All other ADO.NET providers:

        ```shell
        dotnet add package Nanorm --prerelease
        ```

1. Create a `class`, `record`, or `struct` to map a database query result to. If you're using .NET 7 or .NET 8, you can make it `partial` and decorate it with the `[DataRecordMapper]` attribute to enable the source generator which will take care of implementing the `IDataRecordMapper<T>` interface for you:

    ```csharp
    [DataRecordMapper]
    public partial class Todo
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public bool IsComplete { get; set; }
    }

    // Generated for you if .NET 7+, otherwise you'll need to write it yourself
    partial class Todo : IDataRecordMapper<Todo>
    {
        public static Todo Map(System.Data.IDataRecord dataRecord) =>
            new()
            {
                Id = dataRecord.GetInt32("Id"),
                Title = dataRecord.GetString("Title"),
                IsComplete = dataRecord.GetBoolean("IsComplete"),
            };
    }
    ```

1. Create an instance of the appropriate `IDbConnection` type and use one of the Nanorm extension methods to execute a query. The `QueryAsync` methods return `IAsyncEnumerable` so you can `await foreach` over the results or simply call `ToListAsync()` to asynchronously get a `List<T>` result:

    ```csharp
    // Using Npgsql to query a local PostgreSQL instance
    var connectionString = "Server=localhost;Port=5432;Username=postgres;Database=postgres";
    await using var db = new NpgsqlDataSourceBuilder(connectionString).Build();

    var todos = db.QueryAsync<Todo>("SELECT * FROM Todos");
    var todosList = await todos.ToListAsync();

    if (todosList.Count == 0)
    {
        Console.WriteLine("There are currently no todos!");
    }
    else
    {
        Console.WriteLine($"Found {todosList.Count} todo(s):");
        foreach (var todo in todosList)
        {
            Console.WriteLine($"({todo.Id}) {todo.Title}");
        }
    }
    ```

### Using parameters

Nanorm supports a few different ways to pass parameters to queries:

- Passing an interpolated string that is processed by Nanorm's [custom string interpolation handler](https://learn.microsoft.com/dotnet/csharp/whats-new/tutorials/interpolated-string-handler). This is the preferred approach. The query is automatically parameterized in an optimal way, i.e. no string concatenation, uses pooled allocations, etc.:

    ```csharp
    var title = "Do the dishes";
    var result = db.QueryAsync<Todo>($"SELECT * FROM Todos WHERE Title = {title}")
    ```

- Passing instances of the ADO.NET provider's `DbParameter` implementation as parameters, e.g.:

    ```csharp
    var title = "Do the dishes";
    var sql = "SELECT * FROM Todos WHERE Title = $1";
    var result = db.QueryAsync<Todo>(sql, new NpgsqlParameter { Value =  title }))
    ```

- Passing a callback that modifies the ADO.NET provider's parameter collection implementation, e.g.:

    ```csharp
    var title = "Do the dishes";
    var sql = "SELECT * FROM Todos WHERE Title = $1";
    var result = db.QueryAsync<Todo>(sql, parameters => parameters.Add(title))
    ```

### Extension methods

The following extension methods are provided to make it easier to work against your database:

Method | Description
------ | -----------
`ExecuteAsync` | Executes a command that does not return any results.
`ExecuteScalarAsync` | Executes a command and returns the first column of the first row in the first returned result set. All other columns, rows, and result sets are ignored.
`QueryAsync` | Executes a command and returns the result as an appropriately typed `DbDataReader`
`QueryAsync<T>` | Executes a command and returns the rows mapped to instances of `T` as an `IAsyncEnumerable<T>`
`QuerySingleAsync<T>` | Executes a command and maps the first row returned to an instance of `T`
`AsDbParameter` | Creates a provider-specific parameter object from the `object` value
`AsTypedDbParameter<T>` | Creates a generic parameter from the `T` value ([Npgsql only](https://www.npgsql.org/doc/basic-usage.html#strongly-typed-parameters))
`ToListAsync<T>` | Asynchronously converts an `IAsyncEnumerable<T>` to a `List<T>`

## Benchmarks

Nanorm is intended to be a very thin layer over ADO.NET with support for trimming and native AOT. Here's how it compares to raw ADO.NET and Dapper for a [simple insert & return operation](./tests/Nanorm.Benchmarks/Program.cs) with regards to execution time and memory allocations:

| Method                            | Mean     | Error   | StdDev  | Ratio | RatioSD | Allocated | Alloc Ratio |
|---------------------------------- |---------:|--------:|--------:|------:|--------:|----------:|------------:|
| AdoNet                            | 401.7 us | 3.83 us | 3.58 us |  1.00 |    0.00 |   2.49 KB |        1.00 |
| AdoNetDbCommon                    | 417.6 us | 8.33 us | 7.79 us |  1.04 |    0.03 |   4.18 KB |        1.68 |
| Dapper                            | 400.7 us | 4.57 us | 4.28 us |  1.00 |    0.01 |   3.19 KB |        1.28 |
| DapperAot                         | 409.2 us | 5.80 us | 5.43 us |  1.02 |    0.01 |   3.27 KB |        1.32 |
| NanormDbParameters                | 402.7 us | 5.47 us | 5.12 us |  1.00 |    0.02 |   2.65 KB |        1.07 |
| NanormStringInterpolation         | 403.5 us | 5.75 us | 5.38 us |  1.00 |    0.02 |   2.68 KB |        1.08 |
| NanormDbCommonParameters          | 404.0 us | 5.48 us | 5.12 us |  1.01 |    0.01 |   2.86 KB |        1.15 |
| NanormDbCommonStringInterpolation | 406.8 us | 3.60 us | 3.19 us |  1.01 |    0.01 |   3.12 KB |        1.26 |
