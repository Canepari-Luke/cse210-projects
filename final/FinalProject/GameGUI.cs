using System;
using System.Windows.Forms;

public class GameGUI
{
    private GameManager gameManager;

    public GameGUI(GameManager manager)
    {
        gameManager = manager;
    }

    public void Run()
    {
        // Initialize and run the GUI application
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm(gameManager));
    }
}
