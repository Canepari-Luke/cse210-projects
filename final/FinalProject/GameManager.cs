using System;
using System.Collections.Generic;

public class GameManager
{
    private ScoreTally scoreTally;
    private Leaderboard leaderboard;

    public GameManager()
    {
        scoreTally = new ScoreTally();
        leaderboard = new Leaderboard();
    }

    public void AddScore(string gameName, string playerName, int score)
    {
        scoreTally.AddScore(gameName, score);
        leaderboard.AddScore(gameName, playerName, score);
    }

    public int GetTotalScore()
    {
        return scoreTally.GetTotalScore();
    }

    public List<KeyValuePair<string, int>> GetLeaderboard(string gameName)
    {
        return leaderboard.GetLeaderboard(gameName);
    }
}
