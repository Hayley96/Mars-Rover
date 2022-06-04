using System.Linq;
using System.Text.RegularExpressions;

public class MissionManager
{
    private Regex regex = new(@"^\s$");
    private PlateauManager plateauManager;
    private VehicleManager vehicleManager;
    private MoveCommands moveCommands;
    public PlateauShapes? Plateau { get; private set; }
    public Vehicles? Vehicle { get; private set; }
    private List<Vehicles> Vehicles = new List<Vehicles>();
    public static int PlateauSizeX { get; private set; } = 0;
    public static int PlateauSizeY { get; private set; } = 0;
    private string vehicleType = string.Empty, vehicleDirection = string.Empty, vehicleMoveCommands = string.Empty, plateauShape = string.Empty;
    private int VehicleAxisX = 0, VehicleAxisY = 0;

    public MissionManager(PlateauManager _plateauManager, VehicleManager _vehicleManager, MoveCommands _moveCommands)
    {
        plateauManager = _plateauManager;
        vehicleManager = _vehicleManager;
        moveCommands = _moveCommands;
        plateauManager.GetSubclasses();
        vehicleManager.GetSubclasses();
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
        Plateau?.Draw(PlateauSizeX, PlateauSizeY, Plateau.Grid);
    }
    private void UpdateVehiclePlateauLocation(int VehicleAxisY, int VehicleAxisX, Vehicles vehicle)
    {
        for (int i = 0; i < Plateau?.PlateauSizeY; i++)
            for (int j = 0; j < Plateau?.PlateauSizeX; j++)
                if (Plateau?.Grid?[i, j].Color == vehicle?.GridIcon?.Color)
                {
                    Plateau.Grid[i, j].Color = ConsoleColor.Cyan;
                    Plateau.Grid[i, j].Content = "   ";
                }
        Plateau.Grid[VehicleAxisX, VehicleAxisY].Color = vehicle.GridIcon.Color;
        Plateau.Grid[VehicleAxisX, VehicleAxisY].Content = vehicle.GridIcon.Content;
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
        if (Vehicles.Count.Equals(0))
            GetVehicle();
            UpdateVehiclePlateauLocation(VehicleAxisX, VehicleAxisY, Vehicle);
        Vehicles.ToList().ForEach(vehicle =>
        {
            if (vehicle.Model.Equals(vehicleType))
                UpdateVehiclePlateauLocation(vehicle.AxisX, vehicle.AxisY, vehicle);
            if (!vehicle.Model.Equals(vehicleType) && vehicle.Equals(Vehicles.Last()))
                GetVehicle();
                UpdateVehiclePlateauLocation(vehicle.AxisX, vehicle.AxisY, vehicle);
        });
        ReDrawPlateau();
    }

    public void ReceiveVehicleMoveCommands(string message)
    {
        Validation.ValidMoveCommand(message);
        vehicleMoveCommands = message;
        foreach (var vehicle in Vehicles.Where(v => v.Model.Equals(vehicleType)))
        {
            moveCommands.RunVehicleMoveCommands(vehicleMoveCommands, vehicle, Plateau);
            UpdateVehiclePlateauLocation(vehicle.AxisX, vehicle.AxisY, vehicle);
        }
        ReDrawPlateau();
        DisplayResults();
    }

    private void GetVehicle()
    {
        vehicleManager.PrepareVehicle(VehicleAxisX, VehicleAxisY, vehicleDirection, vehicleType);
        Vehicle = vehicleManager.Vehicle;
        Vehicles = vehicleManager.Vehicles;
    }

    private void DisplayResults()
    {
        Vehicles.ForEach(vehicle =>
        {
            DisplayResult.DisplayResultString(vehicle);
        });
    }
}