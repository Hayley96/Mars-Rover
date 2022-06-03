public class MissionManager
{
    public PlateauManager plateauManager;
    public VehicleManager vehicleManager;
    public IPlateau? Plateau { get; private set; }
    public static int PlateauSizeX { get; private set; } = 0;
    public static int PlateauSizeY { get; private set; } = 0;
    public MissionManager(PlateauManager _plateauManager, VehicleManager _vehicleManager)
    {
        plateauManager = _plateauManager;
        vehicleManager = _vehicleManager;
    }


}
