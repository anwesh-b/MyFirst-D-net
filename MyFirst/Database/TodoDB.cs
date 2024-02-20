using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyFirst.Model;

namespace MyFirst.Database
{
    public class TodoDb: ITodoDb
    {
        private readonly IMongoCollection<TodoItem> _todoCollection;

        public TodoDb(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionUri);
            var database = client.GetDatabase(options.Value.Database);
            _todoCollection =  database.GetCollection<TodoItem>("todo");
        }

        public List<TodoItem> GetTodoList()
        {
            var data = _todoCollection.Find(new BsonDocument(), new FindOptions
            {
                // Not sure what this does :thinking:
                BatchSize = 3
            });

            // Just typecasting.
            return data.ToList();
        }
        
        public TodoItem GetTodoItemById(string id)
        {
            var data = _todoCollection.Find(data => data.Id == id).FirstOrDefault();
        
            return data;
        }
        
        public async Task<TodoItem> CreateTodoItem(TodoItem todo) {
            // Insert status
            await _todoCollection.InsertOneAsync(todo);
        
            return todo;
        }
        
        public async Task<int> UpdateItemStatus(string id, string status)
        {
            // Filter
            var filter = Builders<TodoItem>.Filter.Eq(p=>p.Id, id);
            // Data to udpate
            var update = Builders<TodoItem>.Update.Set("status", status);
            
            var updatedItem = await _todoCollection.FindOneAndUpdateAsync(filter, update);
            
            return updatedItem == null ?
                // Handle case where item with specified ID does not exist
                0 : 1;
        }
    }
}
