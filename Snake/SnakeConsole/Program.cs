using Snake;
namespace SnakeConsole;

internal class Program
{
    public static bool firstRender;
    static void Main()
    {
        Console.CursorVisible = false;
    
        Console.SetBufferSize(Console.BufferWidth, Console.WindowHeight);

        Run();
    }
    
    private static void Run()
    {
        
        Console.WriteLine("Welcome to Snake");
        Console.WriteLine("Before starting lets set the playing field size");
        var boardWidth = GetWindowWidth();
        var boardHeight = GetWindowHeight();
        
        Console.SetBufferSize(
            Math.Max(Console.BufferWidth, boardWidth),
            Math.Max(Console.BufferHeight, boardHeight)
        );

        Console.SetWindowSize(
            Math.Min(Console.LargestWindowWidth, boardWidth),
            Math.Min(Console.LargestWindowHeight, boardHeight)
        );
        
        var game = new GameLogic(boardHeight, boardWidth);
        game.PlaceApple();
        Console.Clear();
        firstRender = true;
    
        while (game.Alive())
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W: 
                    {
                        game.SetDirection(Direction.Up); 
                        break;
                        
                    }
                    case ConsoleKey.A:
                    {
                        game.SetDirection(Direction.Left); 
                        break;
                    }
                    case ConsoleKey.S:
                    {
                        game.SetDirection(Direction.Down);
                        break;
                    }
                    case ConsoleKey.D:
                    {
                        game.SetDirection(Direction.Right); 
                        break;
                    }
                }
            }

            game.Update();
            Draw(game);
            Thread.Sleep(120);
        }
    }

    private static void Draw(GameLogic game)
    {
        if (firstRender)
        {
            var field = game.Board.PlayingField;
            var height = field.GetLength(0);
            var width = field.GetLength(1);

            for (var row = 0; row < height; row++)
            for (var col = 0; col < width; col++)
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(col, row);
                    Console.Write("#");
                }

            firstRender = false;
        }

        
        Console.SetCursorPosition(game.Apple.horizontal, game.Apple.vertical);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("*");

        Console.SetCursorPosition(game.SnakeHead.horizontal, game.SnakeHead.vertical);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("O");

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var part in game.SnakeBody)
        {
            Console.SetCursorPosition(part.horizontal, part.vertical);
            Console.Write("o");
        }
    }
    
    private static int GetWindowHeight()
    {
        while (true)
        {
            Console.WriteLine("How tall should the playing field be?");
            if (int.TryParse(Console.ReadLine(), out var playingFieldHeight) && playingFieldHeight > 0)
            {
                return playingFieldHeight;
            }
            Console.WriteLine("Please enter a number between 0 and 100..");
        }
    }

    private static int GetWindowWidth()
    {
        while (true)
        {
            Console.WriteLine("How wide should the playing field be?");
            if (int.TryParse(Console.ReadLine(), out var playingFieldWidth) && playingFieldWidth > 0)
            {
                return playingFieldWidth;
            }
            Console.WriteLine("Please enter a number between 0 and 100..");
        }
    }
}