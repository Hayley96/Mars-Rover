using System.Reflection;

public class VehicleManager
{
    public Vehicles? Vehicle { get; private set; }
    public List<Vehicles> Vehicles { get; private set; } = new List<Vehicles>();
    public  IEnumerable<Type>? subclasses { get; private set; }
    private static int VehicleAxisX;
    private static int VehicleAxisY;
    private static string Direction = string.Empty;
    private string UserVehicleType = string.Empty;

    public void PrepareVehicle(int vehicleAxisX, int vehicleAxisY, string vehicleDirection, string vehicletype)
    {
        VehicleAxisX = vehicleAxisX;
        VehicleAxisY = vehicleAxisY;
        Direction = vehicleDirection;
        UserVehicleType = vehicletype;
        SetVehicle(UserVehicleType);
    }

    public void GetSubclasses()
    {
        subclasses = GetUserInputInstances.GetSubclasses(typeof(Vehicles));
    }

    private void SetVehicle(string vehicleType)
    {
        object[] VehicleParamArr = { VehicleAxisX, VehicleAxisY, Direction, UserVehicleType, };
        Vehicle = (Vehicles)GetUserInputInstances.Get(vehicleType, typeof(Vehicles), VehicleParamArr);
        Vehicles = AddItemToList.Add(Vehicles, Vehicle);
    }
}