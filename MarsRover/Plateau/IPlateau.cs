public interface IPlateau
{
    int PlateauSizeX { get; set; }
    int PlateauSizeY { get; set; }

    public void Draw(int x, int y, ColorGrid[,] Grid);
}