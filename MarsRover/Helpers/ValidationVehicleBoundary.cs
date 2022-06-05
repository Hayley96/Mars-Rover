using static System.Console;
public static class ValidationVehicleBoundary
{
    public static bool IsOutOfPlateauBounds(Vehicles vehicle, PlateauShapes plateau)
    {
        try
        {
            if (vehicle.AxisX.Equals(0) && vehicle.Direction.ToString().Equals("W"))
            {
                throw new Exception("ERROR: Cannot proceed with move - Entering Out-Of-Bounds of Plateau");
            }

            if (vehicle.AxisX.Equals(plateau.PlateauSizeX - 1) && vehicle.Direction.ToString().Equals("E"))
            {
                throw new Exception("ERROR: Cannot proceed with move - Entering Out-Of-Bounds of Plateau");
            }

            if (vehicle.AxisY.Equals(0) && vehicle.Direction.ToString().Equals("S"))
            {
                throw new Exception("ERROR: Cannot proceed with move - Entering Out-Of-Bounds of Plateau");
            }
            if (vehicle.AxisY.Equals(plateau.PlateauSizeY - 1) && vehicle.Direction.ToString().Equals("S"))
            {
                throw new Exception("ERROR: Cannot proceed with move - Entering Out-Of-Bounds of Plateau");
            }
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
            UserContinueOrEndOption.Continue();
            return false;
        }
        return true;
      
    }
}