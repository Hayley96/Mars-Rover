using static System.Console;
public class MainMenu
{
    private readonly MarsRoverMenu MarsUI;
    private bool isUserStillSendingInputs = true;

    public MainMenu(MarsRoverMenu _marsUI)
    {
        MarsUI = _marsUI;
    }

    public void Start()
    {
        RunMainMenu();
    }

    private void RunMainMenu()
    {
        string prompt = MarsRoverLogo.DrawTitle();
        string[] options = { "Enter Rover program", "About Mars Rover", "Exit" };
        Menu mainMenu = new(prompt, options);
        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                EnterMarsProgram();
                break;
            case 1:
                DisplayAboutInfo();
                break;
            case 2:
                ExitMarsRoverProgram();
                break;
        };

    }

    private void EnterMarsProgram()
    {
        MarsUI.PlateauShapeMessage();
        MarsUI.PlateauSizeMessage();
        MarsUI.VehicleTypeMessage();
        MarsUI.VehicleCoordMessage();
        MarsUI.VehicleMoveMessage();
        do
        {
            WriteLine("\n");
            string userOptions = ConsoleUIUtilities.DisplayUserOptions();
            if (MenuUIValidation.CheckUserUIInput(userOptions))
            {
                switch (userOptions)
                {
                    case "CM":
                        MarsUI.VehicleTypeMessage();
                        MarsUI.VehicleCoordMessage();
                        MarsUI.VehicleMoveMessage();
                        break;
                    case "M":
                        MarsUI.VehicleTypeMessage();
                        MarsUI.VehicleMoveMessage();
                        break;
                    case "D":
                        MarsUI.VehicleTypeMessage();
                        MarsUI.VehicleCoordMessage();
                        MarsUI.VehicleMoveMessage();
                        break;
                    case "E":
                        isUserStillSendingInputs = false;
                        break;
                }
            }
        } while (isUserStillSendingInputs);
    }

    private static void DisplayAboutInfo()
    {
        MenuOptionAboutMarsRoverFacts.DisplayAboutInfo();
        ExitMarsRoverProgram();
    }

    private static void ExitMarsRoverProgram()
    {
        WriteLine("\nPress any key to exit...");
        ReadKey(true);
        Environment.Exit(0);
    }
}