using static System.Console;
public static class ValidationVehicleCollision
{
    public static bool DeploymentCollisionCheck(int axisX, int axisY, Vehicles vehicle, PlateauShapes plateau)
    {
        try
        {
            if (plateau?.Grid?[axisY, axisX].Color == ConsoleColor.Cyan)
                return true;
            throw new ArgumentException($"ERROR: Something is in the way....Cannot proceed with {vehicle.Model} deployment\n" +
                $"to that position. Defaulting to position [0,0] - you can now move from position [0,0]");
        }
        catch(ArgumentException ex)
        {
            WriteLine(ex.Message);
            UserContinueOrEndOption.Continue();
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
            UserContinueOrEndOption.Continue();
            return false;
        }
        return true;
        
    }
}