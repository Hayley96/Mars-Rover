using static System.Console;
public static class UpdateVehicleOnGrid
{
    public static void Update(Vehicles vehicle, PlateauShapes plateau)
    {
        UpdateGridIconArrow(vehicle);
        UpdateVehiclePlateauLocation(vehicle, plateau);
    }

    private static void UpdateGridIconArrow(Vehicles vehicle)
    {
        _ = vehicle.Direction.ToString() switch
        {
            "N" => vehicle!.GridIcon!.Content = " ^ ",
            "E" => vehicle!.GridIcon!.Content = " > ",
            "W" => vehicle!.GridIcon!.Content = " < ",
            "S" => vehicle!.GridIcon!.Content = " v ",
            _ => throw new ArgumentException("Value not found in Directions"),
        };
    }

    private static void UpdateVehiclePlateauLocation(Vehicles vehicle, PlateauShapes plateau)
    {
        try
        {
            for (int i = 0; i < plateau?.PlateauSizeY; i++)
                for (int j = 0; j < plateau?.PlateauSizeX; j++)
                    if (plateau?.Grid?[i, j].Color == vehicle?.GridIcon?.Color)
                    {
                        plateau!.Grid![i, j].Color = ConsoleColor.Cyan;
                        plateau.Grid[i, j].Content = "   ";
                    }
            plateau!.Grid![vehicle!.AxisY, vehicle.AxisX].Color = vehicle!.GridIcon!.Color;
            plateau.Grid[vehicle.AxisY, vehicle.AxisX].Content = vehicle.GridIcon.Content;
        }
        catch(Exception ex)
        {
            WriteLine(ex.Message);
            //UserContinueOrEndOption.Continue();
        }
    }
}