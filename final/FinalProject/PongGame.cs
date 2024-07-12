using System;
using Raylib_cs;
using Keyboardservice;

public class PongGame : Game
{
    private Paddle playerPaddle;
    private Paddle aiPaddle;
    private Ball ball;

    public PongGame(GameManager manager, string player) : base(manager, player)
    {
        playerPaddle = new Paddle(1, 300 / 2, 4);
        aiPaddle = new Paddle(800 - 2, 300 / 2, 4);
        ball = new Ball(800 / 2, 300 / 2, 4, 4);
    }

    public override void Start()
    {
        bool playing = true;
        while (playing && !Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            playerPaddle.Draw();
            aiPaddle.Draw();
            ball.Draw();
            ball.Move();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                playerPaddle.MoveUp();
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                playerPaddle.MoveDown();

            if (ball.Y > aiPaddle.Y)
                aiPaddle.MoveDown();
            else if (ball.Y < aiPaddle.Y)
                aiPaddle.MoveUp();

            if ((ball.X == playerPaddle.X + 1 && ball.Y >= playerPaddle.Y && ball.Y <= playerPaddle.Y + playerPaddle.Length) ||
                (ball.X == aiPaddle.X - 1 && ball.Y >= aiPaddle.Y && ball.Y <= aiPaddle.Y + aiPaddle.Length))
            {
                ball.SpeedX = -ball.SpeedX;
            }

            if (ball.X <= 0 || ball.X >= 800)
            {
                playing = false;
            }

            Raylib.EndDrawing();
        }
    }
}

public class Ball
{
    public int X { get; set; }
    public int Y { get; set; }
    public int SpeedX { get; set; }
    public int SpeedY { get; set; }

    public Ball(int x, int y, int speedX, int speedY)
    {
        X = x;
        Y = y;
        SpeedX = speedX;
        SpeedY = speedY;
    }

    public void Move()
    {
        X += SpeedX;
        Y += SpeedY;
    }

    public void Draw()
    {
        Raylib.DrawRectangle(X, Y, 4, 4, Color.WHITE);
    }

    public void Reset(int x, int y, int speedX, int speedY)
    {
        X = x;
        Y = y;
        SpeedX = speedX;
        SpeedY = speedY;
    }
}

public class Paddle
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Length { get; set; }

    public Paddle(int x, int y, int length)
    {
        X = x;
        Y = y;
        Length = length;
    }

    public void MoveUp()
    {
        if (Y > 0)
            Y -= 4;
    }

    public void MoveDown()
    {
        if (Y < 600 - Length)
            Y += 4;
    }

    public void Draw()
    {
        Raylib.DrawRectangle(X, Y, 4, Length, Color.WHITE);
    }
}
