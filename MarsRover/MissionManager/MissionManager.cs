﻿using System.Linq;
using System.Text.RegularExpressions;

public class MissionManager
{
    private Regex regex = new(@"^\s$");
    public PlateauManager plateauManager;
    public VehicleManager vehicleManager;
    public PlateauShapes? Plateau { get; private set; }
    public Vehicles? Vehicle { get; private set; }
    private List<Vehicles> Vehicles = new List<Vehicles>();
    public static int PlateauSizeX { get; private set; } = 0;
    public static int PlateauSizeY { get; private set; } = 0;
    private string vehicleType = string.Empty, vehicleDirection = string.Empty, plateauShape = string.Empty;
    private int VehicleAxisX = 0, VehicleAxisY = 0;

    public MissionManager(PlateauManager _plateauManager, VehicleManager _vehicleManager)
    {
        plateauManager = _plateauManager;
        vehicleManager = _vehicleManager;
    }

    public void ReceivePlateauTypeMessage(string message)
    {
        Validation.CheckIfClassExists(message, plateauManager.subclasses);
        plateauShape = message;
    }

    public void ReceivePlateauSizeMessage(string message)
    {
        regex = new(@"^[0-9]*\s[0-9]*$");
        Validation.CheckArgs(message, regex);
        PlateauSizeX = SplitStrings.SplitIntDataIndex0(message);
        PlateauSizeY = SplitStrings.SplitIntDataIndex1(message);
        GetPlateau();
    }

    private void GetPlateau()
    {
        plateauManager.PreparePlateau(PlateauSizeX, PlateauSizeY, plateauShape);
        Plateau = plateauManager.Plateau;
    }

    private void ReDrawPlateau()
    {
        Plateau?.Draw(PlateauSizeX, PlateauSizeY, plateauManager.Grid);
    }

    public void ReceiveVehicleTypeMessage(string message)
    {
        Validation.CheckIfClassExists(message, vehicleManager.subclasses);
        vehicleType = message;
    }

    public void ReceiveVehicleCoordinatesMessage(string message)
    {
        regex = new(@"^[0-9]*\s[0-9]*\s[N,S,E,W]$");
        Validation.CheckArgs(message, regex);
        VehicleAxisX = SplitStrings.SplitIntDataIndex0(message);
        VehicleAxisY = SplitStrings.SplitIntDataIndex1(message);
        vehicleDirection = SplitStrings.SplitDataIndex2(message);
        Vehicles.ForEach(vehicle =>
        {
            if (vehicle.Model.Equals(vehicleType))
                UpdateVehiclePlateauLocation(VehicleAxisY, VehicleAxisX);
            if (vehicle.Equals(Vehicles.Last()))
                GetVehicle();
                UpdateVehiclePlateauLocation(VehicleAxisX, VehicleAxisY);
        });
        if(Vehicles.Count.Equals(0))
            GetVehicle();
            UpdateVehiclePlateauLocation(VehicleAxisX, VehicleAxisY);
    }

    private void GetVehicle()
    {
        vehicleManager.PrepareVehicle(VehicleAxisX, VehicleAxisY, vehicleDirection, vehicleType);
        Vehicle = vehicleManager.Vehicle;
        Vehicles = vehicleManager.Vehicles;
    }

    private void UpdateVehiclePlateauLocation(int VehicleAxisY, int VehicleAxisX)
    {
        if (Vehicle.Model.Equals(vehicleType))
        {
            for (int i = 0; i < Plateau?.PlateauSizeY; i++)
                for (int j = 0; j < Plateau?.PlateauSizeX; j++)
                    if (Plateau?.Grid?[i, j].Color == Vehicle?.GridIcon?.Color)
                    {
                        Plateau.Grid[i, j].Color = ConsoleColor.Cyan;
                        Plateau.Grid[i, j].Content = "   ";
                    }
            Plateau.Grid[VehicleAxisX, VehicleAxisY].Color = Vehicle.GridIcon.Color;
            Plateau.Grid[VehicleAxisX, VehicleAxisY].Content = Vehicle.GridIcon.Content;
        }
        if (!Vehicle.Model.Equals(vehicleType))
            Plateau.Grid[VehicleAxisX, VehicleAxisY].Color = Vehicle.GridIcon.Color;
            Plateau.Grid[VehicleAxisX, VehicleAxisY].Content = Vehicle.GridIcon.Content;
        ReDrawPlateau();
    }
}