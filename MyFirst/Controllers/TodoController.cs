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
    public class TodoController(ILogger<ITodoController> logger, ITodoDb todoDb, IStringUtil stringUtil) : ControllerBase, ITodoController
    {
        [HttpGet("/")]
        public async Task<List<TodoItem>> GetTodoItemList(string? status)
        {
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(GetTodoItemList)}");
            var statuses = status != null ? stringUtil.GetCommaSeparatedValues(status) : null;

            if (statuses != null)
            {
                var statusesLog = string.Join(", ", statuses); 
                logger.LogInformation("Getting all todo list with statuses: {statusesLog}.", statusesLog);
            }
            else
            {
                logger.LogInformation("Getting all todo list.");
                
            }

            var data = await todoDb.GetTodoList(new TodoFilterGenerator
            {
                Status = statuses
            });

            return data;
        }

        [HttpGet("/{id}")]
        public async Task<TodoItem> GetTodoItemById(string id)
        {
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(GetTodoItemById)}");
            logger.LogInformation("Getting todo item by id with id: {id}.", id);
            
            var data = await todoDb.GetTodoItemById(id);
        
            if (data == null) {
                throw new Exception("Data not found");
            }
        
            return data;
        }
        
        [HttpPost("/")]
        public async Task<TodoItem> CreateTodoItem(TodoItem todo)
        {
            using var scope = logger.BeginScope($"{nameof(TodoController)}.{nameof(CreateTodoItem)}");
            
            logger.LogInformation("Creating new item with title: {todo.title}.", todo.title);
            
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
        
            logger.LogInformation("Updating status of id: {id} to {status.status}", id ,status.status);
            
            var data = await todoDb.GetTodoItemById(id);
        
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
