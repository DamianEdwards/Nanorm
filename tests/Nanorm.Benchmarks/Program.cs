using System.Data;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Nanorm.Npgsql;
using Npgsql;

BenchmarkRunner.Run<DbParametersVsStringInterpolation>();

[MemoryDiagnoser]
public class DbParametersVsStringInterpolation
{
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
        _dataSource?.Dispose();
    }

    [Benchmark(Baseline = true)]
    public async Task<Todo?> DbParameters()
    {
        var todo = new Todo { Title = "Wash the dishes" };

        await using var db = _dataSource.CreateConnection();
        await db.OpenAsync();

        var createdTodo = await db.QuerySingleAsync<Todo>($"""
            INSERT INTO Todos(Title, IsComplete)
            Values($1, $2)
            RETURNING *
            """,
            todo.Title.AsTypedDbParameter(),
            todo.IsComplete.AsTypedDbParameter());

        return createdTodo;
    }

    [Benchmark]
    public async Task<Todo?> StringInterpolation()
    {
        var todo = new Todo { Title = "Wash the dishes" };

        var createdTodo = await _dataSource.QuerySingleAsync<Todo>($"""
            INSERT INTO Todos(Title, IsComplete)
            Values({todo.Title}, {todo.IsComplete})
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
