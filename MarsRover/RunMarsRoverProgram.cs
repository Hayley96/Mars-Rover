using static System.Console;

PlateauManager plateauManager = new();
VehicleManager vehicleManager = new();
MoveCommands moveCommands = new();
MissionManager missionManager = new(plateauManager, vehicleManager, moveCommands);
MarsRoverMainConsoleUI runMarsProgramMenuUI = new(missionManager);
MenuOptionMarsRoverProgram marsRoverProgram = new(runMarsProgramMenuUI);
marsRoverProgram.Start();