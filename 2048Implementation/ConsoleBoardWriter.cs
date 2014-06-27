using System;

namespace _2048Implementation
{
    public class ConsoleBoardWriter : IBoardWriter
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteBoard(IBoard board)
        {
            for (int row = 0; row < 4; row++)
            {
                Console.WriteLine();
                for (int column = 0; column < 4; column++)
                {
                    var value = board.GetCellValue(row, column);
                    var cellWasMerged = board.WasCellMerged(row, column);

                    if (cellWasMerged)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (value >= 128)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (value >= 32)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (value > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(" {0,6} ", value);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
