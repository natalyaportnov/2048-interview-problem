
using System;
using _2048Implementation;

namespace _2048ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
 _______  _______  _   ___   _____  
|       ||  _    || | |   | |  _  | 
|____   || | |   || |_|   | | |_| | 
 ____|  || | |   ||       ||   _   |
| ______|| |_|   ||___    ||  | |  |
| |_____ |       |    |   ||  |_|  |
|_______||_______|    |___||_______|

Press any key to begin...
");
            Console.ReadKey();
            Console.Clear();

            var game = new Game(new Board(), new ConsoleBoardWriter());
            game.Start();

            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Q)
            {
                MoveDirection direction;

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        direction = MoveDirection.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = MoveDirection.Right;
                        break;
                    case ConsoleKey.UpArrow:
                        direction = MoveDirection.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = MoveDirection.Down;
                        break;
                    default:
                        key = Console.ReadKey();
                        continue;
                }

                var gameState = game.MakeMove(direction);
                if (gameState != GameState.InProgress) break;
                key = Console.ReadKey();
            }

            Console.ReadKey();

        }
    }
}
