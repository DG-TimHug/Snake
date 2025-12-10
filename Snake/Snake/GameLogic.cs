namespace Snake;

public class GameLogic
{
    public Direction Direction { get; private set; } = Direction.Right;
    public (int horizontal, int vertical) Snakehead { get; private set; } = (10, 5);
    public List<(int horizontal, int vertical)> Snakebody { get; private set; } = new();

    public (int horizontal, int vertical) Apple { get; private set; }

    private readonly Random random = new();
    private bool ateApple;

    public void SetDirection(Direction dir)
    {
        if (dir.Horizontal == -Direction.Horizontal && dir.Horizontal != 0) return;
        if (dir.Vertical == -Direction.Vertical && dir.Vertical != 0) return;

        Direction = dir;
    }

    public void Update()
    {
        var oldHead = Snakehead;

        Snakehead = (
            Snakehead.horizontal + Direction.Horizontal,
            Snakehead.vertical + Direction.Vertical
        );

        Snakebody.Insert(0, oldHead);

        if (Snakehead == Apple)
        {
            ateApple = true;
            PlaceApple();
        }

        if (!ateApple)
        {
            Snakebody.RemoveAt(Snakebody.Count - 1);
        }

        ateApple = false;

        Snakehead = (
            Math.Clamp(Snakehead.horizontal, 0, Console.BufferWidth - 1),
            Math.Clamp(Snakehead.vertical, 0, Console.BufferHeight - 1)
        );
    }

    public void PlaceApple()
    {
        Apple = (
            random.Next(0, Console.BufferWidth - 1),
            random.Next(0, Console.BufferHeight - 1)
        );
    }
}