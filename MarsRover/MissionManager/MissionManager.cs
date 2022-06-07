public class MissionManager
{
    public PlateauManager plateauManager { get; private set; }
    public VehicleManager vehicleManager { get; private set; }
    public PlateauShapes? Plateau { get; private set; }
    public Vehicles? Vehicle { get; private set; }
    private PlateauShapes? PlateauTemp; 
    private Vehicles? VehicleTemp;
    private MoveCommands moveCommands;
    private int PlateauSizeX = 0, PlateauSizeY = 0, SubclassCount = 0;
    private string vehicleType = string.Empty, plateauShape = string.Empty;
    private List<Vehicles> Vehicles = new List<Vehicles>();

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
        ValidationInputs.CheckIfUserHasInputASubClassThatExists(message, plateauManager!.subclasses!);
        plateauShape = message;
    }

    public bool ReceivePlateauSizeMessage(string message)
    {
        MessagePlateauHandler.ReceivePlateauSizeMessage(message, out PlateauSizeX, out PlateauSizeY);
        if(PlateauSizeX != 0 && PlateauSizeY != 0)
        {
            MessagePlateauHandler.GetPlateau(plateauManager, out PlateauTemp, PlateauSizeX, PlateauSizeY, plateauShape);
            Plateau = PlateauTemp;
            return true;
        }
        return false;
    }

    public void ReceiveVehicleTypeMessage(string message)
    {
        if(MessageVehicleTypeHandler.ReceiveVehicleTypeMessage(message, SubclassCount, vehicleManager, Vehicle!, Vehicles, out vehicleType))
            MissionManagerGetVehicle.GetVehicle(vehicleType, vehicleManager, out VehicleTemp, out Vehicles);
    }

    public bool ReceiveVehicleCoordinatesMessage(string message)
    {
        if(MessageCoordinatesHandler.ReceiveCoordinates(message, vehicleType, Vehicles, Plateau!))
        {
            ReDrawPlateau();
            return true;
        }
        return false;
    }

    public bool ReceiveVehicleMoveCommands(string message)
    {
        if (MessageVehicleMove.ReceiveCommands(message, vehicleType, Vehicles, Plateau!, moveCommands))
        {
            ReDrawPlateau();
            DisplayResults();
            return true;
        }
        return false;
    }

    public void DisplayResults() =>
        DisplayResult.DisplayResultString(Vehicles);
    public void ReDrawPlateau() =>
    Plateau?.Draw(PlateauSizeX, PlateauSizeY, Plateau!.Grid!);
}