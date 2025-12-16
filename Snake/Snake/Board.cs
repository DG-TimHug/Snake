namespace Snake;

public class Board
{
    private readonly GameLogic game = new();
    
   private bool[,] PlayingFieldGenerator(int height, int width, List<(int horizontal, int vertical)> Snake)
   {
       var playingField = new bool[height, width];
       
       foreach (var part in Snake)
       {
           playingField[part.vertical, part.horizontal] = true;
       }
       playingField[game.SnakeHead.vertical, game.SnakeHead.horizontal] = true;

       playingField[game.Apple.vertical, game.Apple.horizontal] = true;
       
       return playingField;
   }
    
}