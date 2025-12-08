using Snake;

namespace SnakeConsole;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Snake!");
        Console.WriteLine("Before starting lets set the playing field size");
        var boardWidth = GetWindowWidth();
        var boardHeight = GetWindowHeight();
        var board = new GameLogic(boardHeight, boardWidth);
        Console.Clear();
        Console.CursorVisible = false;
        do
        {
            for (var row = 0; row < board.PlayingField.GetLength(0); row++)
            {
                for (var column = 0; column < board.PlayingField.GetLength(1); column++)
                {
                    if (board.PlayingField[row, column])
                    {
                        PrintHead();
                    }
                    else
                    {
                        PrintApple();
                    }
                }

                Console.WriteLine();
            }
            board.AdvanceGeneration();
            Console.SetCursorPosition(0,0);
        } while (board.IsGameAlive());
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
    private static void PrintHead()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" ■ ");
        Console.ResetColor();
    }
    
    private static void PrintApple()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(" 🍎 ");
        Console.ResetColor();
    }
}