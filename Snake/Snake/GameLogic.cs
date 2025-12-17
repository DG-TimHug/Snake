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
        var newhead = CollisionChecker();

        if (!alive)
        {
            return;
        }
        
        var oldHead = Snake.SnakeHead;
        Snake.SnakeHead = newhead;
        
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
        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine($"The Length of your snake was {Snake.SnakeBody.Count}");
        var key = Console.ReadKey(true).Key;
        return alive;
    }

    internal (int horizontal, int vertical) CollisionChecker()
    {
        var newHead = (
            horizontal: Snake.SnakeHead.horizontal + Direction.Horizontal,
            vertical: Snake.SnakeHead.vertical + Direction.Vertical
        );
    
        if (newHead.horizontal <= 0 || newHead.horizontal >= width - 1 || 
            newHead.vertical <= 0 || newHead.vertical >= height - 1)
        {
            alive = false;
        }
    
        if (Snake.SnakeBody.Contains(newHead))
        {
            alive = false;
        }

        return newHead;
    }
}