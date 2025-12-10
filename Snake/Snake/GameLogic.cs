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
}