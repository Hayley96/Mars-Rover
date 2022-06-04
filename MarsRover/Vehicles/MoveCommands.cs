public class MoveCommands
{
    public void RunVehicleMoveCommands(string movecommands, Vehicles vehicle, PlateauShapes plateau)
    {
        foreach (char command in movecommands)
        {
            if (command.ToString().Equals("L"))
                vehicle?.TurnLeft(vehicle.Direction.ToString());
            if (command.ToString().Equals("R"))
                vehicle?.TurnRight(vehicle.Direction.ToString());
            if (command.ToString().Equals("M"))
            {
                _ = Validation.IsOutOfPlateauBounds(vehicle, plateau);
                Validation.CollisionCheck(vehicle, plateau);
                vehicle?.MoveForward(vehicle.Direction.ToString());
            }
        }
    }
}