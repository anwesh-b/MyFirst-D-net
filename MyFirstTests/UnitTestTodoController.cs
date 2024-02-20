using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyFirst.Database;
using MyFirst.Model;
using NSubstitute;

namespace MyFirstTests;

using MyFirst.Controllers;
public class UnitTestTodoController
{
    // private TodoController _todoController;
    private readonly ILogger<ITodoController> _logger;
    private readonly ITodoDb _todoDb;

    public UnitTestTodoController()
    { 
        _logger = Substitute.For<ILogger<TodoController>>();
        _todoDb = Substitute.For<ITodoDb>();
        
    }

    [Theory]
    [InlineData("1,2,8", new[] { 1, 2, 8 })]
    [InlineData("progress,completed", new[] { "progress","completed" })]
    [InlineData("1.5,2.5,3.5", new[] { 1.5, 2.5, 3.5 })]
    public void TestGetCommaSeparatedValuesGoodCase<T>(string input, T[] expectedArray)
    {
        var todoController = new TodoController(_todoDb);
        // Assert.Same(todoController._todoDB, dependentClassMock);
        //
        var result = todoController.GetCommaSeparatedValues<T>(input);

        Assert.Equal(expectedArray, result);
        // No need to return btw
    }
}