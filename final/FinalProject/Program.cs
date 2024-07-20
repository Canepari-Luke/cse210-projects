using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize the GameManager
        GameManager gameManager = new GameManager();

        // Initialize the Console GUI and pass the GameManager to it
        ConsoleGUI consoleGUI = new ConsoleGUI(gameManager);

        // Run the application
        consoleGUI.Run();
    }
}