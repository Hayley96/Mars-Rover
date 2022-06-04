PlateauManager plateauManager = new();
VehicleManager vehicleManager = new();
MoveCommands moveCommands = new();
MissionManager missionManager = new(plateauManager, vehicleManager, moveCommands);
missionManager.ReceivePlateauTypeMessage("Rectangle");
missionManager.ReceivePlateauSizeMessage("10 5");

missionManager.ReceiveVehicleTypeMessage("Rover");
missionManager.ReceiveVehicleCoordinatesMessage("1 2 E");
missionManager.ReceiveVehicleMoveCommands("MM");

missionManager.ReceiveVehicleTypeMessage("SuperRover");
missionManager.ReceiveVehicleCoordinatesMessage("4 0 N");
missionManager.ReceiveVehicleMoveCommands("MMLM");