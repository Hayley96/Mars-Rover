public class ColorGrid
{
    public ConsoleColor Color { get; set; }
    public string Content { get; set; }

    public ColorGrid(ConsoleColor cColor, string content)
    {
        Color = cColor;
        Content = content;
    }
    public static void PrintColor(ColorGrid obj)
    {
        var prevColor = Console.BackgroundColor;
        var prevForeColor = Console.ForegroundColor;
        Console.BackgroundColor = obj.Color;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(obj.Content);
        Console.BackgroundColor = prevColor;
        Console.ForegroundColor = prevForeColor;
        Console.Write(" ");
    }
}

