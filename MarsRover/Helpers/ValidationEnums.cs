using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Console;
public static class ValidationEnums
{
    public enum Directions { N, E, S, W, };
    public enum Movements { L, R, M, };

    public static bool ValidMoveCommand(string message)
    {
        try
        {
            foreach (char move in message)
                return Enum.IsDefined(typeof(Movements), move.ToString()) ? true : throw new ArgumentException("Move parameter out of range");
        }
        catch (ArgumentException ex)
        {
            WriteLine(ex.Message);
            return false;
        }
        return false;
    }

    public static Directions ValidDirection(string message)
    {
        Directions result;
        try
        {
            return Enum.TryParse<Directions>(message, out result) ? result : throw new ArgumentException("Direction parameter out of range");
        }
        catch(ArgumentException ex)
        {
            WriteLine(ex.Message);
            return Directions.N;
        }

    }
}