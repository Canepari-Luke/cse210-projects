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
            Y--;
    }

    public void MoveDown()
    {
        if (Y + Length < Console.WindowHeight)
            Y++;
    }

    public void Draw()
    {
        for (int i = 0; i < Length; i++)
        {
            Console.SetCursorPosition(X, Y + i);
            Console.Write('|');
        }
    }
}