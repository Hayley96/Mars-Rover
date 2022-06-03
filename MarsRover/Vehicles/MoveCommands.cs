public class MoveCommands
{
    public void RunVehicleMoveCommands(string movecommands, Vehicles vehicle, PlateauShapes plateau)
    {
        foreach (char command in movecommands)
        {
            if (command.ToString().Equals("L"))
                vehicle?.TurnLeft(command.ToString());
            if (command.ToString().Equals("R"))
                vehicle?.TurnRight(command.ToString());
            if (command.ToString().Equals("M"))
            {
                _ = Validation.IsOutOfPlateauBounds(vehicle, plateau);
                vehicle?.MoveForward(command.ToString());
            }
        }
    }
}

