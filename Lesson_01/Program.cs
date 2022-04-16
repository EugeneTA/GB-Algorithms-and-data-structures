using System;
using Lesson_01.Common;
using Lesson_01.Task_01;

namespace Lesson_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ITask task;
            bool taskIsWorking = true;
            ConsoleKey userInput;
            TaskFactory taskFactory = new TaskFactory();

            while (taskIsWorking)
            {
                Console.WriteLine(" Курс \"Алогоритмы и структуры данных\". Домашнее задание. Урок 1.");
                Console.WriteLine(" Выберите действие:");
                Console.WriteLine(" 0. Завершить работу.");
                Console.WriteLine(" 1. Реализовать алгоритм проверки простого числа согласно блок-схеме. ");
                Console.WriteLine(" 2. Посчитать асимптотическую сложность фуекции.");
                Console.WriteLine(" 3. Реализация фунции вычисления числа Фибоначи методом рекурсии и через цикл.");
                Console.Write(" > ");

                userInput = Console.ReadKey().Key;

                task = null;

                switch (userInput)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        {
                            taskIsWorking = false;
                        }
                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            task = taskFactory.GetTask(1);
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            task = taskFactory.GetTask(2);
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            task = taskFactory.GetTask(3);
                        }
                        break;
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine(" Ошибка выбора задачи. Введите число от 0 до 3.");
                            Console.WriteLine();
                        }
                        break;
                }

                if (task != null)
                {
                    Console.Clear();
                    task.Execute(true);
                    Console.WriteLine();
                    Console.WriteLine(" Нажмите любую клавишу для продолжения ...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
