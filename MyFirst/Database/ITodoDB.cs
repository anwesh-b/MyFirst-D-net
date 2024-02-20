using MongoDB.Driver;
using MyFirst.Model;

namespace MyFirst.Database;

public interface ITodoDB
{
    List<TodoItem> getTodoList();

    // TodoItem getTodoItemById(string id);
    //
    // Task<TodoItem> createTodoItem(TodoItem todo);
    //
    // Task<int> updateItemStatus(string id, string status);
}
