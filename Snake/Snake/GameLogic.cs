namespace Snake;

public class GameLogic
{
    public Direction Direction { get; set; } = new Direction(1, 0);
    public (int horizontal, int vertical) Snakehead { get; set; } = (10, 5);
    public (int horizontal, int vertical) Apple { get; set; }
    public bool AteApple { get; set; }
    public List<(int horizontal, int vertical)> Snakebody { get; set; } = new();
    public Random Random = new();

    public void SetDirection(Direction direction)
    {
        Direction = direction;
    }
    
    public void Update()
    {
        Snakebody.Insert(0, Snakehead); 
        Snakehead = (Snakehead.horizontal + Direction.Horizontal,
            Snakehead.vertical + Direction.Vertical);
        
        if (Snakebody.Count > 0 && !AteApple)
            Snakebody.RemoveAt(Snakebody.Count - 1);


        AteApple = false;

        if (Snakehead == Apple)
        {
            AteApple = true;
            PlaceApple();
        }
    }
    
    public void PlaceApple()
    {
        Apple = (Random.Next(1, 40), Random.Next(1, 20));
    }

}