public static class MenuUIValidation
{
    public static bool CheckUserUIInput(string message)
    {
        try
        {
            if (!string.IsNullOrEmpty(message) && message.Equals("CM") || message.Equals("M") ||
                message.Equals("D") || message.Equals("E"))
            {
                return true;               
            }
            throw new ArgumentException($"ERROR: The option value: '{message}' is invalid");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}