using System.Diagnostics.CodeAnalysis;
using System.Reflection;

public class VehicleManager
{
    public static Vehicles? Vehicle { get; private set; }
    public readonly List<Vehicles> Vehicles = new List<Vehicles>();
    private static int VehicleAxisX;
    private static int VehicleAxisY;
    private static string Direction = string.Empty;
    private static string VehicleType = string.Empty;
    private IEnumerable<Type>? subClasses;

    private static string vehicleType = "Rover";

    private Dictionary<string, Action> VehicleTypeActionKeyValuePair = new Dictionary<string, Action>()
    { { vehicleType, () => Vehicle = new Rover(VehicleAxisX, VehicleAxisY, Direction, VehicleType)} };

}