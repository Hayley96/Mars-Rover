using static System.Console;

public class SubMenu
{
    private MissionManager missionmanager;
    private int selectedIndex;
    private List<string> menuOptions;
    private string prompt;

    public SubMenu(string _prompt, List<string> _options, MissionManager _missionManager)
    {
        prompt = _prompt;
        menuOptions = _options;
        selectedIndex = 0;
        missionmanager = _missionManager;
    }

    private void DisplayOptions()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(prompt);
        WriteLine();
        for (int i = 0; i < menuOptions.Count; i++)
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
                    selectedIndex = menuOptions.Count - 1;
            }
            else if (keyPressed.Equals(ConsoleKey.DownArrow))
            {
                selectedIndex++;
                if (selectedIndex.Equals(menuOptions.Count))
                    selectedIndex = 0;
            }
            Clear();
            missionmanager.ReDrawPlateau();
            missionmanager.DisplayResults();

        } while (!keyPressed.Equals(ConsoleKey.Enter));
        return selectedIndex;
    }
}