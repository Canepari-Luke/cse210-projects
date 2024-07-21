using System;
using System.Threading;

namespace Arcade
{
    public class PongGame : Game
    {
        private Ball ball;
        private Paddle leftPaddle;
        private Paddle rightPaddle;

        public PongGame(GameManager manager, string player) : base(manager, player)
        {
            ball = new Ball(40, 12, 1, 1);
            leftPaddle = new Paddle(2, 10, 5);
            rightPaddle = new Paddle(77, 10, 5);
        }

        public override void Start()
        {
            Console.Clear();
            Console.WriteLine("Starting Pong...");

            // Implement Pong game logic here
            for (int i = 0; i < 10; i++)
            {
                ball.Move();
                leftPaddle.Draw();
                rightPaddle.Draw();
                ball.Draw();
                Thread.Sleep(100);
            }

            // Example score addition
            gameManager.AddScore("Pong", playerName, new Random().Next(1, 100));

            Console.WriteLine("Pong game finished. Score saved.");
            Thread.Sleep(1000);
        }
    }
}
