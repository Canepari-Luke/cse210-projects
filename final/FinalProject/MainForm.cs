using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private GameManager gameManager;

    public MainForm(GameManager manager)
    {
        gameManager = manager;
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Initialize the main form components
        this.Text = "Arcade";
        this.Width = 800;
        this.Height = 600;

        // Add buttons for different games (e.g., Pong, Snake, etc.)
        Button pongButton = new Button { Text = "Pong", Left = 50, Top = 50, Width = 100 };
        pongButton.Click += (sender, args) => StartGame(new PongGame(gameManager, "Player1"));
        this.Controls.Add(pongButton);

        // Add more buttons for other games similarly...
    }

    private void StartGame(Game game)
    {
        game.Start();
        // Additional logic to integrate game into the GUI
    }
}
