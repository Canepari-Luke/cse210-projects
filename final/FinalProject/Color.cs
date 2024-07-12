using System;
namespace Game.Casting
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;

        public Color(int red, int green, int blue, int alpha = 255)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        public int GetRed() => red;
        public int GetGreen() => green;
        public int GetBlue() => blue;
        public int GetAlpha() => alpha;
    }
}
