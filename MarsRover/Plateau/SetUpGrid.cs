public static class SetUpGrid
{
    public static ColorGrid[,]? Grid { get; private set; }
    public static ColorGrid[,] SetUp(int sizeX, int sizeY)
    {
        Grid = new ColorGrid[sizeY, sizeX];
        for (int i = 0; i < sizeY; i++)
            for (int j = 0; j < sizeX; j++)
                Grid[i, j] = new ColorGrid(ConsoleColor.Cyan, "   ");
        return Grid;
    }
}