using Raylib_cs;

public class HangmanGame : Game
{
    private string word;
    private List<char> guessedLetters;
    private int attemptsLeft;

    public HangmanGame(GameManager manager, string player) : base(manager, player)
    {
        word = "hangman"; // Replace with your word selection logic
        guessedLetters = new List<char>();
        attemptsLeft = 6;
    }

    public override void Start()
    {
        bool playing = true;
        while (playing && !Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            DrawHangman();
            DrawWord();
            DrawGuessedLetters();
            CheckGameStatus();

            Raylib.EndDrawing();
        }
    }

    private void DrawHangman()
    {
        // Draw hangman parts based on attempts left
        // Example: Draw head, body, arms, legs, etc.
    }

    private void DrawWord()
    {
        // Draw the word with underscores for unguessed letters
        // Example: "h _ _ _ m a n"
    }

    private void DrawGuessedLetters()
    {
        // Draw the list of guessed letters
    }

    private void CheckGameStatus()
    {
        // Check if the game is won or lost
    }
}
