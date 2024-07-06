public abstract class Game
{
    protected GameManager gameManager;
    protected string playerName;

    public Game(GameManager manager, string player)
    {
        gameManager = manager;
        playerName = player;
    }

    public abstract void Start();
}
