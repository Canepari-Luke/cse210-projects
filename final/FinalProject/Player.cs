using System;
using System.Collections.Generic;

public class Player
{
    public string Username { get; set; }
    public string Initials { get; set; }
    public Dictionary<string, int> GameScores { get; set; }

    public Player(string username, string initials)
    {
        Username = username;
        Initials = initials;
        GameScores = new Dictionary<string, int>();
    }

    public void UpdateScore(string gameName, int score)
    {
        if (GameScores.ContainsKey(gameName))
        {
            if (score > GameScores[gameName])
            {
                GameScores[gameName] = score;
            }
        }
        else
        {
            GameScores[gameName] = score;
        }
    }

    public int GetTotalScore()
    {
        int totalScore = 0;
        foreach (var score in GameScores.Values)
        {
            totalScore += score;
        }
        return totalScore;
    }
}
