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
        var game = new GameLogic();
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

    public static void Draw(GameLogic game)
    {
        Console.Clear();

        Console.SetCursorPosition(game.Apple.horizontal, game.Apple.vertical);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("O");

        Console.SetCursorPosition(game.SnakeHead.horizontal, game.SnakeHead.vertical);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("■");

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var part in game.SnakeBody)
        {
            Console.SetCursorPosition(part.horizontal, part.vertical);
            Console.Write("■");
        }
    }
}