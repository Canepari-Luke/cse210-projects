using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize the GameManager
        GameManager gameManager = new GameManager();

        // Initialize the GUI and pass the GameManager to it
        GameGUI gameGUI = new GameGUI(gameManager);

        // Run the application
        gameGUI.Run();
    }
}
