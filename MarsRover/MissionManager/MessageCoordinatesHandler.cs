using System.Text.RegularExpressions;

public static class MessageCoordinatesHandler
{
    public static void ReceiveCoordinates(string message, string vehicleType, List<Vehicles> Vehicles,
        PlateauShapes Plateau)
    {
        Regex regex = new(@"^[0-9]*\s[0-9]*\s[N,S,E,W]$");
        ValidationInputs.CheckArgs(message, regex);
        int VehicleAxisX = SplitStrings.SplitIntDataIndex0(message);
        int VehicleAxisY = SplitStrings.SplitIntDataIndex1(message);
        string vehicleDirection = SplitStrings.SplitDataIndex2(message);

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
    }
}

