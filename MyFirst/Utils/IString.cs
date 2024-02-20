namespace MyFirst.Utils;

public interface IStringUtil
{
    string[] GetCommaSeparatedValues(string input);

    T[] GetCommaSeparatedValues<T>(string input);
}
