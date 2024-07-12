using Game.Casting;
using Game.Services;

public class Ball : Actor
{
    private int dx;
    private int dy;

    public Ball(int x, int y, int radius, int dx, int dy, Color color)
    {
        SetPosition(new Point(x, y));
        SetRadius(radius);
        this.dx = dx;
        this.dy = dy;
        SetColor(color);
    }

    public void Move()
    {
        Point position = GetPosition();
        SetPosition(new Point(position.GetX() + dx, position.GetY() + dy));
    }
}
