public class Food
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Food(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write('X');
    }

    public void Relocate(int maxX, int maxY)
    {
        var random = new Random();
        X = random.Next(0, maxX);
        Y = random.Next(0, maxY);
    }
}
