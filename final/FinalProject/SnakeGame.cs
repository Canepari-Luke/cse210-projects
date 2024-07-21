using System;
using System.Collections.Generic;
using System.Threading;

namespace Arcade
{
    public class SnakeGame : Game
    {
        private List<(int x, int y)> snakeBody;
        private Food food;
        private int boardWidth = 80;
        private int boardHeight = 20;

        public SnakeGame(GameManager manager, string player) : base(manager, player)
        {
            snakeBody = new List<(int x, int y)> { (10, 10) };
            food = new Food(boardWidth, boardHeight, snakeBody);
        }

        public override void Start()
        {
            Console.Clear();
            Console.WriteLine("Starting Snake...");

            // Implement Snake game logic here
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                DrawBoard();
                DrawSnake();
                DrawFood();
                Thread.Sleep(500);
            }

            // Example score addition
            gameManager.AddScore("Snake", playerName, new Random().Next(1, 100));

            Console.WriteLine("Snake game finished. Score saved.");
            Thread.Sleep(1000);
        }

        private void DrawBoard()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < boardWidth; i++)
                Console.Write('#');
            for (int i = 1; i < boardHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('#');
                Console.SetCursorPosition(boardWidth - 1, i);
                Console.Write('#');
            }
            Console.SetCursorPosition(0, boardHeight - 1);
            for (int i = 0; i < boardWidth; i++)
                Console.Write('#');
        }

        private void DrawSnake()
        {
            foreach (var segment in snakeBody)
            {
                Console.SetCursorPosition(segment.x, segment.y);
                Console.Write('O');
            }
        }

        private void DrawFood()
        {
            Console.SetCursorPosition(food.Position.x, food.Position.y);
            Console.Write('*');
        }
    }
}
