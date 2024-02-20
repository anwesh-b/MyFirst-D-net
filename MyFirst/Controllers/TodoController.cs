using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using MyFirst.Model;
using MyFirst.Database;
using MyFirst.Utils;

namespace MyFirst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // Converted to primary constructor.
    public class TodoController(ILogger<ITodoController> logger, ITodoDb todoDb) : ControllerBase, ITodoController
    {
        [HttpGet("/")]
        public List<TodoItem> GetTodoItemList(string status)
        {
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(GetTodoItemList)}");
            var statuses = StringUtil.GetCommaSeparatedValues(status);

            logger.LogInformation($"Getting all todo list with statuses: ${string.Join(", ", statuses)}");
            
            var data = todoDb.GetTodoList();

            return data;
        }

        [HttpGet("/{id}")]
        public TodoItem GetTodoItemById(string id)
        {
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(GetTodoItemById)}");
            logger.LogInformation($"Getting todo item by id with id: {id}.");
            
            var data = todoDb.GetTodoItemById(id);
        
            if (data == null) {
                throw new Exception("Data not found");
            }
        
            return data;
        }
        
        [HttpPost("/")]
        public async Task<TodoItem> CreateTodoItem(TodoItem todo)
        {
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(CreateTodoItem)}");
            
            logger.LogInformation($"Creating new item with title: {todo.title}.");
            
            // Move to constant folder.
            var defaultStatus = "In Progress";
        
            var insertData = new TodoItem
            {
                title = todo.title,
                status = defaultStatus,
                description = todo.description
            };
            
            return await todoDb.CreateTodoItem(insertData);
        }
        
        [HttpPatch("/{id}/status")]
        public async Task<TodoItem> UpdateTaskStatus(string id, TodoStatusUpdate status)
        { 
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(UpdateTaskStatus)}");
        
            logger.LogInformation($"Updating status of id: {id} to {status.status}");
            
            var data = todoDb.GetTodoItemById(id);
        
            if (data == null) {
                throw new Exception("Data not found");
            }
        
            await todoDb.UpdateItemStatus(id, status.status);
            
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
