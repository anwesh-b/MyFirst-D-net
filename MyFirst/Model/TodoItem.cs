

using System.Runtime.InteropServices;

namespace MyFirst.Model
{
    public class TodoItem
    {
        public required int id { get; set; }
        public required string title { get; set; }

        public string? description { get; set; }
    }
}
