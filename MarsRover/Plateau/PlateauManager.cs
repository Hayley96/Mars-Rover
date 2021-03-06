public class PlateauManager
{
    public PlateauShapes? Plateau { get; private set; } = default;
    public ColorGrid[,]? Grid { get; private set; }
    public IEnumerable<Type>? Subclasses { get; private set; }
    public static int SizeX { get; private set; }
    public static int SizeY { get; private set; }
    private string platShape = string.Empty;
    private List<PlateauShapes> Plateaus = new();

    public void PreparePlateau(int plateauSizeX, int plateauSizeY, string plateauShape)
    {
        platShape = plateauShape;
        SizeX = plateauSizeX;
        SizeY = plateauSizeY;
        Grid = SetUpGrid.SetUp(SizeX, SizeY);
        SetPlateau(platShape);
        Plateau?.Draw(SizeX, SizeY, Grid);
    }

    public void GetSubclasses()
    {
        Subclasses = GetUserInputInstances.GetSubclasses(typeof(PlateauShapes));
    }

    private void SetPlateau(string plateauShape)
    {
        object[] PlateauParamArr = { SizeX, SizeY, };
        Plateau = (PlateauShapes)GetUserInputInstances.Get(plateauShape, typeof(PlateauShapes), PlateauParamArr);
        Plateaus = AddItemToList.Add(Plateaus, Plateau);
    }
}