public class PongGame : Game
{
    private GameManager gameManager;
    private string playerName;

    public PongGame(GameManager manager, string player)
    {
        gameManager = manager;
        playerName = player;
    }

    public override void Start()
    {
        // Initialize Pong game
    }

    public override void Update()
    {
        // Game logic for Pong
        // Example: If player scores
        int score = 10; // Example score
        gameManager.AddScore("Pong", playerName, score);
    }

    public override void End()
    {
        // Clean up Pong game
    }
}
