public class SnakeGame : Game
{
    private Snake snake;
    private Food food;

    public SnakeGame(GameManager manager, string player) : base(manager, player)
    {
        snake = new Snake(Console.WindowWidth / 2, Console.WindowHeight / 2);
        food = new Food(Console.WindowWidth / 3, Console.WindowHeight / 3);
    }

    public override void Start()
    {
        Console.Clear();
        bool playing = true;
        while (playing)
        {
            Console.Clear();
            snake.Draw();
            food.Draw();

            // Handle player input
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Direction = (0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Direction = (0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Direction = (-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Direction = (1, 0);
                        break;
                }
            }

            snake.Move();

            // Check if the snake has eaten the food
            if (snake.Body.First.Value.X == food.X && snake.Body.First.Value.Y == food.Y)
            {
                snake.Grow();
                food.Relocate(Console.WindowWidth, Console.WindowHeight);
            }

            // Check if the snake has collided with itself
            if (snake.HasCollidedWithSelf())
            {
                playing = false;
            }

            System.Threading.Thread.Sleep(100);
        }

        Console.WriteLine("Game over. Press any key to return to the game selection menu.");
        Console.ReadKey();
    }
}
