using static System.Console;
public class Rectangle : PlateauShapes
{
    public Rectangle(int _sizeX, int _sizeY) : base(_sizeX, _sizeY) {}

    public override void Draw(int sizeX, int sizeY, ColorGrid[,] Grid)
    {
        if (!IsOutputRedirected)
            Clear();
        for (int i = sizeY - 1; i >= 0; i--)
        {
            Write("\n");
            for (int j = 0; j < sizeX; j++)
            {
                ColorGrid.PrintColor(Grid[i, j]);
            }
            Write("\n");
        }
        Write("\n\n");
        this.Grid = Grid;
    }
}