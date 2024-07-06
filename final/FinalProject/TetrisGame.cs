using System;

public class TetrisGame : Game
{
    public TetrisGame(GameManager manager, string playerName) : base(manager, playerName)
    {
    }

    public override void Start()
    {
        // Simplified game logic for Tetris
        Console.Clear();
        Console.WriteLine("Playing Tetris...");
        // Implement game logic here

        // Simulate a score for demo purposes
        Random random = new Random();
        int score = random.Next(0, 100);
        Console.WriteLine($"Game over! Your score: {score}");

        gameManager.AddScore("Tetris", playerName, score);
    }
}
