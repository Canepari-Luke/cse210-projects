using System;

public class Food
{
    public (int x, int y) Position { get; private set; }

    public Food(int boardWidth, int boardHeight, List<(int x, int y)> snakeBody)
    {
        GenerateNewFood(boardWidth, boardHeight, snakeBody);
    }

    public void GenerateNewFood(int boardWidth, int boardHeight, List<(int x, int y)> snakeBody)
    {
        Random random = new Random();
        int x, y;
        do
        {
            x = random.Next(1, boardWidth - 1);
            y = random.Next(1, boardHeight - 1);
        } while (snakeBody.Contains((x, y)));

        Position = (x, y);
    }
}
