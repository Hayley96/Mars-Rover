using System.Reflection;

public class VehicleManager
{
    public Vehicles? Vehicle { get; private set; }
    private List<Vehicles> Vehicles = new List<Vehicles>();
    private static int VehicleAxisX;
    private static int VehicleAxisY;
    private static string Direction = string.Empty;
    private string UserVehicleType = string.Empty;

    public void PrepareVehicleData(int vehicleAxisX, int vehicleAxisY, string vehicleDirection, string vehicletype)
    {
        VehicleAxisX = vehicleAxisX;
        VehicleAxisY = vehicleAxisY;
        Direction = vehicleDirection;
        UserVehicleType = vehicletype;
        SetVehicle(UserVehicleType);
    }

    private void SetVehicle(string vehicleType)
    {
        object[] VehicleParamArr = { VehicleAxisX, VehicleAxisY, Direction, UserVehicleType, };
        Vehicle = (Vehicles)GetUserInputInstances.Get(vehicleType, VehicleParamArr);
        Vehicles = AddItemToList.Add(Vehicles, Vehicle);
    }
}