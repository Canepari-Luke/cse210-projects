namespace Arcade
{
    public class Player
    {
        public string Username { get; private set; }
        public string Initials { get; private set; }
        private Dictionary<string, int> gameScores;

        public Player(string username, string initials)
        {
            Username = username;
            Initials = initials;
            gameScores = new Dictionary<string, int>();
        }

        public void UpdateScore(string gameName, int score)
        {
            if (gameScores.ContainsKey(gameName))
            {
                if (score > gameScores[gameName])
                {
                    gameScores[gameName] = score;
                }
            }
            else
            {
                gameScores[gameName] = score;
            }
        }

        public int GetTotalScore()
        {
            int totalScore = 0;
            foreach (var score in gameScores.Values)
            {
                totalScore += score;
            }
            return totalScore;
        }

        public int GetScoreForGame(string gameName)
        {
            if (gameScores.ContainsKey(gameName))
            {
                return gameScores[gameName];
            }
            return 0;
        }
    }
}
