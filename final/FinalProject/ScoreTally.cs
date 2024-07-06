using System.Collections.Generic;

public class ScoreTally
{
    private Dictionary<string, int> gameScores;
    private int totalScore;

    public ScoreTally()
    {
        gameScores = new Dictionary<string, int>();
        totalScore = 0;
    }

    public void AddScore(string gameName, int score)
    {
        if (gameScores.ContainsKey(gameName))
        {
            gameScores[gameName] += score;
        }
        else
        {
            gameScores[gameName] = score;
        }
        totalScore += score;
    }

    public int GetGameScore(string gameName)
    {
        return gameScores.ContainsKey(gameName) ? gameScores[gameName] : 0;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
