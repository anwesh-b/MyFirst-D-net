using MyFirst.Utils;

namespace MyFirstTests.Utils;

public class StatusTest
{

    [Theory]
    [InlineData("1,2,8", new[] { 1, 2, 8 })]
    [InlineData("progress,completed", new[] { "progress","completed" })]
    [InlineData("1.5,2.5,3.5", new[] { 1.5, 2.5, 3.5 })]
    public void TestGetCommaSeparatedValuesGoodCase<T>(string input, T[] expectedArray)
    {
        var result = StringUtil.GetCommaSeparatedValues<T>(input);

        Assert.Equal(expectedArray, result);
        // No need to return btw
    }
    
    [Theory]
    [InlineData("progress,completed", new[] { "progress","completed" })]
    public void TestGetCommaSeparatedValuesErrorCase<T>(string input, T[] expectedArray)
    {
        // We can define the type of exceptions.
        Assert.Throws<FormatException>(()=> StringUtil.GetCommaSeparatedValues<int>(input));
    } 
}