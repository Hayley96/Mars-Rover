public static class DisplayResult
{
    public static void DisplayResultString(Vehicles vehicle)
    {
        string ResultCoordinates = ($"New co-ordinates for vehicle {vehicle.Model}: {vehicle?.AxisX.ToString()} {vehicle?.AxisY.ToString()} " +
            $"{vehicle?.Direction}");
        Console.WriteLine(ResultCoordinates);
    }
}