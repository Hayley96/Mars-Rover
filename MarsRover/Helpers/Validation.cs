using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Console;
public static class Validation
{
    public enum Directions { N, E, S, W, };
    public enum Movements { L, R, M, };
   
    public static void RunInCorrectArgs(string value, [CallerArgumentExpression("value")] string expression = "",
        string conditionExpression = "")
    {
        try
        {
            throw new ArgumentException($"Incorrect input value: {value} passed in property: {expression}");
        }
        catch(ArgumentException ex)
        {
            WriteLine(ex.Message);
        }

    }

    public static bool CheckArgs(string message, Regex regex)
    {
        if (!regex.IsMatch(message))
            RunInCorrectArgs(message);
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
            return false;
        }
        
    }

    public static bool IsOutOfPlateauBounds(Vehicles vehicle, PlateauShapes plateau)
    {
        try
        {
            if (vehicle.AxisX >= 0 && vehicle.AxisX < plateau.PlateauSizeX && vehicle.AxisY >= 0 && vehicle.AxisY < plateau.PlateauSizeY)
            {
                return true;
            }
            throw new ArgumentException("Entering Plateau Out-Of-Bounds");
        }
        catch (ArgumentException ex)
        {
            WriteLine(ex.Message);
            return false;
        }
        
    }

    public static bool IsGridLocationOccupied(int axisx, int asixy, PlateauShapes plateau)
    {
        if (plateau?.Grid?[asixy, axisx].Color == ConsoleColor.Cyan)
            return true;
        return false;
    }


    public static bool DeploymentCollisionCheck(int axisX, int axisY, Vehicles vehicle, PlateauShapes plateau)
    {
        try
        {
            if (plateau?.Grid?[axisY, axisX].Color == ConsoleColor.Cyan)
                return true;
            throw new ArgumentException($"ERROR: Something is in the way....Cannot proceed with {vehicle.Model} deployment");
        }
        catch(ArgumentException ex)
        {
            WriteLine(ex.Message);
            return false;
        }

    }

    public static bool MovementCollisionCheck(Vehicles vehicle, PlateauShapes plateau)
    {
        var gridCommand = plateau?.Grid?[0,0];
        try
        {
            for (int i = 1; i < vehicle.NumberOfStepsCapableOfPerforming + 1; i++)
            {
                _ = vehicle.Direction.ToString() switch
                {
                    "N" => gridCommand = plateau?.Grid?[(vehicle.AxisY + i), vehicle.AxisX],
                    "E" => gridCommand = plateau?.Grid?[vehicle.AxisY, (vehicle.AxisX + i)],
                    "W" => gridCommand = plateau?.Grid?[vehicle.AxisY, (vehicle.AxisX - i)],
                    "S" => gridCommand = plateau?.Grid?[(vehicle.AxisY - i), vehicle.AxisX],
                    _ => throw new ArgumentException("ERROR: Direction parameter not found")
                };

                if (gridCommand?.Color != ConsoleColor.Cyan)
                {
                    throw new ArgumentException($"ERROR: Something is in the way....Cannot " +
                        $"proceed with {vehicle.Model} move");
                }
            }
        }
        catch(Exception ex)
        {
            WriteLine(ex.Message);
            return false;
        }
        return true;
        
    }

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