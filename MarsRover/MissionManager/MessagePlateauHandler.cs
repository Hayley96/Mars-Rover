using System.Text.RegularExpressions;

public static class MessagePlateauHandler
{
    private static int PlateauSizeXTemp = 0, PlateauSizeYTemp = 0;
    public static void ReceivePlateauSizeMessage(string message, out int PlateauSizeX, out int PlateauSizeY)
    {
        Regex regex = new(@"^[0-9]*\s[0-9*]$");
        if (ValidationInputs.CheckArgs(message, regex))
        {
            PlateauSizeXTemp = SplitStrings.SplitIntDataIndex0(message);
            PlateauSizeYTemp = SplitStrings.SplitIntDataIndex1(message);
        }
        PlateauSizeX = PlateauSizeXTemp;
        PlateauSizeY = PlateauSizeYTemp;
    }

    public static void GetPlateau(PlateauManager plateauManager, out PlateauShapes Plateau, int PlateauSizeX, int PlateauSizeY, string plateauShape)
    {
        plateauManager.PreparePlateau(PlateauSizeX, PlateauSizeY, plateauShape);
        Plateau = plateauManager!.Plateau!;
    }
}