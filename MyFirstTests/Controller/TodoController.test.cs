using Microsoft.Extensions.Logging;
using MyFirst.Controllers;
using MyFirst.Database;
using MyFirst.Model;
using MyFirst.Utils;
using NSubstitute;

using Xunit;

namespace MyFirstTests.Controller;

public class TodoControllerTest
{
    [Theory]
    [InlineData("1,2,8")]
    public void TestCallingOfStringUtilGetCommaSeparatedValues(string input)
    {
        var utilSpy = Substitute.For<IStringUtil>();
        var todoDb = Substitute.For<ITodoDb>();
        var logger = Substitute.For<ILogger<ITodoController>>();

        var todoList = new List<TodoItem>
        {
            new() { Id = "65d310673b5dbbfb2ddd702c", title = "Todo 1", status = "Completed"},
            new() { Id = "65d310673b5dbbfb2ddd702c", title = "Todo 1", status = "Completed"}
        };

        utilSpy.GetCommaSeparatedValues(Arg.Any<string>()).Returns(["a","b"]);

        todoDb.GetTodoList(Arg.Any<TodoFilterGenerator>()).Returns(todoList);
        
        var myTodoController = new TodoController(logger, todoDb, utilSpy);
        
        myTodoController.GetTodoItemList(status: input);

        utilSpy.Received(1).GetCommaSeparatedValues(input);
    }
    
    [Theory]
    [InlineData(null)]
    public void TestNoCallOfStringUtilGetCommaSeparatedValues(string? input)
    {
        var utilSpy = Substitute.For<IStringUtil>();
        var todoDb = Substitute.For<ITodoDb>();
        var logger = Substitute.For<ILogger<ITodoController>>();

        var todoList = new List<TodoItem>
        {
            new() { Id = "65d310673b5dbbfb2ddd702c", title = "Todo 1", status = "Completed"},
            new() { Id = "65d310673b5dbbfb2ddd702c", title = "Todo 1", status = "Completed"}
        };

        utilSpy.GetCommaSeparatedValues(Arg.Any<string>()).Returns(["a","b"]);

        todoDb.GetTodoList(Arg.Any<TodoFilterGenerator>()).Returns(todoList);
        
        var myTodoController = new TodoController(logger, todoDb, utilSpy);
        
        myTodoController.GetTodoItemList(status: input);

        utilSpy.DidNotReceive().GetCommaSeparatedValues(null);
    }
}