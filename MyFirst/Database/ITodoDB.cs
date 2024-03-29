using MyFirst.Model;

namespace MyFirst.Database;

public interface ITodoDb
{
    Task<List<TodoItem>> GetTodoList(TodoFilterGenerator? options);

    Task<TodoItem> GetTodoItemById(string id);
    
    Task<TodoItem> CreateTodoItem(TodoItem todo);
    
    Task<int> UpdateItemStatus(string id, string status);
}
