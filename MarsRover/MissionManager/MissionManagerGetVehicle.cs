public static class MissionManagerGetVehicle
{
    public static void GetVehicle(string vehicletype, VehicleManager vehicleManager, out Vehicles Vehicle, out List<Vehicles> Vehicles)
    {
        vehicleManager.PrepareVehicle(vehicletype);
        Vehicle = vehicleManager.Vehicle;
        Vehicles = vehicleManager.Vehicles;
    }
}

