using System.Collections.Generic;
using Raylib_cs;
using Game.Casting;

namespace Game.Services
{
    public class VideoService
    {
        private int width;
        private int height;
        private string title;
        private int frameRate;

        public VideoService(string title, int width, int height, int frameRate)
        {
            this.width = width;
            this.height = height;
            this.title = title;
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

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
        }

        public void DrawActor(Actor actor)
        {
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            Color color = actor.GetColor();
            Raylib.DrawRectangle(x, y, actor.GetWidth(), actor.GetHeight(), ToRaylibColor(color));
        }

        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        private Raylib_cs.Color ToRaylibColor(Color color)
        {
            return new Raylib_cs.Color(color.GetRed(), color.GetGreen(), color.GetBlue(), color.GetAlpha());
        }
    }
}
