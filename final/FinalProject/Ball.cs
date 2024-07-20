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