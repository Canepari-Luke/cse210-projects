using System;

public class PongGame : Game
{
    public PongGame(GameManager manager, string playerName) : base(manager, playerName)
    {
    }

    public override void Start()
    {
        // Simplified game logic for Pong
        Console.Clear();
        Console.WriteLine("Playing Pong...");
        // Implement game logic here

        // Simulate a score for demo purposes
        Random random = new Random();
        int score = random.Next(0, 100);
        Console.WriteLine($"Game over! Your score: {score}");

        gameManager.AddScore("Pong", playerName, score);
    }
}
