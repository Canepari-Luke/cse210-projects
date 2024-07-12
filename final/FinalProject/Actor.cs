using Game.Casting;

public class Actor
{
    private Point position;
    private Color color;
    private int width;
    private int height;
    private int radius;

    public Point GetPosition() => position;
    public void SetPosition(Point position) => this.position = position;

    public Color GetColor() => color;
    public void SetColor(Color color) => this.color = color;

    public int GetWidth() => width;
    public void SetWidth(int width) => this.width = width;

    public int GetHeight() => height;
    public void SetHeight(int height) => this.height = height;

    public int GetRadius() => radius;
    public void SetRadius(int radius) => this.radius = radius;
}
