using static System.Console;
public static class ConsoleUIUtilities
{
    public static string GetInputFromUser(string prompt)
    {
        Write(prompt);
        string result = ReadLine() ?? "";
        return result;
    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = CursorTop;
        SetCursorPosition(0, CursorTop);
        Write(new string(' ', BufferWidth));
        SetCursorPosition(0, currentLineCursor);
    }

    public static void ResetCursorPosition()
    {
        SetCursorPosition(0, CursorTop - 1);
    }

    public static string DisplayUserOptions()
    {
        string userOptions = GetInputFromUser(@"What would you like to do?: CM/M/D/E 
[CM: move vehicle - new coordinates and move commands] [M: move vehicle without new coordinates] 
[D: deploy new vehicle] [E: exit]: ");
        return userOptions;
    }
}