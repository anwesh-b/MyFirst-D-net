using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirst.Model;
using MyFirst.Database;

namespace MyFirst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoDB _todoDB;

        // Constructor
        public TodoController(ILogger<TodoController> logger, IOptions<MongoSettings> mongoSettings)
        {
            _logger = logger;
            _todoDB = new TodoDB(mongoSettings);
        }

        private string[] getCommaSeparatedValues(string input) {
            string[] commaSeparatedValues = input.Split(',');

            return commaSeparatedValues;
        }

        private T[] getCommaSeparatedValues<T>(string input)
        {
            string[] commaSeparatedValues = input.Split(',');

            T[] convertedArray = new T[commaSeparatedValues.Length];
            
            for (int i = 0; i < commaSeparatedValues.Length; i++)
            {

                var res = Convert.ChangeType(commaSeparatedValues[i], typeof(T));       
                convertedArray.SetValue(res, i);
            }

            return convertedArray;
        }

        [HttpGet("/")]
        public  async Task<List<TodoItem>> GetTodoItemList(string status)
        {
            var statuses = this.getCommaSeparatedValues(status);

            _logger.LogInformation(string.Join(", ", statuses));
            
            var data = await _todoDB.getTodoList();

            return data;
        }

        [HttpGet("/{id}")]
        public TodoItem GetTodoItemById(string id, int deeplyNestedId, int nestedId)
        {
            _logger.LogInformation("Getting todo item by id with id: " + id);
            
            var data = _todoDB.getTodoItemById(id);

            if (data == null) {
                throw new Exception("Data not found");
            }

            return data;
        }

        [HttpPost("/")]
        public async Task<TodoItem> CreateTodoItem(TodoItem todo) {
            _logger.LogInformation($"Creating new item with title: {todo.title}.");

            return await _todoDB.createTodoItem( todo);
        }
    }
}
