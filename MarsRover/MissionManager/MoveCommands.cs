using static System.Console;
public class MoveCommands
{
    public void RunVehicleMoveCommands(string movecommands, Vehicles vehicle, PlateauShapes plateau)
    {
        foreach (char command in movecommands)
        {
            if (command.ToString().Equals("L")) 
            {
                vehicle?.TurnLeft(vehicle.Direction.ToString());
                UpdateVehicleOnGrid.Update(vehicle, plateau);
            }

            if (command.ToString().Equals("R"))
            {
                vehicle?.TurnRight(vehicle.Direction.ToString());
                UpdateVehicleOnGrid.Update(vehicle, plateau);
            }
            if (command.ToString().Equals("M"))
                if(ValidationVehicleBoundary.IsOutOfPlateauBounds(vehicle, plateau))
                    if (ValidationVehicleCollision.MovementCollisionCheck(vehicle, plateau))
                    {
                        vehicle?.MoveForward(vehicle.Direction.ToString());
                        UpdateVehicleOnGrid.Update(vehicle, plateau);
                        plateau?.Draw(plateau.PlateauSizeX, plateau.PlateauSizeY, plateau.Grid);
                    }
        }
    }
}