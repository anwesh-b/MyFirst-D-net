

using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyFirst.Model
{
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }

        public required string title { get; init; }

        public string? description { get; init; }
        
        public string? status { get; init; }
    }

    public class TodoStatusUpdate
    {
        public string status { get; init; }
    }
}
