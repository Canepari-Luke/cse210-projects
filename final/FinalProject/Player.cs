using System.Collections.Generic;

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
                gameScores[gameName] = score;
            else
                gameScores.Add(gameName, score);
        }

        public int GetTotalScore()
        {
            return gameScores.Values.Sum();
        }
    }
}
