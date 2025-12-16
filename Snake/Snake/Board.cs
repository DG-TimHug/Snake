namespace Snake;

public class Board
{
    public bool[,] PlayingField { get; private set; }
    
   public bool[,] PlayingFieldGenerator(int height, int width, List<(int horizontal, int vertical)> snake)
   {
       var playingField = new bool[height, width];

       PlayingField = playingField;
       return PlayingField;
   }
   //TODO: Gebastel work in progress
   // - differentiate between Gamelogic and Board
   // - Gamelogic is in charge, Game Logic gives data to Board, Board DOES NOT FETCH data.
   // - Further splitting up of classes Files and methods. Figure out what to do with border and rendering etc.  
   public bool[,] PlayingFieldUpdater(bool[,] playingField, List<(int horizontal, int vertical)> snake)
   {
       foreach (var part in snake)
       {
           playingField[part.vertical, part.horizontal] = true;
       }
       playingField[Game.SnakeHead.vertical, Game.SnakeHead.horizontal] = true;

       playingField[Game.Apple.vertical, Game.Apple.horizontal] = true;

       PlayingField = playingField;
       return playingField;
   }
}