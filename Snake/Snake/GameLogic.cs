namespace Snake;

public class GameLogic
{
    public Direction Direction { get; set; } = new Direction(1, 0);
    public (int horizontal, int vertical) Snakehead { get; set; } = (10, 5);
    public (int horizontal, int vertical) Apple { get; set; }
    
    public bool AteApple { get; set; }
    public List<(int horizontal, int vertical)> Snakebody { get; set; } = new();
    public readonly Random Random = new();

    public void SetDirection(Direction direction)
    {
        Direction = direction;
    }
    
    public void Update()
    {
        Snakebody.Insert(0, Snakehead);
        Snakehead = (
            Snakehead.horizontal + Direction.Horizontal,
            Snakehead.vertical + Direction.Vertical
        );

        if (Snakehead == Apple)
        {
            AteApple = true;
            PlaceApple();
        }

        if (!AteApple && Snakebody.Count > 0)
            Snakebody.RemoveAt(Snakebody.Count - 1);

        AteApple = false;

        Snakehead = (
            Math.Clamp(Snakehead.horizontal, 0, Console.BufferWidth  - 1),
            Math.Clamp(Snakehead.vertical,   0, Console.BufferHeight - 1)
        );
    }
    
    public void PlaceApple()
    {
        Apple = (
            Random.Next(0, Console.BufferWidth - 1),
            Random.Next(0, Console.BufferHeight - 1)
        );

    }
}