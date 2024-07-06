using System;

public class SnakeGame : Game
{
    public SnakeGame(GameManager manager, string playerName) : base(manager, playerName)
    {
    }

    public override void Start()
    {
        // Simplified game logic for Snake
        Console.Clear();
        Console.WriteLine("Playing Snake...");
        // Implement game logic here

        // Simulate a score for demo purposes
        Random random = new Random();
        int score = random.Next(0, 100);
        Console.WriteLine($"Game over! Your score: {score}");

        gameManager.AddScore("Snake", playerName, score);
    }
}
