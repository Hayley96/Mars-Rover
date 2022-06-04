PlateauManager plateauManager = new();
VehicleManager vehicleManager = new();
MoveCommands moveCommands = new();
MissionManager missionManager = new(plateauManager, vehicleManager, moveCommands);
missionManager.ReceivePlateauTypeMessage("Rectangle");
missionManager.ReceivePlateauSizeMessage("6 7");

missionManager.ReceiveVehicleTypeMessage("Rover");
missionManager.ReceiveVehicleCoordinatesMessage("1 2 N");
missionManager.ReceiveVehicleMoveCommands("MM");

missionManager.ReceiveVehicleTypeMessage("SuperRover");
missionManager.ReceiveVehicleCoordinatesMessage("2 4 N");
missionManager.ReceiveVehicleMoveCommands("LM");
