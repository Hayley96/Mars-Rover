PlateauManager plateauManager = new();
VehicleManager vehicleManager = new();
MoveCommands moveCommands = new();
MissionManager missionManager = new(plateauManager, vehicleManager, moveCommands);
MarsRoverMenu runMarsProgramMenuUI = new(missionManager);
MainMenu marsRoverProgram = new(runMarsProgramMenuUI);
marsRoverProgram.Start();