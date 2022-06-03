using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
public static class Validation
{
    private static int platsizeX = MissionManager.PlateauSizeX - 1;
    private static int platsizeY = MissionManager.PlateauSizeY - 1;

    public static void RunInCorrectArgs(string value, [CallerArgumentExpression("value")] string expression = "",
        string conditionExpression = "")
    {
        Console.WriteLine($"Incorrect input value: {value} passed in property: {expression}");
        throw new ArgumentException($"Incorrect input value: {value} passed in property: {expression}");
    }

    public static bool CheckArgs(string message, Regex regex)
    {
        if (!regex.IsMatch(message))
            RunInCorrectArgs(message);
        return true;
    }
}

