using Snake;
namespace SnakeConsole;

internal class Program
{
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
        var game = new GameLogic(boardHeight, boardWidth);
        game.PlaceApple();
        Console.Clear();
    
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
        Console.Clear();

        Console.SetCursorPosition(game.Apple.horizontal, game.Apple.vertical);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("🍎");

        Console.SetCursorPosition(game.SnakeHead.horizontal, game.SnakeHead.vertical);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("🐍");

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var part in game.SnakeBody)
        {
            Console.SetCursorPosition(part.horizontal, part.vertical);
            Console.Write("■");
        }
        
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var part in game.Board.PlayingField)
        {
            Console.SetCursorPosition(part.horizontal, part.vertical);
            Console.Write("■");
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