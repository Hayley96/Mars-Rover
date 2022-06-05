using static System.Console;
public static class UserContinueOrEndOption
{
    public static void Continue()
    {
        Write("Press 'C' to continue....or any other key to exit: ");
        var option = ReadLine();
        if (!string.IsNullOrEmpty(option) && !option.Equals("C"))
            Environment.Exit(0);            
    }

    public static void End()
    {
        Write("Cannot proceed without correct Plateau size...You will have to begin again...press any to exit: ");
        var option = ReadKey();       
        if (!string.IsNullOrEmpty(option.ToString()) && !option.Equals(ConsoleKey.Enter))
            Environment.Exit(0);
    }
}