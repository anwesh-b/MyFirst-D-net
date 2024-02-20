using Microsoft.AspNetCore.Mvc;
using MyFirst.Model;
using MyFirst.Database;

namespace MyFirst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase, ITodoController
    {
        private readonly ILogger<ITodoController> _logger;
        
        public ITodoDB _todoDB;

        // Constructor
        public TodoController(ILogger<ITodoController> logger,  ITodoDB todoDb)
        {
            _logger = logger;
            _todoDB = todoDb;
        }

        // Need to define to ignore in swagger.json
        [NonAction]
        public string[] getCommaSeparatedValues(string input) {
            string[] commaSeparatedValues = input.Split(',');

            return commaSeparatedValues;
        }

        [NonAction]
        public T[] getCommaSeparatedValues<T>(string input)
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
        public List<TodoItem> GetTodoItemList(string status)
        {
            using var scope = _logger.BeginScope($"{nameof(TodoController)}.{nameof(GetTodoItemList)}");
            var statuses = this.getCommaSeparatedValues(status);

            _logger.LogInformation(string.Join(", ", statuses));
            
            var data = _todoDB.getTodoList();

            return data;
        }

        [HttpGet("/{id}")]
        public TodoItem GetTodoItemById(string id)
        {
            using var scope = _logger.BeginScope($"{nameof(TodoController)}.{nameof(GetTodoItemById)}");
            _logger.LogInformation("Getting todo item by id with id: " + id);
            
            var data = _todoDB.getTodoItemById(id);
        
            if (data == null) {
                throw new Exception("Data not found");
            }
        
            return data;
        }
        
        [HttpPost("/")]
        public async Task<TodoItem> CreateTodoItem(TodoItem todo)
        {
            using var scope = _logger.BeginScope($"{nameof(TodoController)}.{nameof(CreateTodoItem)}");
            
            _logger.LogInformation($"Creating new item with title: {todo.title}.");
            
            // Move to constant folder.
            var defaultStatus = "In Progress";
        
            var insertData = new TodoItem
            {
                title = todo.title,
                status = defaultStatus,
                description = todo.description
            };
            
            return await _todoDB.createTodoItem(insertData);
        }
        
        [HttpPatch("/{id}/status")]
        public async Task<TodoItem> updateTaskStatus(string id, TodoStatusUpdate status)
        { 
            using var scope = _logger.BeginScope($"{nameof(TodoController)}.{nameof(updateTaskStatus)}");
        
            _logger.LogInformation($"Updating status of id: {id} to {status.status}");
            
            var data = _todoDB.getTodoItemById(id);
        
            if (data == null) {
                throw new Exception("Data not found");
            }
        
            await _todoDB.updateItemStatus(id, status.status);
            
            return new TodoItem
            {
                Id = data.Id,
                title = data.title,
                description = data.description,
                status = status.status
            };
        }
    }
}
