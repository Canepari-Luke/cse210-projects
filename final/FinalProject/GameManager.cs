using System;
using System.Collections.Generic;
using System.Linq;

public class GameManager
{
    private List<Player> players;
    public Player CurrentPlayer { get; private set; }

    public GameManager()
    {
        players = new List<Player>();
        LoadPlayers();
    }

    public void CreateNewPlayer(string username, string initials)
    {
        Player player = new Player(username, initials);
        players.Add(player);
        CurrentPlayer = player;
    }

    public void LoadPlayer(string initials)
    {
        CurrentPlayer = players.FirstOrDefault(p => p.Initials == initials);
    }

    public List<Player> GetPlayers()
    {
        return players;
    }

    public void SaveCurrentPlayer()
    {
        SavePlayers();
    }

    public int GetTotalScore()
    {
        return CurrentPlayer.GetTotalScore();
    }

    private void LoadPlayers()
    {
        // Placeholder for loading players from storage
    }

    private void SavePlayers()
    {
        // Placeholder for saving players to storage
    }

    public void AddScore(string gameName, string playerName, int score)
    {
        var player = players.FirstOrDefault(p => p.Username == playerName);
        if (player != null)
        {
            player.UpdateScore(gameName, score);
        }
    }
}
