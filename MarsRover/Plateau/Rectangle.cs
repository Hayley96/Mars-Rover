public class Rectangle : PlateauShapes
{
    public ColorGrid[,]? Grid { get; private set; }
    public Rectangle(int _sizeX, int _sizeY) : base(_sizeX, _sizeY) {}

    public override void Draw(int sizeX, int sizeY, ColorGrid[,] Grid)
    {
        Console.Clear();
        for (int i = sizeY - 1; i >= 0; i--)
        {
            Console.Write("\n");
            for (int j = 0; j < sizeX; j++)
            {
                ColorGrid.PrintColor(Grid[i, j]);
            }
            Console.Write("\n");
        }
        Console.Write("\n\n");
    }
}