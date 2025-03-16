using Nanorm;
using Npgsql;

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "Server=localhost;Port=5432;Username=postgres;Database=postgres";
#if NET8_0_OR_GREATER
await using var db = new NpgsqlSlimDataSourceBuilder(connectionString).Build();
#else
await using var db = NpgsqlDataSource.Create(connectionString);
#endif

await EnsureDb(db);

await ListCurrentTodos(db);

await AddTodo(db, "Do the groceries", "Don't forget to buy milk!");
await AddTodo(db, "Give the dog a bath", null);
await AddTodo(db, "Wash the car", null);

Console.WriteLine();

await ListCurrentTodos(db);

await MarkComplete(db, "Wash the car");

await ListCurrentTodos(db);

var deletedCount = await DeleteAllTodos(db);
Console.WriteLine($"Deleted all {deletedCount} todos!");
Console.WriteLine();

static async Task ListCurrentTodos(NpgsqlDataSource db)
{
    var todos = db.QueryAsync<Todo>("SELECT * FROM Todos");
    var todosList = await todos.ToListAsync();

    if (todosList.Count == 0)
    {
        Console.WriteLine("There are currently no todos!");
        Console.WriteLine();
        return;
    }

    var idColHeading = "Id";
    var titleColHeading = "Title";
    var noteColHeading = "Note";
    var idWidth = int.Max(idColHeading.Length, todosList.Max(t => t.Id).ToString().Length);
    var titleWidth = int.Max(titleColHeading.Length, todosList.Max(t => t.Title?.Length ?? 0));
    var noteWidth = int.Max(noteColHeading.Length, todosList.Max(t => t.Note?.Length ?? 0));
    var lineWidth = idWidth + 1 + titleWidth + 1 + noteWidth;

    Console.Write(idColHeading.PadRight(idWidth));
    Console.Write(" ");
    Console.Write(titleColHeading.PadRight(titleWidth));
    Console.Write(" ");
    Console.WriteLine(noteColHeading.PadRight(noteWidth));
    Console.WriteLine(new string('-', lineWidth));

    foreach (var todo in todosList)
    {
        Console.Write(todo.Id.ToString().PadRight(idWidth));
        Console.Write(" ");
        Console.Write(todo.Title?.PadRight(titleWidth));
        Console.Write(" ");
        Console.WriteLine(todo.Note?.PadRight(noteWidth));
    }

    Console.WriteLine();
}

static async Task AddTodo(NpgsqlDataSource db, string title, string? note)
{
    var todo = new Todo { Title = title, Note = note };

    var createdTodo = await db.QuerySingleAsync<Todo>($"""
        INSERT INTO Todos(Title, IsComplete, Note)
        Values({todo.Title}, {todo.IsComplete}, {todo.Note})
        RETURNING *
        """);

    Console.WriteLine($"Added todo {createdTodo?.Id}");
}

static async Task MarkComplete(NpgsqlDataSource db, string title)
{
    var result = await db.ExecuteAsync($"""
        UPDATE Todos
        SET IsComplete = true
        WHERE Title = {title}
          AND IsComplete = false
        """);

    if (result == 0)
    {
        throw new InvalidOperationException($"No incomplete todo with title '{title}' was found!");
    }

    Console.WriteLine($"Todo '{title}' completed!");
    Console.WriteLine();
}

static async Task<int> DeleteAllTodos(NpgsqlDataSource db)
{
    return await db.ExecuteAsync("DELETE FROM Todos");
}

async Task EnsureDb(NpgsqlDataSource db)
{
    if (Environment.GetEnvironmentVariable("SUPPRESS_DB_INIT") != "true")
    {
        Console.WriteLine($"Ensuring database exists and is up to date at connection string '{connectionString}'");

        const string sql = $"""
            CREATE TABLE IF NOT EXISTS public.Todos
            (
                {nameof(Todo.Id)} SERIAL PRIMARY KEY,
                {nameof(Todo.Title)} text NOT NULL,
                {nameof(Todo.Note)} text NULL,
                {nameof(Todo.IsComplete)} boolean NOT NULL DEFAULT false
            );

            DELETE FROM Todos;
            """;
        await db.ExecuteAsync(sql);

        Console.WriteLine();
    }
    else
    {
        Console.WriteLine($"Database initialization disabled for connection string '{connectionString}'");
    }
}

[DataRecordMapper]
sealed partial class Todo
{
    public int Id { get; set; }

    public required string Title { get; set; }
    
    public string? Note { get; set; }

    public bool IsComplete { get; set; }
}
