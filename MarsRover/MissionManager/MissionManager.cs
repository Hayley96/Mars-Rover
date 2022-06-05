using System.Text.RegularExpressions;

public class MissionManager
{
    public  PlateauManager plateauManager { get; private set; }
    public VehicleManager vehicleManager { get; private set; } 
    public PlateauShapes? Plateau { get; private set; }
    public Vehicles? Vehicle { get; private set; }
    private Regex? regex;
    private MoveCommands moveCommands;
    private int PlateauSizeX = 0, PlateauSizeY = 0, VehicleAxisX = 0, VehicleAxisY = 0, SubclassCount = 0;
    private string vehicleType = string.Empty, vehicleDirection = string.Empty, vehicleMoveCommands = string.Empty, plateauShape = string.Empty;
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
        Validation.CheckIfUserHasInputASubClassThatExists(message, plateauManager.subclasses);
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

    public void ReDrawPlateau() =>
        Plateau?.Draw(PlateauSizeX, PlateauSizeY, Plateau.Grid);
    public void ReceiveVehicleTypeMessage(string message)
    {
        SubclassCount = vehicleManager.subclasses.ToList().Count();
        Validation.CheckIfUserHasInputASubClassThatExists(message, vehicleManager.subclasses);
        vehicleType = message;
        if(Vehicles.Count != SubclassCount)
            GetVehicle(vehicleType);
    }

    public void ReceiveVehicleCoordinatesMessage(string message)
    {
        regex = new(@"^[0-9]*\s[0-9]*\s[N,S,E,W]$");
        Validation.CheckArgs(message, regex);
        VehicleAxisX = SplitStrings.SplitIntDataIndex0(message);
        VehicleAxisY = SplitStrings.SplitIntDataIndex1(message);
        vehicleDirection = SplitStrings.SplitDataIndex2(message);

        Vehicles.ToList().ForEach(vehicle =>
        {
            if (vehicle.Model.Equals(vehicleType))
            {
                if(Validation.DeploymentCollisionCheck(VehicleAxisX, VehicleAxisY, vehicle, Plateau))
                {
                    vehicle.AxisX = VehicleAxisX;
                    vehicle.AxisY = VehicleAxisY;
                    vehicle.Direction = Validation.ValidDirection(vehicleDirection);
                    UpdateVehicleOnGrid.Update(vehicle, Plateau);
                }
            }
        });
        ReDrawPlateau();
    }

    public void ReceiveVehicleMoveCommands(string message)
    {
        Validation.ValidMoveCommand(message);
        vehicleMoveCommands = message;

        Vehicles.ToList().ForEach(vehicle =>
        {
            if (vehicle.Model.Equals(vehicleType))
            {
                moveCommands.RunVehicleMoveCommands(vehicleMoveCommands, vehicle, Plateau);
                UpdateVehicleOnGrid.Update(vehicle, Plateau);
            }

        });
        ReDrawPlateau();
        DisplayResults();
    }

    private void GetVehicle(string vehicletype)
    {
        vehicleManager.PrepareVehicle(vehicletype);
        Vehicle = vehicleManager.Vehicle;
        Vehicles = vehicleManager.Vehicles;
    }

    public void DisplayResults() =>
        DisplayResult.DisplayResultString(Vehicles);
}