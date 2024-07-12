using System.Collections.Generic;
using Game.Casting;
using Game.Services;

public class Game
{
    private KeyboardService keyboardService;
    private VideoService videoService;
    private List<Actor> actors;

    public Game()
    {
        keyboardService = new KeyboardService(1);
        videoService = new VideoService("Pong Game", 800, 600, 60);
        actors = new List<Actor>();

        // Initialize paddles and ball
        Paddle leftPaddle = new Paddle(50, 300, 100, new Color(0, 0, 255));
        Paddle rightPaddle = new Paddle(750, 300, 100, new Color(0, 0, 255));
        Ball ball = new Ball(400, 300, 10, 2, 2, new Color(255, 0, 0));

        actors.Add(leftPaddle);
        actors.Add(rightPaddle);
        actors.Add(ball);
    }

    public void Start()
    {
        videoService.OpenWindow();

        while (!Raylib_cs.Raylib.WindowShouldClose())
        {
            // Input
            Point direction = keyboardService.GetDirection();

            // Update
            foreach (Actor actor in actors)
            {
                if (actor is Paddle paddle)
                {
                    paddle.Move(direction.GetY());
                }
                else if (actor is Ball ball)
                {
                    ball.Move();
                }
            }

            // Output
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

        videoService.CloseWindow();
    }
}
