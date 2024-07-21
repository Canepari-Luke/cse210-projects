namespace Arcade
{
    public class PongGame : Game
    {
        private Paddle playerPaddle;
        private Paddle aiPaddle;
        private Ball ball;

        public PongGame(GameManager manager, string player) : base(manager, player)
        {
            playerPaddle = new Paddle(1, Console.WindowHeight / 2, 4);
            aiPaddle = new Paddle(Console.WindowWidth - 2, Console.WindowHeight / 2, 4);
            ball = new Ball(Console.WindowWidth / 2, Console.WindowHeight / 2, 1, 1);
        }

        public override void Start()
        {
            Console.Clear();
            bool playing = true;
            while (playing)
            {
                Console.Clear();
                playerPaddle.Draw();
                aiPaddle.Draw();
                ball.Draw();
                ball.Move();

                // Handle player input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow)
                        playerPaddle.MoveUp();
                    else if (key == ConsoleKey.DownArrow)
                        playerPaddle.MoveDown();
                }

                // Simple AI for the opponent paddle
                if (ball.Y > aiPaddle.Y)
                    aiPaddle.MoveDown();
                else if (ball.Y < aiPaddle.Y)
                    aiPaddle.MoveUp();

                // Check for ball collision with paddles
                if ((ball.X == playerPaddle.X + 1 && ball.Y >= playerPaddle.Y && ball.Y <= playerPaddle.Y + playerPaddle.Length) ||
                    (ball.X == aiPaddle.X - 1 && ball.Y >= aiPaddle.Y && ball.Y <= aiPaddle.Y + aiPaddle.Length))
                {
                    ball.SpeedX = -ball.SpeedX;
                }

                // Check for ball going out of bounds
                if (ball.X <= 0 || ball.X >= Console.WindowWidth - 1)
                {
                    ball.Reset(Console.WindowWidth / 2, Console.WindowHeight / 2, 1, 1);
                }

                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
