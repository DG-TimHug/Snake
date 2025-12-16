namespace Snake;

public class GameLogic(int height, int width)
{
    private Direction Direction { get; set; } = Direction.Right;
    public (int horizontal, int vertical) SnakeHead { get; private set; } = (10, 5);
    public List<(int horizontal, int vertical)> SnakeBody { get; private set; } = new();
    

    public (int horizontal, int vertical) Apple { get; private set; }

    private readonly Random random = new();
    private bool ateApple;

    private bool alive = true;

    public readonly Board Board = new();

    public void SetDirection(Direction dir)
    {
        if (dir.Horizontal == -Direction.Horizontal && dir.Horizontal != 0) return;
        if (dir.Vertical == -Direction.Vertical && dir.Vertical != 0) return;

        Direction = dir;
    }

    public void Update()
    {
        Board.PlayingFieldGenerator(height, width, SnakeBody, SnakeHead, Apple);
        var oldHead = SnakeHead;

        SnakeHead = (
            SnakeHead.horizontal + Direction.Horizontal,
            SnakeHead.vertical + Direction.Vertical
        );

        SnakeBody.Insert(0, oldHead);

        if (SnakeHead == Apple)
        {
            ateApple = true;
            PlaceApple();
        }

        if (!ateApple)
        {
            SnakeBody.RemoveAt(SnakeBody.Count - 1);
        }

        ateApple = false;

        SnakeHead = (
            Math.Clamp(SnakeHead.horizontal, 0, Console.BufferWidth - 1),
            Math.Clamp(SnakeHead.vertical, 0, Console.BufferHeight - 1)
        );

        if (SnakeBody.Contains(SnakeHead))
        {
            alive = false;
        }

        Board.PlayingFieldUpdater(SnakeHead.vertical, SnakeHead.horizontal, Apple.vertical, Apple.horizontal,
            Board.PlayingField, SnakeBody);
    }

    public void PlaceApple()
    {
        Apple = (
            random.Next(0, Console.BufferWidth - 1),
            random.Next(0, Console.BufferHeight - 1)
        );
    }

    public bool Alive()
    {
        if (!alive)
        {
            Thread.Sleep(100);
            Console.Write("Game Over!");
        }
        return alive;
    }

    internal void CollisionCheck()
    {
        //TODO: Gebastel work in progress
        // - differentiate between Gamelogic and Board
        // - Gamelogic is in charge, Game Logic gives data to Board, Board DOES NOT FETCH data.
        // - Further splitting up of classes Files and methods. Figure out what to do with border and rendering etc.  
    }
}