public class MissionManager
{
    public PlateauManager plateauManager;
    public VehicleManager vehicleManager;
    public IPlateau? Plateau { get; private set; }
    public static int PlateauSizeX { get; private set; } = 0;
    public static int PlateauSizeY { get; private set; } = 0;
    private string plateauShape = string.Empty;

    public Vehicles? Vehicle { get; private set; }
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
}