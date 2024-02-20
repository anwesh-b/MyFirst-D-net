using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyFirst.Model;
using MyFirst;

namespace MyFirst.Database
{
    public class TodoDB: ITodoDB
    {
        protected readonly IMongoCollection<TodoItem> _todoColelction;

        public TodoDB(IOptions<MongoSettings> options)
        {
            // _baseDB = baseDB;
            
         MongoClient client = new MongoClient(options.Value.ConenctionUri);
         IMongoDatabase database = client.GetDatabase(options.Value.Database);
         _todoColelction =  database.GetCollection<TodoItem>("todo");
        }

        public List<TodoItem> getTodoList()
        {
            // var data = _todoColelction.Find(new BsonDocument(), new FindOptions
            // {
            //     // Not sure what this does :thinking:
            //     BatchSize = 3
            // });        

            var data = new TodoItem
            {
                Id = "65d3178c832a339dffef1cd0",
                title = "Titile",
                description = "Mero description"
            };

            return [data];

            // Just typecasting.
            // return data.ToList();
        }
        //
        // public TodoItem getTodoItemById(string id)
        // {
        //     var data = _todoColelction.Find(data => data.Id == id).FirstOrDefault();
        //     // var todoitem= new TodoItem { Id = "1", title = "Title", description = "Description" };
        //
        //     return data;
        // }
        //
        // public async Task<TodoItem> createTodoItem(TodoItem todo) {
        //     // Insert status
        //     await _todoColelction.InsertOneAsync(todo);
        //
        //     return todo;
        // }
        //
        // public async Task<int> updateItemStatus(string id, string status)
        // {
        //     // Filter
        //     var filter = Builders<TodoItem>.Filter.Eq(p=>p.Id, id);
        //     // Data to udpate
        //     var update = Builders<TodoItem>.Update.Set("status", status);
        //     
        //     var updatedItem = _todoColelction.FindOneAndUpdateAsync(filter, update);
        //     
        //     if (updatedItem == null)
        //     {
        //         // Handle case where item with specified ID does not exist
        //         return 0;
        //     }
        //     
        //     return 1;
        // }
    }
}
