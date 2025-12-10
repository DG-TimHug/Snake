using Snake;

namespace SnakeConsole;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        Console.SetBufferSize(Console.BufferWidth, Console.WindowHeight);

        Run();
    }

    public static void Run()
    {
        var game = new GameLogic();
        game.PlaceApple();
        Console.Clear();

        while (true)
        {
            // Handle input
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W: game.SetDirection(Direction.Up); break;
                    case ConsoleKey.A: game.SetDirection(Direction.Left); break;
                    case ConsoleKey.S: game.SetDirection(Direction.Down); break;
                    case ConsoleKey.D: game.SetDirection(Direction.Right); break;
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

        Console.SetCursorPosition(game.Snakehead.horizontal, game.Snakehead.vertical);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("■");

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var part in game.Snakebody)
        {
            Console.SetCursorPosition(part.horizontal, part.vertical);
            Console.Write("■");
        }
    }
}