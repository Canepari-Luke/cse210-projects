namespace Arcade
{
    public class GameManager
    {
        private List<Player> players;

        public GameManager()
        {
            players = new List<Player>();
        }

        public void AddScore(string gameName, string playerName, int score)
        {
            var player = players.FirstOrDefault(p => p.Username == playerName);
            if (player == null)
            {
                player = new Player(playerName, playerName.Substring(0, 2).ToUpper());
                players.Add(player);
            }
            player.UpdateScore(gameName, score);
        }

        // Other GameManager methods...
    }
}
