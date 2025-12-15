namespace Snake;

public class Board
{
    private GameLogic game = new GameLogic();
    
    //TODO: Aktives Gebastel WIP in Playingfield
     
   private bool[,] GeneratePlayingField(int height, int width, List<(int horizontal, int vertical)> Snake)
   {
       int[] = Array.Empty<int>()
       var playingField = new bool[height, width];
       for (var row = 0; row < height; row++)
       {
           for (var column = 0; column < width; column++)
           {
               playingField[row, column] = Snake.Contains()
           }
       }
       
       return playingField;
   }
    
}