namespace Snake;

public class Board
{
    public bool[,] PlayingField { get; private set; } = null!;

    public void PlayingFieldGenerator(int height, int width, List<(int horizontal, int vertical)> snake,
        (int horizontal, int vertical) snakeHead, (int horizontal, int vertical) apple)
    {
        var playingField = new bool[height, width];

        BorderMaker(height, width, playingField);

        PlayingField = PlayingFieldUpdater(snakeHead.vertical, snakeHead.horizontal, apple.vertical, apple.horizontal, playingField, snake);
    }

    private static bool[,] PlayingFieldUpdater(int snakeHeadVertical, int snakeHeadHorizontal, int appleVertical, int appleHorizontal, bool[,] playingField, List<(int horizontal, int vertical)> snake)
    {
        foreach (var part in snake)
        {
            playingField[part.vertical, part.horizontal] = true;
        }

        playingField[snakeHeadVertical, snakeHeadHorizontal] = true;
        playingField[appleVertical, appleHorizontal] = true;

        return playingField;
    }

    private void BorderMaker(int height, int width, bool[,] playingField)
    {
        for (var row = 0; row < height; row++)
        {
            for (var column = 0; column < width; column++)
            {
                if (row == 0 || row == height - 1 || column == 0 || column == width - 1)
                {
                    playingField[row, column] = true;
                }
            }
        }
    }
}