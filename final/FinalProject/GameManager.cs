using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcade
{
    public class GameManager
    {
        private List<Player> players;
        public Player CurrentPlayer { get; private set; }

        public GameManager()
        {
            players = new List<Player>();
        }

        public void CreateNewPlayer(string username, string initials)
        {
            CurrentPlayer = new Player(username, initials);
            players.Add(CurrentPlayer);
        }

        public void LoadPlayer(string initials)
        {
            CurrentPlayer = players.FirstOrDefault(p => p.Initials == initials);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public int GetTotalScore()
        {
            return CurrentPlayer.GetTotalScore();
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

        public void SaveCurrentPlayer()
        {
            // Save the current player's data
            PlayerDataStore dataStore = new PlayerDataStore();
            dataStore.Players = players;
            dataStore.SavePlayers();
        }
    }
}
