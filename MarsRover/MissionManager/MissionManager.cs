public class MissionManager
{
    public PlateauManager plateauManager;
    public VehicleManager vehicleManager;
    public PlateauShapes? Plateau { get; private set; }
    public static int PlateauSizeX { get; private set; } = 0;
    public static int PlateauSizeY { get; private set; } = 0;
    private string plateauShape = string.Empty;
    public Vehicles? Vehicle { get; private set; }
    private string vehicleType = string.Empty, vehicleCoordinates = string.Empty, vehicleDirection = string.Empty;
    private int VehicleAxisX = 0, VehicleAxisY = 0;
    private List<Vehicles> Vehicles = new List<Vehicles>();
    public MissionManager(PlateauManager _plateauManager, VehicleManager _vehicleManager)
    {
        plateauManager = _plateauManager;
        vehicleManager = _vehicleManager;
    }

    public void ReceivePlateauTypeMessage(string message)
    {
        plateauShape = message;
    }

    public void ReceivePlateauSizeMessage(string message)
    {
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
        vehicleType = message;
    }

    public void ReceiveVehicleCoordinatesMessage(string message)
    {
        vehicleCoordinates = message;
        VehicleAxisX = SplitStrings.SplitIntDataIndex0(message);
        VehicleAxisY = SplitStrings.SplitIntDataIndex1(message);
        vehicleDirection = SplitStrings.SplitDataIndex2(message);
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
        Plateau.Grid[VehicleAxisX, VehicleAxisY].Color = Vehicle.GridIcon.Color;
        Plateau.Grid[VehicleAxisX, VehicleAxisY].Content = Vehicle.GridIcon.Content;
        ReDrawPlateau();
    }
}