using System.Collections.Generic;

public class Snake
{
    public List<(int x, int y)> Body { get; private set; }
    public (int x, int y) Direction { get; private set; }

    public Snake(int startX, int startY)
    {
        Body = new List<(int x, int y)> { (startX, startY) };
        Direction = (0, -1); // Start moving up
    }

    public void ChangeDirection((int x, int y) newDirection)
    {
        Direction = newDirection;
    }

    public void Move()
    {
        var head = Body[0];
        var newHead = (head.x + Direction.x, head.y + Direction.y);
        Body.Insert(0, newHead);
    }

    public void Grow()
    {
        // Do nothing, the tail will not be removed, so the snake will grow
    }

    public void RemoveTail()
    {
        Body.RemoveAt(Body.Count - 1);
    }

    public bool CheckCollision((int x, int y) position)
    {
        return Body.Contains(position);
    }

    public bool CheckSelfCollision()
    {
        var head = Body[0];
        for (int i = 1; i < Body.Count; i++)
        {
            if (Body[i] == head)
                return true;
        }
        return false;
    }
}
