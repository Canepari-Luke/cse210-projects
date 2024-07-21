using System.Collections.Generic;

public class Snake
{
    public LinkedList<(int X, int Y)> Body { get; private set; }
    public (int X, int Y) Direction { get; set; }

    public Snake(int startX, int startY)
    {
        Body = new LinkedList<(int X, int Y)>();
        Body.AddFirst((startX, startY));
        Direction = (1, 0);
    }

    public void Move()
    {
        var newHead = (X: Body.First.Value.X + Direction.X, Y: Body.First.Value.Y + Direction.Y);
        Body.AddFirst(newHead);
        Body.RemoveLast();
    }

    public void Grow()
    {
        var tail = Body.Last.Value;
        Body.AddLast(tail);
    }

    public void Draw()
    {
        foreach (var segment in Body)
        {
            Console.SetCursorPosition(segment.X, segment.Y);
            Console.Write('O');
        }
    }

    public bool HasCollidedWithSelf()
    {
        var head = Body.First.Value;
        foreach (var segment in Body.Skip(1))
        {
            if (segment.X == head.X && segment.Y == head.Y)
                return true;
        }
        return false;
    }
}
