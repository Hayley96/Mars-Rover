﻿using static System.Console;
public class MenuOptionMarsRoverProgram
{
    private MarsRoverMainConsoleUI MarsUI;
    private bool isUserStillSendingInputs = true;

    public MenuOptionMarsRoverProgram(MarsRoverMainConsoleUI _marsUI)
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
        //ExitMarsRoverProgram();
    }

    private void DisplayAboutInfo()
    {
        MenuOptionHistoryOfMarsProgram.DisplayAboutInfo();
        ExitMarsRoverProgram();
    }

    private void ExitMarsRoverProgram()
    {
        WriteLine("\nPress any key to exit...");
        ReadKey(true);
        Environment.Exit(0);
    }
}