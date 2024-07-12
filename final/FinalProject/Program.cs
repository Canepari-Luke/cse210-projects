using System;
using System.Collections.Generic;
using Raylib_cs;
using Game.Casting;
using Game.Services;

namespace PongGame
{
    class Program
    {
        private static int FRAME_RATE = 60;
        private static int MAX_X = 800;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 10;
        private static string CAPTION = "Pong Game";
        private static Color WHITE = new Color(255, 255, 255);

        static void Main(string[] args)
        {
            // Create the actors
            List<Actor> actors = new List<Actor>();

            // Create the left paddle
            Paddle leftPaddle = new Paddle(50, MAX_Y / 2 - 50, 100, new Color(0, 0, 255));
            actors.Add(leftPaddle);

            // Create the right paddle
            Paddle rightPaddle = new Paddle(MAX_X - 60, MAX_Y / 2 - 50, 100, new Color(0, 0, 255));
            actors.Add(rightPaddle);

            // Create the ball
            Ball ball = new Ball(MAX_X / 2, MAX_Y / 2, 10, 2, 2, new Color(255, 0, 0));
            actors.Add(ball);

            // Initialize services
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService = new VideoService(CAPTION, MAX_X, MAX_Y, FRAME_RATE);

            // Main game loop
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                // Get input
                Point direction = keyboardService.GetDirection();

                // Update actors
                foreach (Actor actor in actors)
                {
                    if (actor is Paddle paddle)
                    {
                        paddle.Move(direction.GetY());
                    }
                    else if (actor is Ball)
                    {
                        ball.Move();
                    }
                }

                // Render actors
                videoService.ClearBuffer();
                videoService.DrawActors(actors);
                videoService.FlushBuffer();
            }
            videoService.CloseWindow();
        }
    }
}
