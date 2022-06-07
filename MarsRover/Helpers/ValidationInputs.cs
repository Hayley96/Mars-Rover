using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Console;
public static class ValidationInputs
{
    public static bool RunInCorrectArgs(string value, [CallerArgumentExpression("value")] string expression = "",
        string conditionExpression = "")
    {
        try
        {
            throw new ArgumentException($"Incorrect input value: {value} passed in property: {expression}");
        }
        catch(ArgumentException ex)
        {
            WriteLine(ex.Message);
            //UserContinueOrEndOption.End();
            return false;
        }

    }

    public static bool CheckArgs(string message, Regex regex)
    {
        if (!regex.IsMatch(message))
        {
            RunInCorrectArgs(message);
            return false;
        }
        return true;
    }

    public static bool CheckIfUserHasInputASubClassThatExists(string message, IEnumerable<Type> subclasses)
    {
        try
        {
            foreach (var type in subclasses.Where(t => t.Name.Equals(message)))
                return true;
            throw new ArgumentException($"No object exists of type: {message} exists....Please Restart");
        }
        catch(ArgumentException ex)
        {
            WriteLine(ex.Message);
            UserContinueOrEndOption.Continue();
            return false;
        }       
    }
}