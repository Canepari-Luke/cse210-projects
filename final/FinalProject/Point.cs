namespace FinalProject
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX() => x;
        public int GetY() => y;

        public Point Scale(int factor) => new Point(x * factor, y * factor);
        public Point Add(Point other) => new Point(x + other.GetX(), y + other.GetY());
    }
}
