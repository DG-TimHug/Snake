using Snake;

namespace SnakeConsole;

class Program
{
    static void Main()
    {
        Run();
    }
    public static void Run()
    {

        var game = new GameLogic();
        game.PlaceApple();
        Console.Clear();

        while (true)
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
            Thread.Sleep(100);

        }
    }

    public static void Draw(GameLogic game)
    {
        Console.Clear();

        Console.SetCursorPosition(game.Apple.horizontal, game.Apple.vertical);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("🍎");

        Console.SetCursorPosition(game.Snakehead.horizontal, game.Snakehead.vertical);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("■");

        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (var b in game.Snakebody)
        {
            Console.SetCursorPosition(b.horizontal, b.vertical);
            Console.Write("■");
        }
    }
}