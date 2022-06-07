using System.Text.RegularExpressions;

public static class MessageCoordinatesHandler
{
    private static int VehicleAxisX, VehicleAxisY;
    private static string vehicleDirection;
    public static bool ReceiveCoordinates(string message, string vehicleType, List<Vehicles> Vehicles,
        PlateauShapes Plateau)
    {
        Regex regex = new(@"^[0-9]*\s[0-9]*\s[N,S,E,W]$");
        if (ValidationInputs.CheckArgs(message, regex))
        {
            VehicleAxisX = SplitStrings.SplitIntDataIndex0(message);
            VehicleAxisY = SplitStrings.SplitIntDataIndex1(message);
            vehicleDirection = SplitStrings.SplitDataIndex2(message);

            Vehicles.ToList().ForEach(vehicle =>
            {
                if (vehicle.Model.Equals(vehicleType))
                {
                    if (ValidationVehicleCollision.DeploymentCollisionCheck(VehicleAxisX, VehicleAxisY, vehicle, Plateau))
                    {
                        vehicle.AxisX = VehicleAxisX;
                        vehicle.AxisY = VehicleAxisY;
                        vehicle.Direction = ValidationEnums.ValidDirection(vehicleDirection);
                        UpdateVehicleOnGrid.Update(vehicle, Plateau);
                    }
                }
            });
            return true;
        }
        return false;
    }
}

