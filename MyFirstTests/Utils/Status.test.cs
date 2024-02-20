using MyFirst.Utils;

namespace MyFirstTests.Utils;

public class StatusTest
{

    private IStringUtil _stringUtil;

    public StatusTest()
    {
        _stringUtil = new StringUtil();
    }

    [Theory]
    [InlineData("1,2,8", new[] { 1, 2, 8 })]
    [InlineData("progress,completed", new[] { "progress","completed" })]
    [InlineData("1.5,2.5,3.5", new[] { 1.5, 2.5, 3.5 })]
    public void TestGetCommaSeparatedValuesGoodCase<T>(string input, T[] expectedArray)
    {
        var result = _stringUtil.GetCommaSeparatedValues<T>(input);

        Assert.Equal(expectedArray, result);
        // No need to return btw
    }
    
    [Theory]
    [InlineData("progress,completed")]
    public void TestGetCommaSeparatedValuesErrorCase(string input)
    {
        // We can define the type of exceptions.
        Assert.Throws<FormatException>(()=> _stringUtil.GetCommaSeparatedValues<int>(input));
    } 
}