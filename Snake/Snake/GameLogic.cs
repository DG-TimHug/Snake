namespace Snake;

public class GameLogic(int height, int width)
{
    private Direction Direction { get; set; } = Direction.Right;
    
    public (int horizontal, int vertical) Apple { get; private set; }
    private bool ateApple;
    
    private readonly Random random = new();
    private bool alive = true;
    public readonly Board Board = new();
    public Snake Snake = new();
    
    //TODO:
    //- Rendering works but Apple often spawns in Wall which causes glitches, => happens because Console Windows doesnt auto adjust
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
        var oldHead = Snake.SnakeHead;

        Snake.SnakeHead = (
            Snake.SnakeHead.horizontal + Direction.Horizontal,
            Snake.SnakeHead.vertical + Direction.Vertical
        );
        
        if (Snake.SnakeHead.horizontal <= 0 || Snake.SnakeHead.horizontal >= width - 1 || Snake.SnakeHead.vertical <= 0 || Snake.SnakeHead.vertical >= height - 1)
        {
            alive = false;
            return;
        }
        CollisionChecker(Snake.SnakeHead);
        
        Snake.SnakeBody.Insert(0, oldHead);

        if (Snake.SnakeHead == Apple)
        {
            ateApple = true;
            PlaceApple();
        }

        if (!ateApple && Snake.SnakeBody.Count > 0)
        {
            Snake.RemovedTail = Snake.SnakeBody[^1];
            Snake.SnakeBody.RemoveAt(Snake.SnakeBody.Count - 1);
        }
        else
        {
            Snake.RemovedTail = null;
        }
        
        ateApple = false;
        
        if (Snake.SnakeBody.Contains(Snake.SnakeHead))
        {
            alive = false;
        }

        Board.PlayingFieldGenerator(height, width, Snake.SnakeBody, Snake.SnakeHead, Apple);
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
            newApple == Snake.SnakeHead ||
            Snake.SnakeBody.Contains(newApple)
        );

        Apple = newApple;
    }

    public bool AliveCheck()
    {
        if (alive) return alive;
        Thread.Sleep(100);
        Console.Write("Game Over!");
        return alive;
    }

    internal void CollisionChecker((int horizontal, int vertical)SnakeHead)
    {
        
        
    }
}