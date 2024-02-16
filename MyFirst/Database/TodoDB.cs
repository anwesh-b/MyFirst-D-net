using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyFirst.Model;
using MyFirst;


namespace MyFirst.Database
{
    public class TodoDB
    {
        private readonly MongoClientSettings _mongoSettings;
        
        public TodoDB()
        {
        }   

        public async Task<TodoItem[]> getTodoList()
        {
            var todoList = new[] {
                new TodoItem { id = 1, title="Title", description="Description" }
            };

            return todoList;
        }

        public TodoItem getTodoItemById(int id)
        {
            var todoitem= new TodoItem { id = 1, title = "Title", description = "Description" };

            return todoitem;
        }

        public TodoItem createTodoItem() {
            var createdTodo =  new TodoItem { id = 1, description = "Hello", title = "Hello" };

            return createdTodo;
        }
    }
}
