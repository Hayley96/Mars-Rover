public static class MessageVehicleMove
{
    private static bool check = false;
    public static bool ReceiveCommands(string message, string vehicleType, List<Vehicles> Vehicles, PlateauShapes Plateau, MoveCommands moveCommands)
    {
        if (ValidationEnums.ValidMoveCommand(message))
        {
            string vehicleMoveCommands = message;

            Vehicles.ForEach(vehicle =>
            {
                if (vehicle.Model.Equals(vehicleType))
                    if(moveCommands.RunVehicleMoveCommands(vehicleMoveCommands, vehicle, Plateau))
                        check = true;
                    else
                        check = false;
            });
            return check;
        }
        return check;
    }
}