namespace Snake;

public class GameLogic
{
    public bool[,] PlayingField { get; private set; }

    public GameLogic(int height, int width)
    {
        PlayingField = GenerateRandomPlayingField(height, width);
    }
    private static bool[,] GenerateRandomPlayingField(int height, int width)
    {
        // TODO: Insert new Playing Field Generation Logic
        
        //var playingField = new bool[height, width];
        //var rand = new Random(42);
        //for (var row = 0; row < height; row++)
        //{
        //    for (var column = 0; column < width; column++)
        //    {
        //        playingField[row, column] = rand.Next(100 + 1) < aliveCellsPrecent;
        //    }
        //}
        //
        //return playingField;
    }
    public void AdvanceGeneration()
    {
        bool[,] updatedCells = new bool[PlayingField.GetLength(0), PlayingField.GetLength(1)];
        for (var row = 0; row < PlayingField.GetLength(0); row++)
        {
            for (var column = 0; column < PlayingField.GetLength(1); column++)
            {
                updatedCells[row, column] = ApplyRules(GetNeighborCount(row, column), PlayingField[row, column]);
            }
        }

        PlayingField = updatedCells;
    }
}