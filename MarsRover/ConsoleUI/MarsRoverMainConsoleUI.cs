using static System.Console;
public class MarsRoverMainConsoleUI
{
    private MissionManager missionManager;
    private string vehicleType = string.Empty, plateauShape = string.Empty;
    List<string> options = new List<string> { };


    public MarsRoverMainConsoleUI(MissionManager _missionManager)
    {
        missionManager = _missionManager;
    }

    private void RunVehicleSubMenu()
    {
        string prompt = "Select Vehicle";
        options = new List<string> { };
        foreach(var type in missionManager.vehicleManager.subclasses)
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
        foreach (var type in missionManager.plateauManager.subclasses)
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
        string plateausize = ConsoleUIUtilities.GetInputFromUser("Enter size of plateau - [Example: 5 5]: ");
        missionManager?.ReceivePlateauSizeMessage(plateausize);
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
        string vehicleCoordinates = ConsoleUIUtilities.GetInputFromUser("Enter vehicle co-ordinates - [Example: 1 2 N]: ");
        missionManager?.ReceiveVehicleCoordinatesMessage(vehicleCoordinates);
        ConsoleUIUtilities.ResetCursorPosition();
        ConsoleUIUtilities.ClearCurrentConsoleLine();
    }

    public void VehicleMoveMessage()
    {
        string vehicleMoveCommands = ConsoleUIUtilities.GetInputFromUser("Enter vehicle movement commands - [Example: RMMLM]: ");
        missionManager?.ReceiveVehicleMoveCommands(vehicleMoveCommands);
    }
}

