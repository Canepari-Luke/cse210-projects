using System;
using System.Threading;

public class HangmanGame : Game
{
    public HangmanGame(GameManager manager, string player) : base(manager, player) { }

    public override void Start()
    {
        Console.Clear();
        Console.WriteLine("Starting Hangman...");

        // Implement Hangman game logic here
        Console.WriteLine("Press any key to simulate playing Hangman.");
        Console.ReadKey();

        // Example score addition
        gameManager.AddScore("Hangman", playerName, new Random().Next(1, 100));

        Console.WriteLine("Hangman game finished. Score saved.");
        Thread.Sleep(1000);
    }
}