using static System.Console;
public static class DisplayResult
{
    public static void DisplayResultString(List<Vehicles> vehiclesList)
    {
        vehiclesList.ForEach(_vehicle =>
        {
            string ResultCoordinates = ($"New co-ordinates for vehicle {_vehicle.Model}: {_vehicle?.AxisX.ToString()} {_vehicle?.AxisY.ToString()} " +
            $"{_vehicle?.Direction}");
            WriteLine(ResultCoordinates);
        });
    }
}