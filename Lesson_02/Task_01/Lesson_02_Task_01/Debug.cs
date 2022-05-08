using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02_Task_01
{
    public class Debug
    {
        public bool IfDebug = false;
        public void DebugWriteLine(string message)
        {
            if (IfDebug)
            {
                //Console.WriteLine();
                Console.WriteLine(message);
            }
        }

        public void DebugWriteLine(string function, string message)
        {
            if (IfDebug)
            {
                //Console.WriteLine();
                AddColor<string>(function, ConsoleColor.Cyan);
                Console.WriteLine($": {message}.");
            }
        }

        public void DebugWriteLine()
        {
            if (IfDebug)
            {
                Console.WriteLine();
            }
        }

        public void DebugWrite(string function, string message)
        {
            if (IfDebug)
            {
                //Console.WriteLine();
                AddColor<string>(function, ConsoleColor.Cyan);
                Console.Write($": {message}.");
            }
        }

        public void DebugWrite(string message)
        {
            if (IfDebug)
            {
                Console.Write(message);
            }
        }

        public void AddColor<T>(T value, ConsoleColor consoleColor)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;

            Console.Write($"{value}");

            Console.ForegroundColor = defaultColor;
        }
    }
}
