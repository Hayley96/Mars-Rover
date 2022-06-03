﻿Rover rover = new(1, 1, "N", "Rover");
rover.MoveForward("N");
Console.WriteLine($"{rover.AxisX} {rover.AxisY}");

Rectangle rectangle = new(5, 6);
SetUpGrid.SetUp(rectangle.PlateauSizeX, rectangle.PlateauSizeY);
rectangle.Draw(rectangle.PlateauSizeX, rectangle.PlateauSizeY, SetUpGrid.Grid);

VehicleManager vehicleManager = new();
vehicleManager.PrepareVehicleData(1, 1, "N", "Rover");
Console.WriteLine(vehicleManager?.Vehicle?.Model);

PlateauManager plateauManager = new();
plateauManager.PreparePlateau(5, 6, "Rectangle");

MissionManager missionManager = new(plateauManager, vehicleManager);
missionManager.ReceivePlateauTypeMessage("Rectangle");
missionManager.ReceivePlateauSizeMessage("9 9");
