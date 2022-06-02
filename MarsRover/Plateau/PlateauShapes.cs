public abstract class PlateauShapes : IPlateau
{
    public int PlateauSizeX { get; set; }
    public int PlateauSizeY { get; set; }

    public PlateauShapes(int sizeX, int sizeY)
    {
        PlateauSizeX = sizeX;
        PlateauSizeY = sizeY;
    }

    public abstract void Draw(int x, int y, ColorGrid[,] grid);

}