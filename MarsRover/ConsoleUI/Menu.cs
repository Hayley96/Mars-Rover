using static System.Console;
public class Menu
{
    private int selectedIndex;
    private string[] menuOptions;
    private string prompt;

    public Menu(string _prompt, string[] _options)
    {
        prompt = _prompt;
        menuOptions = _options;
        selectedIndex = 0;
    }

    private void DisplayOptions()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(prompt);
        WriteLine();
        for (int i = 0; i < menuOptions.Length; i++)
        {
            string option = menuOptions[i];
            string prefix;

            if (i.Equals(selectedIndex))
            {
                prefix = "*";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                prefix = " ";
                ForegroundColor = ConsoleColor.Red;
                BackgroundColor = ConsoleColor.Black;
            }
            WriteLine($" {prefix} << {option} >>");

        }
        ResetColor();
    }

    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            DisplayOptions();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed.Equals(ConsoleKey.UpArrow))
            {
                selectedIndex--;
                if (selectedIndex.Equals(-1))
                    selectedIndex = menuOptions.Length - 1;
            }
            else if (keyPressed.Equals(ConsoleKey.DownArrow))
            {
                selectedIndex++;
                if (selectedIndex.Equals(menuOptions.Length))
                    selectedIndex = 0;
            }
            Clear();

        } while (!keyPressed.Equals(ConsoleKey.Enter));
        return selectedIndex;
    }
}