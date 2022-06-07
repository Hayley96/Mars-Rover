using static System.Console;
public class MarsRoverMenu
{
    private MissionManager missionManager;
    private string vehicleType = string.Empty, plateauShape = string.Empty;
    List<string> options = new List<string> { };
    private bool success = false;

    public MarsRoverMenu(MissionManager _missionManager)
    {
        missionManager = _missionManager;
    }

    private void RunVehicleSubMenu()
    {
        WriteLine("\n");
        string prompt = "Select Vehicle";
        options = new List<string> { };
        foreach (var type in missionManager!.vehicleManager!.subclasses!)
        {
            options.Add(type.Name);
        }

        SubMenu subMenu = new(prompt, options, missionManager);
        int selectedIndex = subMenu.Run();


        switch (selectedIndex)
        {
            case 0:
                vehicleType = "Rover";
                break;
            case 1:
                vehicleType = "SuperRover";
                break;
        };
    }

    private void RunPlateauSubMenu()
    {
        string prompt = "Select Plateau";
        options = new List<string> { };
        foreach (var type in missionManager!.plateauManager!.subclasses!)
        {
            options.Add(type.Name);
        }
        SubMenu subMenu = new(prompt, options, missionManager);
        int selectedIndex = subMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                plateauShape = "Rectangle";
                break;
        };
    }

    public void PlateauShapeMessage()
    {
        RunPlateauSubMenu();
        Clear();
        missionManager?.ReceivePlateauTypeMessage(plateauShape);
        ConsoleUIUtilities.ClearCurrentConsoleLine();
    }

    public void PlateauSizeMessage()
    {
        success = false;
        while (!success)
        {
            string plateausize = ConsoleUIUtilities.GetInputFromUser("Enter size of plateau - [Example: 5 5]: ");
            if (missionManager.ReceivePlateauSizeMessage(plateausize))
            {
                success = true;
            }
        }
    }

    public void VehicleTypeMessage()
    {
        RunVehicleSubMenu();
        missionManager?.ReceiveVehicleTypeMessage(vehicleType);
        ConsoleUIUtilities.ResetCursorPosition();
        ConsoleUIUtilities.ClearCurrentConsoleLine();
    }

    public void VehicleCoordMessage()
    {
        success = false;
        while (!success)
        {
            string vehicleCoordinates = ConsoleUIUtilities.GetInputFromUser("Enter vehicle co-ordinates - [Example: 1 2 N]: ");
            if (missionManager.ReceiveVehicleCoordinatesMessage(vehicleCoordinates))
                success = true;
        }
        ConsoleUIUtilities.ResetCursorPosition();
        ConsoleUIUtilities.ClearCurrentConsoleLine();
    }

    public void VehicleMoveMessage()
    {
        success = false;
        while (!success)
        {
            string vehicleMoveCommands = ConsoleUIUtilities.GetInputFromUser("Enter vehicle movement commands - [Example: RMMLM]: ");
            if (missionManager.ReceiveVehicleMoveCommands(vehicleMoveCommands))
                success = true;
        }
    }
}