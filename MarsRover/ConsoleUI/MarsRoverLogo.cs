using static System.Console;
public struct MarsRoverLogo
{
    public static string DrawTitle()
    {
        Title = "Mars Rover";
        string prompt = @"
.___  ___.      ___      .______          _______.   .______        ______   ____    ____  _______ .______      
|   \/   |     /   \     |   _  \        /       |   |   _  \      /  __  \  \   \  /   / |   ____||   _  \     
|  \  /  |    /  ^  \    |  |_)  |      |   (----`   |  |_)  |    |  |  |  |  \   \/   /  |  |__   |  |_)  |    
|  |\/|  |   /  /_\  \   |      /        \   \       |      /     |  |  |  |   \      /   |   __|  |      /     
|  |  |  |  /  _____  \  |  |\  \----.----)   |      |  |\  \----.|  `--'  |    \    /    |  |____ |  |\  \----.
|__|  |__| /__/     \__\ | _| `._____|_______/       | _| `._____| \______/      \__/     |_______|| _| `._____|

Welcome to the Mars Rover Program. Feel free to explore?
(Use the arrow keys to cycle through the menu and press enter to select an option)";

        return prompt;
    }
}