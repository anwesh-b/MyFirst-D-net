using MyFirst.Model;

namespace MyFirst.Controllers;

public interface ITodoController
{
    Task<List<TodoItem>> GetTodoItemList(string status);
    Task<TodoItem> GetTodoItemById(string id);
    Task<TodoItem> CreateTodoItem(TodoItem todo);
    Task<TodoItem> UpdateTaskStatus(string id, TodoStatusUpdate status);
}
