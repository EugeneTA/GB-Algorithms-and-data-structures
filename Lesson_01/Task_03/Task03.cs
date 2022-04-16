using Lesson_01.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01.Task_03
{
    public class Task03 : ITask
    {
        public void Execute(bool ifDebug)
        {
            Console.WriteLine();
            Console.WriteLine(" 3. Реализация фунции вичисления числа Фибоначи методом рекурсии.");


            PrintResultRecursion(-10, -55);
            PrintResultCycle(-10, -55);

            PrintResultRecursion(0, 0);
            PrintResultCycle(0, 0);

            PrintResultRecursion(10, 55);
            PrintResultCycle(10, 55);

            PrintResultRecursion(20, 6765);
            PrintResultCycle(20, 6765);
        }

        private (bool, double[]) FiboRecursion(int number)
        {                                                                    
            try
            {
                // Массив будет хранить уже вычисленные значения для чисел Фибоначчи, чтобы не вычислять их повторно
                // т.к. Фибоначчи для 0 равно 0, то создаем массив с числом элементов на 1 больше числа введенного пользователе
                double[] fibResult = new double[Math.Abs(number) + 1];

                double fib = Fibonacci(number);

                double Fibonacci(int number)
                {
                    // Для числа 0 возвращаем 0, для  1 возвращаем 1, для -1 возвращаем -1
                    if (number == 0)
                    {
                        fibResult[0] = 0;
                        return 0;
                    }
                    else if (number == 1)
                    {
                        fibResult[1] = 1;
                        return 1;
                    }
                    else if (number == -1)
                    {
                        fibResult[1] = -1;
                        return -1;
                    }
                    else
                    {
                        if (number > -1)
                        {
                            // Вычисление для положительных чисел
                            // Если число Фибоначчи еще не подсчитано (чило Фибоначчи равно 0 только для числа 0), то вычисляем число Фибоначчи
                            if (fibResult[number] == 0)
                            {
                                fibResult[number] = Fibonacci(number - 1) + Fibonacci(number - 2);
                            }

                            return fibResult[number];

                        }
                        else
                        {
                            // Вычисление для отрицательных чисел
                            if (fibResult[Math.Abs(number)] == 0)
                            {
                                fibResult[Math.Abs(number)] = Fibonacci(number + 1) + Fibonacci(number + 2);
                            }

                            return fibResult[Math.Abs(number)];
                        }
                    }
                }

                return (true, fibResult);

            }
            catch (Exception e)
            {
                Console.WriteLine($" Ошибка при вычислении последовательности Фибоначчи рекурсивным способом. {e.Message}");
                return (false, null);
            }
        }

        private (bool, double[]) FiboCycle(int number)
        {
            try
            {
                // Массив будет хранить уже вычисленные значения для чисел Фибоначчи,
                // т.к. Фибоначчи для 0 равно 0, то создаем массив с числом элементов на 1 больше числа введенного пользователе
                double[] fibResult = new double[Math.Abs(number) + 1];
                
                fibResult[0] = 0;

                if (0 < number)
                {
                    // Фибоначчи для 1
                    fibResult[1] = 1;
                }
                else if (number < 0)
                {
                    // Фибоначчи для -1
                    fibResult[1] = -1;
                }

                // Фибоначчи для  всех остальных чисел
                for (int i = 2; i <= Math.Abs(number); i++)
                {
                    fibResult[i] = fibResult[i - 1] + fibResult[i - 2];

                }

                return (true, fibResult);

            }
            catch (Exception e)
            {
                Console.WriteLine($" Ошибка при вычислении последовательности Фибоначчи рекурсивным способом. {e.Message}");
                return (false, null);
            }
        }

        private void PrintResultRecursion(int fib, double testNumber)
        {
            (bool result, double[] fibResult) = FiboRecursion(fib);

            if (result == true)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($" Вычисление числа Фибоначчи для числа '{fib}' методом рекурсии:  ");
                Helper<string>.WriteLineWithColor($" {fibResult[fibResult.Length-1]}", ConsoleColor.Green);

                // Выводим последовательность Фибоначчи.
                if (fib > -1)
                {
                    for (int i = 0; i < fibResult.Length; i++)
                    {
                        Helper<string>.WriteWithColor($" {fibResult[i]}", ConsoleColor.Red);
                    }
                }
                else
                {
                    for (int i = Math.Abs(fib); i >= 0; i--)
                    {
                        Helper<string>.WriteWithColor($" {fibResult[i]}", ConsoleColor.Red);
                    }
                }

                Console.WriteLine();

                Console.Write($" Результат верен? ");

                if (fibResult[fibResult.Length - 1] == testNumber)
                {
                    Helper<string>.WriteWithColor($"да", ConsoleColor.Green);
                }
                else
                {
                    Helper<string>.WriteWithColor($"нет", ConsoleColor.Red);
                }

                Console.WriteLine();
            }
        }

        private void PrintResultCycle(int fib, double testNumber)
        {
            (bool result, double[] fibResult) = FiboCycle(fib);

            if (result == true)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($" Вычисление числа Фибоначчи для числа '{fib}' через цикл:  ");
                Helper<string>.WriteLineWithColor($" {fibResult[fibResult.Length - 1]}", ConsoleColor.Green);

                // Выводим последовательность Фибоначчи.
                if (fib > -1)
                {
                    for (int i = 0; i < fibResult.Length; i++)
                    {
                        Helper<string>.WriteWithColor($" {fibResult[i]}", ConsoleColor.Red);
                    }
                }
                else
                {
                    for (int i = Math.Abs(fib); i >= 0; i--)
                    {
                        Helper<string>.WriteWithColor($" {fibResult[i]}", ConsoleColor.Red);
                    }
                }

                Console.WriteLine();

                Console.Write($" Результат верен? ");

                if (fibResult[fibResult.Length - 1] == testNumber)
                {
                    Helper<string>.WriteWithColor($"да", ConsoleColor.Green);
                }
                else
                {
                    Helper<string>.WriteWithColor($"нет", ConsoleColor.Red);
                }

                Console.WriteLine();
            }
        }

    }
}
