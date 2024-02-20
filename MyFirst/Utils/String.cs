namespace MyFirst.Utils;

public class StringUtil: IStringUtil
{
    // Need to define to ignore in swagger.json
    public string[] GetCommaSeparatedValues(string input) {
        var commaSeparatedValues = input.Split(',');

        return commaSeparatedValues;
    }

    public T[] GetCommaSeparatedValues<T>(string input)
    {
        var commaSeparatedValues = input.Split(',');

        var convertedArray = new T[commaSeparatedValues.Length];
            
        for (int i = 0; i < commaSeparatedValues.Length; i++)
        {

            var res = Convert.ChangeType(commaSeparatedValues[i], typeof(T));       
            convertedArray.SetValue(res, i);
        }

        return convertedArray;
    } 
}