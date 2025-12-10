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
        
        var dx = 0; 
        var dy = 0;
        
        UpdateConsole(left, top);
        try
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    
                    if (keyInfo.Key == ConsoleKey.X) break;
                    
                    //Console.Clear();
                    
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.W:
                            dx = 0; dy = -1;
                            break;
                        case ConsoleKey.A:
                            dx = -1; dy = 0;
                            break;
                        case ConsoleKey.S:
                            dx = 0; dy = 1;
                            break;
                        case ConsoleKey.D:
                            dx = 1; dy = 0;
                            break;
                    }
                    UpdateConsole(left, top);
                }
                
                if (dx != 0 || dy != 0)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(" ");

                    var newLeft = left + dx;
                    var newTop = top + dy;

                    if (newLeft >= 0 && newLeft < Console.WindowWidth) left = newLeft;
                    if (newTop >= 0 && newTop < Console.WindowHeight) top = newTop;

                    UpdateConsole(left, top);
                }
                Thread.Sleep(100);
            }
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