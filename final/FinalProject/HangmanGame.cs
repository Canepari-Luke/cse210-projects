using System;

public class HangmanGame : Game
{
    public HangmanGame(GameManager manager, string playerName) : base(manager, playerName)
    {
    }

    public override void Start()
    {
        // Simplified game logic for Hangman
        Console.Clear();
        Console.WriteLine("Playing Hangman...");
        // Implement game logic here

        // Simulate a score for demo purposes
        Random random = new Random();
        int score = random.Next(0, 100);
        Console.WriteLine($"Game over! Your score: {score}");

        gameManager.AddScore("Hangman", playerName, score);
    }
}
