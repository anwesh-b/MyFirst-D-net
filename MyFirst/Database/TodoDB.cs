using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyFirst.Model;

namespace MyFirst.Database
{
    public class TodoDb: ITodoDb
    {
        private readonly IMongoCollection<TodoItem> _todoCollection;

        private FilterDefinition<TodoItem> GenerateFilter(TodoFilterGenerator? filter)
        {
            var filterBuilder = Builders<TodoItem>.Filter;
            var filterArray = new List<FilterDefinition<TodoItem>>();
            
            if (filter.Id != null)
            {
                filterArray.Add(filterBuilder.Eq(p => p.Id, filter.Id));
            }

            if (filter.Status != null)
            {
                filterArray.Add(filterBuilder.In(p => p.status, filter.Status));
            }

            return filterArray.Count != 0 ? filterArray.Aggregate((a, b) => a & b) : FilterDefinition<TodoItem>.Empty;
        }

        public TodoDb(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionUri);
            var database = client.GetDatabase(options.Value.Database);
            _todoCollection =  database.GetCollection<TodoItem>("todo");
        }

        public async Task<List<TodoItem>> GetTodoList(TodoFilterGenerator? filter)
        {
            var filterBuild = this.GenerateFilter(filter);

            var data = await _todoCollection.FindAsync(filterBuild, new FindOptions<TodoItem>
            {
                BatchSize = 3
            });

            // Just typecasting.
            return data.ToList();
        }
        
        public async Task<TodoItem> GetTodoItemById(string id)
        {
            var filter = GenerateFilter(new TodoFilterGenerator { Id = id }) ;
            
            var data = await _todoCollection.FindAsync(filter);
            
            return data.FirstOrDefault();
        }
        
        public async Task<TodoItem> CreateTodoItem(TodoItem todo) {
            // Insert status
            await _todoCollection.InsertOneAsync(todo);
        
            return todo;
        }
        
        public async Task<int> UpdateItemStatus(string id, string status)
        {
            // Filter
            var filter = GenerateFilter(new TodoFilterGenerator { Id = id }) ;
            // Data to udpate
            var update = Builders<TodoItem>.Update.Set("status", status);
            
            var updatedItem = await _todoCollection.FindOneAndUpdateAsync(filter, update);
            
            return updatedItem == null ?
                // Handle case where item with specified ID does not exist
                0 : 1;
        }
    }
}
