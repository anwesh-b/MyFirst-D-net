using MyFirst.Model;

namespace MyFirst.Controllers;

public interface ITodoController
{
    List<TodoItem> GetTodoItemList(string status);
    TodoItem GetTodoItemById(string id);
    Task<TodoItem> CreateTodoItem(TodoItem todo);
    Task<TodoItem> UpdateTaskStatus(string id, TodoStatusUpdate status);
}
