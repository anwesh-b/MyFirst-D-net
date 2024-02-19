

using System.Runtime.InteropServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyFirst.Model
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string title { get; set; }

        public string? description { get; set; }
        
        public string? status { get; set; }
    }
}
