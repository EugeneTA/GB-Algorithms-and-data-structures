using System;


namespace Lesson_01.Common
{
    public static class Helper <T>
    {
        // выводит в консоль заданную строку нужным цветом, без перевода на новую строку.
        public static void WriteWithColor(T toPrint, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(toPrint);
            Console.ForegroundColor = defaultColor;
        }

        public static void WriteLineWithColor(T toPrint, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(toPrint);
            Console.ForegroundColor = defaultColor;
        }

    }
}
