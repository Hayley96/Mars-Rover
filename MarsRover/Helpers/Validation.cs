using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
public static class Validation
{
    public enum Directions { N, E, S, W, };
    public enum Movements { L, R, M, };
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

    public static bool CheckIfClassExists(string message, IEnumerable<Type> subclasses)
    {
        foreach (var type in subclasses.Where(t => t.Name.Equals(message)))
            return true;
        return false;
    }

    public static bool IsOutOfPlateauBounds(Vehicles vehicle, PlateauShapes plateau)
    {
        if (vehicle.AxisX >= 0 && vehicle.AxisX < plateau.PlateauSizeX && vehicle.AxisY >= 0 && vehicle.AxisY < plateau.PlateauSizeY)
        {
            return true;
        }
        Console.WriteLine("ERROR: Entering Plateau Out-Of-Bounds");
        throw new ArgumentException("Entering Plateau Out-Of-Bounds");
    }

    public static void CollisionCheck(Vehicles vehicle, PlateauShapes plateau)
    {
        var command = plateau.Grid[0,0];
        _ = vehicle.Direction.ToString() switch
        {
            "N" => command = plateau.Grid[(vehicle.AxisY + vehicle.NumberOfStepsCapableOfPerforming), vehicle.AxisX],
            "E" => command = plateau.Grid[vehicle.AxisY, (vehicle.AxisX + vehicle.NumberOfStepsCapableOfPerforming)],
            "W" => command = plateau.Grid[vehicle.AxisY, (vehicle.AxisX -vehicle.NumberOfStepsCapableOfPerforming)],
            "S" => command = plateau.Grid[(vehicle.AxisY - vehicle.NumberOfStepsCapableOfPerforming), vehicle.AxisX],
            _ => throw new ArgumentException($"ERROR: Something is in the way....Cannot proceed with {vehicle.Model} move")
        };

        if (command.Color != ConsoleColor.Cyan)
        {
            Console.WriteLine($"ERROR: Something is in the way....Cannot proceed with {vehicle.Model} move");
            throw new ArgumentException($"ERROR: Something is in the way....Cannot proceed with {vehicle.Model} move");
        }
    }

    public static bool ValidMoveCommand(string message)
    {
        foreach(char move in message)
            return Enum.IsDefined(typeof(Movements), move.ToString()) ? true : throw new ArgumentException("Direction parameter out of range");
        return true;
    }

    public static Directions ValidDirection(string message)
    {
        Directions result;
        return Enum.TryParse<Directions>(message, out result) ? result : throw new ArgumentException("Direction parameter out of range");
    }
}