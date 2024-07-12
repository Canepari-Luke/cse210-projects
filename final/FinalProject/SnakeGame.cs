using System;
using System.Collections.Generic;
using System.Threading;

public class SnakeGame : Game
{
    private const int BoardWidth = 30;
    private const int BoardHeight = 20;
    private Snake snake;
    private Food food;
    private int score;

    public SnakeGame(GameManager manager, string player) : base(manager, player)
    {
        snake = new Snake(BoardWidth / 2, BoardHeight / 2);
        food = new Food(BoardWidth, BoardHeight, snake.Body);
        score = 0;
    }

    public override void Start()
    {
        Console.Clear();
        while (true)
        {
            DrawBoard();
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                ChangeDirection(key);
            }
            if (!MoveSnake())
            {
                break; // Game over
            }
            Thread.Sleep(100);
        }

        Console.Clear();
        Console.WriteLine($"Game over. Your score: {score}");
        gameManager.AddScore("Snake", playerName, score);
        Console.WriteLine("Press any key to return to the game selection menu.");
        Console.ReadKey();
    }

    private void DrawBoard()
    {
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < BoardHeight; y++)
        {
            for (int x = 0; x < BoardWidth; x++)
            {
                if (x == 0 || x == BoardWidth - 1 || y == 0 || y == BoardHeight - 1)
                {
                    Console.Write("#");
                }
                else if (snake.Body.Contains((x, y)))
                {
                    Console.Write("O");
                }
                else if (food.Position == (x, y))
                {
                    Console.Write("X");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Score: {score}");
    }

    private void ChangeDirection(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (snake.Direction != (0, 1)) snake.ChangeDirection((0, -1));
                break;
            case ConsoleKey.DownArrow:
                if (snake.Direction != (0, -1)) snake.ChangeDirection((0, 1));
                break;
            case ConsoleKey.LeftArrow:
                if (snake.Direction != (1, 0)) snake.ChangeDirection((-1, 0));
                break;
            case ConsoleKey.RightArrow:
                if (snake.Direction != (-1, 0)) snake.ChangeDirection((1, 0));
                break;
        }
    }

    private bool MoveSnake()
    {
        snake.Move();

        var head = snake.Body[0];

        if (head.x <= 0 || head.x >= BoardWidth - 1 || head.y <= 0 || head.y >= BoardHeight - 1 || snake.CheckSelfCollision())
        {
            return false; // Hit a wall or itself
        }

        if (head == food.Position)
        {
            score += 10;
            food.GenerateNewFood(BoardWidth, BoardHeight, snake.Body);
        }
        else
        {
            snake.RemoveTail();
        }

        return true;
    }
}
