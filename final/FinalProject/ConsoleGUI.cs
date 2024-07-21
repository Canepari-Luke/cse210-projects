using System;

public class ConsoleGUI
{
    private GameManager gameManager;

    public ConsoleGUI(GameManager manager)
    {
        gameManager = manager;
    }

    public void Run()
    {
        ShowInitialMenu();
    }

    private void ShowInitialMenu()
    {
        Console.Clear();
        Console.WriteLine("Arcade - Initial Menu");
        Console.WriteLine("1. New Player");
        Console.WriteLine("2. Load Player");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                NewPlayer();
                break;
            case "2":
                LoadPlayer();
                break;
            default:
                Console.WriteLine("Invalid choice. Press any key to try again.");
                Console.ReadKey();
                ShowInitialMenu();
                break;
        }
    }

    private void NewPlayer()
    {
        Console.Clear();
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter initials (3 characters): ");
        string initials = Console.ReadLine();

        if (!string.IsNullOrEmpty(username) && initials.Length == 3)
        {
            gameManager.CreateNewPlayer(username, initials);
            ShowGameSelectionMenu();
        }
        else
        {
            Console.WriteLine("Invalid input. Press any key to try again.");
            Console.ReadKey();
            NewPlayer();
        }
    }

    private void LoadPlayer()
    {
        Console.Clear();
        Console.WriteLine("Select Player:");
        var players = gameManager.GetPlayers();
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {players[i].Initials} - {players[i].Username}");
        }
        Console.Write("Select an option: ");
        string choice = Console.ReadLine();

        if (int.TryParse(choice, out int playerIndex) && playerIndex > 0 && playerIndex <= players.Count)
        {
            gameManager.LoadPlayer(players[playerIndex - 1].Initials);
            ShowGameSelectionMenu();
        }
        else
        {
            Console.WriteLine("Invalid choice. Press any key to try again.");
            Console.ReadKey();
            LoadPlayer();
        }
    }

    private void ShowGameSelectionMenu()
    {
        Console.Clear();
        Console.WriteLine($"Player: {gameManager.CurrentPlayer.Username} ({gameManager.CurrentPlayer.Initials})");
        Console.WriteLine($"Total Score: {gameManager.GetTotalScore()}");
        Console.WriteLine("1. Pong");
        Console.WriteLine("2. Snake");
        Console.WriteLine("5. Save and Quit");
        Console.Write("Select a game to play: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                StartGame(new PongGame(gameManager, gameManager.CurrentPlayer.Initials));
                break;
            case "2":
                StartGame(new SnakeGame(gameManager, gameManager.CurrentPlayer.Initials));
                break;
            case "5":
                SaveAndQuit();
                break;
            default:
                Console.WriteLine("Invalid choice. Press any key to try again.");
                Console.ReadKey();
                ShowGameSelectionMenu();
                break;
        }
    }

    private void StartGame(Game game)
    {
        game.Start();
        Console.WriteLine("Game over. Press any key to return to the game selection menu.");
        Console.ReadKey();
        ShowGameSelectionMenu();
    }

    private void SaveAndQuit()
    {
        gameManager.SaveCurrentPlayer();
        Console.WriteLine("Game saved. Press any key to exit.");
        Console.ReadKey();
    }
}
