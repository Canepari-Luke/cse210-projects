using Game.Casting;
using Game.Services;

public class Paddle : Actor
{
    public Paddle(int x, int y, int height, Color color)
    {
        SetPosition(new Point(x, y));
        SetHeight(height);
        SetColor(color);
    }

    public void Move(int dy)
    {
        Point position = GetPosition();
        SetPosition(new Point(position.GetX(), position.GetY() + dy));
    }
}
