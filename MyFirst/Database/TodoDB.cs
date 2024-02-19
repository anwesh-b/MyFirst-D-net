using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyFirst.Model;
using MyFirst;

namespace MyFirst.Database
{
    public class TodoDB:BaseDB<TodoItem>
    {
        private readonly MongoClientSettings _mongoSettings;
        private readonly IMongoDatabase _db;
        
        public TodoDB(IOptions<MongoSettings> setting): base(setting, "todo")
        {
        }

        public async Task<List<TodoItem>> getTodoList()
        {
            var data = _todoColelction.Find(new BsonDocument(), new FindOptions
            {
                // Not sure what this does :thinking:
                BatchSize = 3
            });        
            
            // Just typecasting.
            return data.ToList();
        }

        public TodoItem getTodoItemById(string id)
        {
            var data = _todoColelction.Find(data => data.Id == id).FirstOrDefault();
            // var todoitem= new TodoItem { Id = "1", title = "Title", description = "Description" };

            return data;
        }

        public async Task<TodoItem> createTodoItem(TodoItem todo) {
            // Insert status
            await _todoColelction.InsertOneAsync(todo);

            return todo;
        }
    }
}
