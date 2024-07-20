using Raylib_cs;

namespace Game.Services
{
    public class KeyboardService
    {
        public Point GetDirection(string paddle)
        {
            int dx = 0;
            int dy = 0;

            if (paddle == "left")
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    dy = -1;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    dy = 1;
                }
            }
            else if (paddle == "right")
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    dy = -1;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    dy = 1;
                }
            }

            return new Point(dx, dy);
        }
    }
}
