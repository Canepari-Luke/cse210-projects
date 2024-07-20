using Raylib_cs;
using System.Collections.Generic;
using Game.Casting;

namespace Game.Services
{
    public class VideoService
    {
        private string title;
        private int width;
        private int height;
        private int frameRate;

        public VideoService(string title, int width, int height, int frameRate)
        {
            this.title = title;
            this.width = width;
            this.height = height;
            this.frameRate = frameRate;
        }

        public void OpenWindow()
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(frameRate);
        }

        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
        }

        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                actor.Draw();
            }
        }

        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}
