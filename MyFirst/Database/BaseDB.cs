using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyFirst.Model;

namespace MyFirst.Database;

public class BaseDB<T>
{
    protected readonly IMongoCollection<T> _todoColelction;

    public BaseDB(IOptions<MongoSettings> options, string colection)
    {
        MongoClient client = new MongoClient(options.Value.ConenctionUri);
        IMongoDatabase database = client.GetDatabase(options.Value.Database);
        _todoColelction = database.GetCollection<T>(colection);
    }
}