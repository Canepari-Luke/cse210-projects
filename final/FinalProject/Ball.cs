using System;
using Raylib_cs;

public class Ball
{
    private int x;
    private int y;
    private int radius;
    private int speed;

    public Ball(int startX, int startY, int ballRadius, int ballSpeed)
    {
        x = startX;
        y = startY;
        radius = ballRadius;
        speed = ballSpeed;
    }

    public void Draw()
    {
        Raylib.DrawCircle(x, y, radius, Color.RED);
    }

    public void Move()
    {
        X += SpeedX;
        Y += SpeedY;

        if (Y <= 0 || Y >= Console.WindowHeight - 1)
            SpeedY = -SpeedY;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write('O');
    }

    public void Reset(int x, int y, int speedX, int speedY)
    {
        X = x;
        Y = y;
        SpeedX = speedX;
        SpeedY = speedY;
    }
}
