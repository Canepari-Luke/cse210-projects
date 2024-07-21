using System.Collections.Generic;
using System.IO;
using Arcade;  // Ensure this namespace is correct for accessing the Player class

public class PlayerDataStore
{
    private const string FilePath = "playerdata.csv";

    public List<Player> Players { get; set; }

    public void SavePlayers()
    {
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            foreach (var player in Players)
            {
                writer.WriteLine($"{player.Username},{player.Initials},{player.GetTotalScore()}");
            }
        }
    }

    public List<Player> LoadPlayers()
    {
        List<Player> loadedPlayers = new List<Player>();

        if (File.Exists(FilePath))
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string username = parts[0];
                        string initials = parts[1];
                        int score = int.Parse(parts[2]);

                        Player player = new Player(username, initials);
                        player.UpdateScore("Unknown", score);
                        loadedPlayers.Add(player);
                    }
                }
            }
        }
        return loadedPlayers;
    }
}
