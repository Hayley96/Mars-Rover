public static class MessageVehicleMove
{
    public static void ReceiveCommands(string message, string vehicleType, List<Vehicles> Vehicles, PlateauShapes Plateau, MoveCommands moveCommands)
    {
        ValidationEnums.ValidMoveCommand(message);
        string vehicleMoveCommands = message;

        Vehicles.ForEach(vehicle =>
        {
            if (vehicle.Model.Equals(vehicleType))
            {
                moveCommands.RunVehicleMoveCommands(vehicleMoveCommands, vehicle, Plateau);
            }

        });
    }
}

