using MyFirst.Model;

namespace MyFirst.Controllers;

public interface ITodoController
{
    // public TodoController(ILogger<TodoController> logger, IOptions<MongoSettings> mongoSettings)

    List<TodoItem> GetTodoItemList(string status);

    string[] getCommaSeparatedValues(string input);

    T[] getCommaSeparatedValues<T>(string input);
}