using System;
using System.Collections.Generic;
using System.IO;

public class PlayerDataStore
{
    private string DataFilePath = "players.csv"; // Ensure this path is correct

    public List<Player> Players { get; private set; }

    public PlayerDataStore()
    {
        Players = LoadPlayers();
    }

    public void SavePlayers()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(DataFilePath))
            {
                foreach (var player in Players)
                {
                    string line = $"{player.Username},{player.Initials}";
                    foreach (var score in player.GameScores)
                    {
                        line += $",{score.Key},{score.Value}";
                    }
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine("Players saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving players: {ex.Message}");
        }
    }

    private List<Player> LoadPlayers()
    {
        List<Player> players = new List<Player>();
        if (File.Exists(DataFilePath))
        {
            try
            {
                using (StreamReader reader = new StreamReader(DataFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
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
                Console.WriteLine("Players loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading players: {ex.Message}");
            }
        }
        return players;
    }
}
