using System.Data;
using System.Data.Common;
using Nanorm;

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "Data Source=todos.db;Cache=Shared";
using var db = Microsoft.Data.Sqlite.SqliteFactory.Instance.CreateConnection();
db.ConnectionString = connectionString;

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

static async Task ListCurrentTodos(DbConnection db)
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

static async Task AddTodo(DbConnection db, string title, string? note)
{
    var todo = new Todo { Title = title, Note = note };

    var createdTodo = await db.QuerySingleAsync<Todo>($"""
        INSERT INTO Todos(Title, IsComplete, Note)
        Values({todo.Title}, {todo.IsComplete}, {todo.Note})
        RETURNING *
        """);

    Console.WriteLine($"Added todo {createdTodo?.Id}");
}

static async Task MarkComplete(DbConnection db, string title)
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

static async Task<int> DeleteAllTodos(DbConnection db)
{
    return await db.ExecuteAsync("DELETE FROM Todos");
}

async Task EnsureDb(DbConnection db)
{
    if (Environment.GetEnvironmentVariable("SUPPRESS_DB_INIT") != "true")
    {
        Console.WriteLine($"Ensuring database exists and is up to date at connection string '{connectionString}'");

        const string sql = $"""
            CREATE TABLE IF NOT EXISTS Todos
            (
                {nameof(Todo.Id)} INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                {nameof(Todo.Title)} TEXT NOT NULL,
                {nameof(Todo.Note)} TEXT NULL,
                {nameof(Todo.IsComplete)} INTEGER DEFAULT 0 NOT NULL CHECK({nameof(Todo.IsComplete)} IN (0, 1))
            );
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
