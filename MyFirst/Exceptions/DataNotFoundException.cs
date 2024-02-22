namespace MyFirst.Exceptions;

public class DataNotFoundException: Exception
{
    public DataNotFoundException()
    {
    }

    public DataNotFoundException(string message)
        : base(message)
    {
    }

    public DataNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public new string GetType()
    {
        return "DataNotFoundException";
    }
}