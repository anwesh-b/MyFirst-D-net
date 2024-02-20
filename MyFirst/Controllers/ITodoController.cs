using MyFirst.Model;

namespace MyFirst.Controllers;

public interface ITodoController
{
    // public TodoController(ILogger<TodoController> logger, IOptions<MongoSettings> mongoSettings)

    List<TodoItem> GetTodoItemList(string status);

    string[] GetCommaSeparatedValues(string input);

    T[] GetCommaSeparatedValues<T>(string input);
    TodoItem GetTodoItemById(string id);
    Task<TodoItem> CreateTodoItem(TodoItem todo);
    Task<TodoItem> UpdateTaskStatus(string id, TodoStatusUpdate status);
}
