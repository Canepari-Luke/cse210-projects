using System;
using System.Collections.Generic;
using System.Linq;

public class GameManager
{
    private PlayerDataStore playerDataStore;
    public Player CurrentPlayer { get; private set; }

    public GameManager()
    {
        playerDataStore = new PlayerDataStore();
    }

    public void CreateNewPlayer(string username, string initials)
    {
        Player player = new Player(username, initials);
        playerDataStore.Players.Add(player);
        CurrentPlayer = player;
    }

    public void LoadPlayer(string initials)
    {
        CurrentPlayer = playerDataStore.Players.FirstOrDefault(p => p.Initials == initials);
    }

    public List<Player> GetPlayers()
    {
        return playerDataStore.Players;
    }

    public void SaveCurrentPlayer()
    {
        playerDataStore.SavePlayers();
    }

    public int GetTotalScore()
    {
        return CurrentPlayer.GetTotalScore();
    }

    public void AddScore(string gameName, string playerName, int score)
    {
        var player = playerDataStore.Players.FirstOrDefault(p => p.Username == playerName);
        if (player != null)
        {
            player.UpdateScore(gameName, score);
        }
    }
}