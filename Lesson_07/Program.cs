using System;

namespace Lesson_07
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание. Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой
            // клетки в правую нижнюю. Известно что ходить можно только на одну клетку вправо или вниз.

            int tableWidth;
            int tableHeight;

            do
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Введите ширину поля: ");
                int.TryParse(Console.ReadLine(), out tableWidth);

                Console.Write("Введите высоту поля: ");
                int.TryParse(Console.ReadLine(), out tableHeight);

                Console.WriteLine($"Количество путей для поля {tableWidth}x{tableHeight}: {GetCornerToCornerRoutesNumber(tableWidth, tableHeight)}");

                Console.WriteLine();
                Console.Write("Продолжить? (Y,N): ");

            } while (ConsoleKey.Y == Console.ReadKey().Key);


            static long GetCornerToCornerRoutesNumber(int boardWidth, int boardHeight)
            {
                long result = 0;

                // Check, that board dimensions not zero in all dimensions
                if (boardWidth > 0 && boardHeight > 0)
                {
                    // Define default result
                    result = 1;

                    // Check, that board is not a row or column. If so, result is always 1
                    if (boardWidth != 1 && boardHeight != 1)
                    {
                        // Define calculated routes array for the previuos row
                        long[] prevNumOfWays = new long[boardHeight + 1];

                        // Start to calculate from the top row
                        for (int n = 0; n < boardWidth; n++)
                        {
                            for (int m = 0; m < boardHeight; m++)
                            {
                                // Calculate ways for the top row
                                if (n == 0 && m > 0)
                                {
                                    // First cell of the top row is zero, all other is 1
                                    prevNumOfWays[m] = 1;
                                }
                                // Calculate route for the row first cell (exept the top row)
                                else if (m == 0)
                                {
                                    // First cell of every row has only 1 route
                                    result = 1;
                                }
                                // Calculate destination for the all other cell's
                                else
                                {
                                    result += prevNumOfWays[m];
                                    prevNumOfWays[m] = result;
                                }
                            }
                        }
                    }
                }

                return result;
            }
        }
    }
}
