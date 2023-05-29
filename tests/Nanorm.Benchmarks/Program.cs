using System.Data;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Nanorm.Npgsql;
using Npgsql;
using Dapper;

BenchmarkRunner.Run<NanormBenchmarks>();

[MemoryDiagnoser]
public class NanormBenchmarks
{
    private readonly Todo _todo = new() { Title = "Wash the dishes" };
    private NpgsqlDataSource _dataSource = null!;

    [GlobalSetup]
    public void Setup()
    {
        _dataSource = NpgsqlDataSource.Create("Server=localhost;Port=5432;Username=postgres;Database=postgres;");
        const string sql = $"""
            CREATE TABLE IF NOT EXISTS public.Todos
            (
                {nameof(Todo.Id)} SERIAL PRIMARY KEY,
                {nameof(Todo.Title)} text NOT NULL,
                {nameof(Todo.IsComplete)} boolean NOT NULL DEFAULT false
            );
            DELETE FROM Todos;
            """;
        _dataSource.ExecuteAsync(sql).GetAwaiter().GetResult();
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        const string sql = "DELETE FROM Todos";
        _dataSource.ExecuteAsync(sql).GetAwaiter().GetResult();
        _dataSource.Dispose();
    }

    [Benchmark(Baseline = true)]
    public async Task<Todo> Dapper()
    {
        const string sql = """
            INSERT INTO Todos(Title, IsComplete)
            Values(@Title, @IsComplete)
            RETURNING *
            """;
        await using var connection = _dataSource.CreateConnection();
        IDbConnection dbConnection = connection;
        var createdTodo = await dbConnection.QuerySingleAsync<Todo>(sql, _todo);

        return createdTodo;
    }

    [Benchmark]
    public async Task<Todo?> NanormDbParameters()
    {
        const string sql = """
            INSERT INTO Todos(Title, IsComplete)
            Values($1, $2)
            RETURNING *
            """;
        var createdTodo = await _dataSource.QuerySingleAsync<Todo>(
            sql,
            _todo.Title.AsTypedDbParameter(),
            _todo.IsComplete.AsTypedDbParameter());

        return createdTodo;
    }

    [Benchmark]
    public async Task<Todo?> NanormStringInterpolation()
    {
        var createdTodo = await _dataSource.QuerySingleAsync<Todo>($"""
            INSERT INTO Todos(Title, IsComplete)
            Values({_todo.Title}, {_todo.IsComplete})
            RETURNING *
            """);

        return createdTodo;
    }
}

public sealed class Todo : IDataReaderMapper<Todo>
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public bool IsComplete { get; set; }

    public static Todo Map(NpgsqlDataReader dataReader) =>
        new()
        {
            Id = dataReader.GetInt32(nameof(Id)),
            Title = dataReader.GetString(nameof(Title)),
            IsComplete = dataReader.GetBoolean(nameof(IsComplete))
        };
}
