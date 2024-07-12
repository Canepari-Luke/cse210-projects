using System;
using Raylib_cs;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize the GameManager
        GameManager gameManager = new GameManager();

        // Initialize the Raylib GUI and pass the GameManager to it
        RaylibGUI raylibGUI = new RaylibGUI(gameManager);

        // Run the application
        raylibGUI.Run();
    }
}
