using MyFirst.Model;

namespace MyFirst.Database;

public interface ITodoDb
{
    List<TodoItem> GetTodoList();

    TodoItem GetTodoItemById(string id);
    
    Task<TodoItem> CreateTodoItem(TodoItem todo);
    
    Task<int> UpdateItemStatus(string id, string status);
}
