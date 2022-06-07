public static class MessageVehicleTypeHandler
{
    public static bool ReceiveVehicleTypeMessage(string message, int SubclassCount, VehicleManager vehicleManager, Vehicles vehicle, 
        List<Vehicles> Vehicles, out string vehicletype)
    {
        SubclassCount = vehicleManager!.subclasses!.ToList().Count();
        ValidationInputs.CheckIfUserHasInputASubClassThatExists(message, vehicleManager!.subclasses!);
        vehicletype = message;
        if (Vehicles.Count != SubclassCount)
        {
            bool result;
            if (Vehicles.Count.Equals(0))
                return true;
            else
                return result = Vehicles.Where(_vehicle => !_vehicle.Model.Equals(message)).ToList().Count > 0;
        }
        return false;
    }
}