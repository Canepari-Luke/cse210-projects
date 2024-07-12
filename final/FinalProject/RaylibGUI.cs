using System;
using Raylib_cs;

public class RaylibGUI
{
    private GameManager gameManager;

    public RaylibGUI(GameManager manager)
    {
        gameManager = manager;
        Raylib.InitWindow(800, 600, "Arcade");
        Raylib.SetTargetFPS(60);
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            ShowInitialMenu();
        }
        Raylib.CloseWindow();
    }

    private void ShowInitialMenu()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RAYWHITE);
        Raylib.DrawText("Arcade - Initial Menu", 10, 10, 20, Color.BLACK);
        Raylib.DrawText("1. New Player", 10, 40, 20, Color.BLACK);
        Raylib.DrawText("2. Load Player", 10, 70, 20, Color.BLACK);
        Raylib.DrawText("Select an option: ", 10, 100, 20, Color.BLACK);
        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE))
        {
            NewPlayer();
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO))
        {
            LoadPlayer();
        }
    }

    private void NewPlayer()
    {
        string username = "", initials = "";

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawText("Enter username: ", 10, 10, 20, Color.BLACK);
            Raylib.DrawText(username, 10, 40, 20, Color.BLACK);
            Raylib.EndDrawing();

            int key = Raylib.GetKeyPressed();
            if (key >= 32 && key <= 126)
            {
                username += (char)key;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && !string.IsNullOrEmpty(username))
            {
                break;
            }
        }

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawText("Enter initials (3 characters): ", 10, 10, 20, Color.BLACK);
            Raylib.DrawText(initials, 10, 40, 20, Color.BLACK);
            Raylib.EndDrawing();

            int key = Raylib.GetKeyPressed();
            if (key >= 32 && key <= 126)
            {
                initials += (char)key;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && initials.Length == 3)
            {
                break;
            }
        }

        gameManager.CreateNewPlayer(username, initials);
        ShowGameSelectionMenu();
    }

    private void LoadPlayer()
    {
        while (!Raylib.WindowShouldClose())
        {
            var players = gameManager.GetPlayers();
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawText("Select Player:", 10, 10, 20, Color.BLACK);

            for (int i = 0; i < players.Count; i++)
            {
                Raylib.DrawText($"{i + 1}. {players[i].Initials} - {players[i].Username}", 10, 40 + i * 30, 20, Color.BLACK);
            }

            Raylib.EndDrawing();

            for (int i = 0; i < players.Count; i++)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE + i))
                {
                    gameManager.LoadPlayer(players[i].Initials);
                    ShowGameSelectionMenu();
                    return;
                }
            }
        }
    }

    private void ShowGameSelectionMenu()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawText($"Player: {gameManager.CurrentPlayer.Username} ({gameManager.CurrentPlayer.Initials})", 10, 10, 20, Color.BLACK);
            Raylib.DrawText($"Total Score: {gameManager.GetTotalScore()}", 10, 40, 20, Color.BLACK);
            Raylib.DrawText("1. Pong", 10, 70, 20, Color.BLACK);
            Raylib.DrawText("2. Snake", 10, 100, 20, Color.BLACK);
            Raylib.DrawText("3. Hangman", 10, 130, 20, Color.BLACK);
            Raylib.DrawText("4. Tetris", 10, 160, 20, Color.BLACK);
            Raylib.DrawText("5. Save and Quit", 10, 190, 20, Color.BLACK);
            Raylib.DrawText("Select a game to play: ", 10, 220, 20, Color.BLACK);
            Raylib.EndDrawing();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE))
            {
                StartGame(new PongGame(gameManager, gameManager.CurrentPlayer.Initials));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO))
            {
                StartGame(new SnakeGame(gameManager, gameManager.CurrentPlayer.Initials));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE))
            {
                StartGame(new HangmanGame(gameManager, gameManager.CurrentPlayer.Initials));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR))
            {
                StartGame(new TetrisGame(gameManager, gameManager.CurrentPlayer.Initials));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_FIVE))
            {
                SaveAndQuit();
                return;
            }
        }
    }

    private void StartGame(Game game)
    {
        game.Start();
    }

    private void SaveAndQuit()
    {
        gameManager.SaveCurrentPlayer();
        Raylib.CloseWindow();
    }
}
