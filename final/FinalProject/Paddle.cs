using System;
using Raylib_cs;


public class Paddle
{
    private int x;
    private int y;
    private int height;

    public Paddle(int startX, int startY, int paddleHeight)
    {
        x = startX;
        y = startY;
        height = paddleHeight;
    }

    public void Draw()
    {
        Raylib.DrawRectangle(x, y, 10, height, Color.BLUE);
    }

    public void Move(int direction)
    {
        y += direction * 5; // Adjust speed as needed
    }
}
