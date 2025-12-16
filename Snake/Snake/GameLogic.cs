namespace Snake;

public class GameLogic(int height, int width)
{
    private Direction Direction { get; set; } = Direction.Right;
    public (int horizontal, int vertical) SnakeHead { get; private set; } = (10, 5);
    public List<(int horizontal, int vertical)> SnakeBody { get; private set; } = new();
    public (int horizontal, int vertical)? RemovedTail { get; private set; }

    
    public (int horizontal, int vertical) Apple { get; private set; }

    private readonly Random random = new();
    private bool ateApple;

    private bool alive = true;

    public readonly Board Board = new();
    
    //TODO:
    //- Rendering works but Apple often spawns in Wall which causes glitches,
    //- Fix Borders and Death mechanism
    //- :)

    public void SetDirection(Direction dir)
    {
        if (dir.Horizontal == -Direction.Horizontal && dir.Horizontal != 0) return;
        if (dir.Vertical == -Direction.Vertical && dir.Vertical != 0) return;

        Direction = dir;
    }

    public void Update()
    {
        var oldHead = SnakeHead;

        SnakeHead = (
            SnakeHead.horizontal + Direction.Horizontal,
            SnakeHead.vertical + Direction.Vertical
        );
        if (SnakeHead.horizontal <= 0 || SnakeHead.horizontal >= width - 1 || SnakeHead.vertical <= 0 || SnakeHead.vertical >= height - 1)
        {
            alive = false;
            return;
        }
        
        SnakeBody.Insert(0, oldHead);

        if (SnakeHead == Apple)
        {
            ateApple = true;
            PlaceApple();
        }

        if (!ateApple && SnakeBody.Count > 0)
        {
            RemovedTail = SnakeBody[^1];
            SnakeBody.RemoveAt(SnakeBody.Count - 1);
        }
        else
        {
            RemovedTail = null;
        }
        
        ateApple = false;
        
        if (SnakeBody.Contains(SnakeHead))
        {
            alive = false;
        }

        Board.PlayingFieldGenerator(height, width, SnakeBody, SnakeHead, Apple);
    }

    public void PlaceApple()
    {
        (int horizontal, int vertical) newApple;
        do
        {
            newApple = (
                random.Next(1, width - 1),
                random.Next(1, height - 1)
            );
        } while (
            newApple == SnakeHead ||
            SnakeBody.Contains(newApple)
        );

        Apple = newApple;
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
}