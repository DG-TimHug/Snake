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
        Console.Clear();
        var top = 3;
        var left = 20;
        var consoleWidth = Console.WindowWidth;
        
        UpdateConsole(left, top);
        try
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                //Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        top = Math.Max(0, top - 1);
                        break;
                    case ConsoleKey.A:
                        left = Math.Max(0, left - 1);
                        break;
                    case ConsoleKey.S:
                        top = Math.Min(Console.WindowHeight - 1, top + 1);
                        break;
                    case ConsoleKey.D:
                        left = Math.Max(0, left + 1);
                        break;
                }
                UpdateConsole(left, top);
            } while (keyInfo.Key != ConsoleKey.X);
        }
        catch (Exception)
        {
            Console.Write("error");
        }
    }

    private static void UpdateConsole(int left, int top)
    {
        Console.SetCursorPosition(left,top);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("■");
    }
}