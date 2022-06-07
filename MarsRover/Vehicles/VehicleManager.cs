public class VehicleManager
{
    public Vehicles? Vehicle { get; private set; }
    public List<Vehicles> Vehicles { get; private set; } = new List<Vehicles>();
    public  IEnumerable<Type>? Subclasses { get; private set; }
    private string UserVehicleType = string.Empty;

    public void PrepareVehicle(string vehicletype)
    {
        UserVehicleType = vehicletype;
        SetVehicle(UserVehicleType);
    }

    public void GetSubclasses()
    {
        Subclasses = GetUserInputInstances.GetSubclasses(typeof(Vehicles));
    }

    private void SetVehicle(string vehicleType)
    {
        object[] VehicleParamArr = { UserVehicleType, };
        Vehicle = (Vehicles)GetUserInputInstances.Get(vehicleType, typeof(Vehicles), VehicleParamArr);
        Vehicles = AddItemToList.Add(Vehicles, Vehicle);
    }
}