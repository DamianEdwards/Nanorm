using System.Data;
using System.Data.Common;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Nanorm;
using Npgsql;
using Dapper;

BenchmarkRunner.Run<NanormBenchmarks>();

[MemoryDiagnoser]
public class NanormBenchmarks
{
    private readonly Todo _todo = new() { Title = "Wash the dishes" };
    private readonly string _connectionString = "Server=localhost;Port=5432;Username=postgres;Database=postgres;";
    private NpgsqlDataSource _dataSource = null!;

    [GlobalSetup]
    public void Setup()
    {
        _dataSource = NpgsqlDataSource.Create(_connectionString);
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
        const string sql = "DROP TABLE IF EXISTS public.Todos;";
        _dataSource.ExecuteAsync(sql).GetAwaiter().GetResult();
        _dataSource.Dispose();
    }

    [Benchmark(Baseline = true)]
    public async Task<Todo?> AdoNet()
    {
        const string sql = """
            INSERT INTO Todos(Title, IsComplete)
            Values($1, $2)
            RETURNING *
            """;

        await using var command = _dataSource.CreateCommand();
        command.CommandText = sql;
        command.Parameters.Add(new NpgsqlParameter<string> { Value = _todo.Title });
        command.Parameters.Add(new NpgsqlParameter<bool> { Value = _todo.IsComplete });

        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow);

        if (!reader.HasRows)
        {
            return null;
        }

        await reader.ReadAsync();

        var id = reader.GetInt32(nameof(Todo.Id));
        var title = reader.GetString(nameof(Todo.Title));
        var isComplete = reader.GetBoolean(nameof(Todo.IsComplete));

        return new Todo { Id = id, Title = title, IsComplete = isComplete };
    }

    [Benchmark]
    public async Task<Todo?> AdoNetDbCommon()
    {
        const string sql = """
            INSERT INTO Todos(Title, IsComplete)
            Values(@Title, @IsComplete)
            RETURNING *
            """;
        
        var dbFactory = NpgsqlFactory.Instance;
        await using var connection = dbFactory.CreateConnection();
        connection.ConnectionString = _connectionString;

        await using var command = dbFactory.CreateCommand();
        command.Connection = connection;
        command.CommandText = sql;

        var titleParameter = command.CreateParameter();
        titleParameter.ParameterName = "Title";
        titleParameter.Value = _todo.Title;
        command.Parameters.Add(titleParameter);

        var isCompleteParameter = command.CreateParameter();
        isCompleteParameter.ParameterName = "IsComplete";
        isCompleteParameter.Value = _todo.IsComplete;
        command.Parameters.Add(isCompleteParameter);

        await connection.OpenAsync();
        await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow);

        if (!reader.HasRows)
        {
            return null;
        }

        await reader.ReadAsync();

        var id = reader.GetInt32(nameof(Todo.Id));
        var title = reader.GetString(nameof(Todo.Title));
        var isComplete = reader.GetBoolean(nameof(Todo.IsComplete));

        return new Todo { Id = id, Title = title, IsComplete = isComplete };
    }

    [Benchmark]
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

    [Benchmark]
    public async Task<Todo?> NanormDbCommonParameters()
    {
        const string sql = """
            INSERT INTO Todos(Title, IsComplete)
            Values($1, $2)
            RETURNING *
            """;
        var dataSource = (DbDataSource)_dataSource;
        var createdTodo = await dataSource.QuerySingleAsync<Todo>(
            sql,
            _todo.Title.AsDbParameter(null),
            _todo.IsComplete.AsDbParameter(null));

        return createdTodo;
    }

    [Benchmark]
    public async Task<Todo?> NanormDbCommonStringInterpolation()
    {
        var dataSource = (DbDataSource)_dataSource;
        var createdTodo = await dataSource.QuerySingleAsync<Todo>($"""
            INSERT INTO Todos(Title, IsComplete)
            Values({_todo.Title}, {_todo.IsComplete})
            RETURNING *
            """);

        return createdTodo;
    }
}

public sealed class Todo : IDataRecordMapper<Todo>
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public bool IsComplete { get; set; }

    public static Todo Map(IDataRecord dataRecord) =>
       new()
       {
           Id = dataRecord.GetInt32(nameof(Id)),
           Title = dataRecord.GetString(nameof(Title)),
           IsComplete = dataRecord.GetBoolean(nameof(IsComplete))
       };
}
