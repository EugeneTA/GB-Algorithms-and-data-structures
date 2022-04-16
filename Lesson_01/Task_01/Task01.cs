using Lesson_01.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01.Task_01
{
    public class Task01 : ITask
    {
        public void Execute(bool ifDebug)
        {
            Console.WriteLine();
            Console.WriteLine(" Урок 1. Задание 1.");
            Console.WriteLine(" Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.");

            if (ifDebug == false)
            {
                bool askDigit = true;

                while (askDigit)
                {
                    try
                    {
                        Console.Write(" Введите целое положительное число больше 1: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        if (n > 1)
                        {
                            askDigit = false;
                            Console.Write($" Результат: вы ввели число ");
                            Helper<int>.WriteWithColor(n, ConsoleColor.Red);
                            Console.Write(" - ");
                            Helper<string>.WriteWithColor(ResultToString(IsPrimeNumber(n)), ConsoleColor.Red);
                            Console.Write(" число");
                            Console.Write(Environment.NewLine);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($" Число введено неверно. {e.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine($" Тестовая проверка:");
                PrintTestResults(2, true);
                PrintTestResults(3, true);
                PrintTestResults(4, false);
                PrintTestResults(5, true);
                PrintTestResults(23, true);
                PrintTestResults(50, false);
            }

        }

        private bool IsPrimeNumber(int number)
        {
            bool result = false;
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                result = true;
            }

            return result;
        }

        private string ResultToString(bool result)
        {
            return result ? "простое" : "не простое";
        }

        private void PrintTestResults(int number, bool truth)
        {
            Console.Write($" Число ");
            Helper<string>.WriteWithColor($"{number,5}", ConsoleColor.Yellow);
            Console.Write($" | ");
            if (IsPrimeNumber(number))
            {
                Helper<string>.WriteWithColor($"{"простое", 10}", ConsoleColor.Green);
            }
            else
            {
                Helper<string>.WriteWithColor($"{"не простое", 10}", ConsoleColor.Red);
            }

            Console.Write($" | Результат верен? ");

            if (IsPrimeNumber(number) == truth)
            {
                Helper<string>.WriteWithColor($"да", ConsoleColor.Green);
            }
            else
            {
                Helper<string>.WriteWithColor($"нет", ConsoleColor.Red);
            }

            Console.Write(Environment.NewLine);
        }

    }
}
