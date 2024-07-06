using System;
using System.Collections.Generic;
using System.IO;

public class PlayerDataStore
{
    private const string DataFilePath = "schoolstuff/programmingwithclasses/cse210/final/FinalProject/players.csv"; // Path to your CSV file
    private const string CsvDelimiter = ","; // CSV delimiter

    public List<Player> Players { get; private set; }

    public PlayerDataStore()
    {
        Players = LoadPlayers();
    }

    public void SavePlayers()
    {
        using (StreamWriter writer = new StreamWriter(DataFilePath))
        {
            foreach (var player in Players)
            {
                string line = $"{player.Username}{CsvDelimiter}{player.Initials}";
                foreach (var score in player.GameScores)
                {
                    line += $"{CsvDelimiter}{score.Key}{CsvDelimiter}{score.Value}";
                }
                writer.WriteLine(line);
            }
        }
    }

    private List<Player> LoadPlayers()
    {
        List<Player> players = new List<Player>();
        if (File.Exists(DataFilePath))
        {
            using (StreamReader reader = new StreamReader(DataFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(CsvDelimiter);
                    string username = parts[0];
                    string initials = parts[1];

                    Player player = new Player(username, initials);

                    // Load scores if available
                    for (int i = 2; i < parts.Length; i += 2)
                    {
                        string gameName = parts[i];
                        int score = int.Parse(parts[i + 1]);
                        player.UpdateScore(gameName, score);
                    }

                    players.Add(player);
                }
            }
        }
        return players;
    }
}
