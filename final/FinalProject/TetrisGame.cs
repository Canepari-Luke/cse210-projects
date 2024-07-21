using System;
using System.Threading;

namespace Arcade
{
    public class TetrisGame : Game
    {
        public TetrisGame(GameManager manager, string player) : base(manager, player) { }

        public override void Start()
        {
            Console.Clear();
            Console.WriteLine("Starting Tetris...");

            // Implement Tetris game logic here
            Console.WriteLine("Press any key to simulate playing Tetris.");
            Console.ReadKey();

            // Example score addition
            gameManager.AddScore("Tetris", playerName, new Random().Next(1, 100));

            Console.WriteLine("Tetris game finished. Score saved.");
            Thread.Sleep(1000);
        }
    }
}
