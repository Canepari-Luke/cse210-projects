using System.Collections.Generic;
using System.Linq;

public class Leaderboard
{
    private Dictionary<string, List<KeyValuePair<string, int>>> leaderboards;

    public Leaderboard()
    {
        leaderboards = new Dictionary<string, List<KeyValuePair<string, int>>>();
    }

    public void AddScore(string gameName, string playerName, int score)
    {
        if (!leaderboards.ContainsKey(gameName))
        {
            leaderboards[gameName] = new List<KeyValuePair<string, int>>();
        }
        leaderboards[gameName].Add(new KeyValuePair<string, int>(playerName, score));
        leaderboards[gameName] = leaderboards[gameName]
            .OrderByDescending(pair => pair.Value)
            .Take(10) // Keep top 10 scores
            .ToList();
    }

    public List<KeyValuePair<string, int>> GetLeaderboard(string gameName)
    {
        return leaderboards.ContainsKey(gameName) ? leaderboards[gameName] : new List<KeyValuePair<string, int>>();
    }
}
