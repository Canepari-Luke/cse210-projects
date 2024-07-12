using System;
using Raylib_cs;


public class SnakeGame : Game
{
    private Snake snake;
    private Food food;

    public SnakeGame(GameManager manager, string player) : base(manager, player)
    {
        snake = new Snake(20, 20);
        food = new Food();
    }

    public override void Start()
    {
        bool playing = true;
        while (playing && !Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            snake.Move();
            snake.Draw();
            food.Draw();

            if (snake.CheckCollision(food))
            {
                snake.Eat(food);
                food = new Food();
            }

            if (snake.CheckSelfCollision() || snake.CheckWallCollision())
            {
                playing = false;
            }

            Raylib.EndDrawing();
        }
    }
}

public class Snake
{
    private const int GridSize = 20;
    private const int InitialLength = 3;

    private List<Vector2> body;
    private Vector2 direction;

    public Snake(int startX, int startY)
    {
        body = new List<Vector2>();
        direction = new Vector2(1, 0); // Start moving right initially

        for (int i = 0; i < InitialLength; i++)
        {
            body.Add(new Vector2(startX - i, startY));
        }
    }

    public void Move()
    {
        Vector2 nextPosition = body[0] + direction;

        // Move body
        for (int i = body.Count - 1; i > 0; i--)
        {
            body[i] = body[i - 1];
        }
        body[0] = nextPosition;
    }

    public void Draw()
    {
        foreach (var segment in body)
        {
            Raylib.DrawRectangle((int)segment.X * GridSize, (int)segment.Y * GridSize, GridSize, GridSize, Color.GREEN);
        }
    }

    public void Eat(Food food)
    {
        body.Add(body[body.Count - 1]); // Grow the snake
    }

    public bool CheckCollision(Food food)
    {
        return body[0].X == food.Position.X && body[0].Y == food.Position.Y;
    }

    public bool CheckSelfCollision()
    {
        for (int i = 1; i < body.Count; i++)
        {
            if (body[0].X == body[i].X && body[0].Y == body[i].Y)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckWallCollision()
    {
        return body[0].X < 0 || body[0].X >= Raylib.GetScreenWidth() / GridSize ||
               body[0].Y < 0 || body[0].Y >= Raylib.GetScreenHeight() / GridSize;
    }
}

public class Food
{
    public Vector2 Position { get; private set; }

    public Food()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Position = new Vector2(RandomNumber(0, Raylib.GetScreenWidth() / 20 - 1), RandomNumber(0, Raylib.GetScreenHeight() / 20 - 1));
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)Position.X * 20, (int)Position.Y * 20, 20, 20, Color.RED);
    }

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max + 1);
    }
}
