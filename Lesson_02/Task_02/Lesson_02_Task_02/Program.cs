using System;

namespace Lesson_02_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine(" Урок 2. Задание 2");
            Console.WriteLine(" Требуется написать функцию бинарного поиска.");
            Console.WriteLine(" Посчитать его асимптотическую сложность и проверить работоспособность функции");

            int test;
            int[] testArray = new int[] {-10, -7, -3, 0, 2 , 5, 12, 24, 127};


            Console.WriteLine(" Асимптотическая сложность алгоритма:");
            Console.WriteLine(" На каждом этапе мы делим всю последовательность на 2.");
            Console.WriteLine(" Таким образом получаем на 1-ом этапе => n/2");
            Console.WriteLine("                        на 2-ом этапе => n/4");
            Console.WriteLine("                        на 3-м этапе  => n/8");
            Console.WriteLine("                        ......");
            Console.WriteLine("                        на i-ом этапе => n/(2^i)");
            Console.WriteLine(" Таким образом получаем, что n = 2^i.");
            Console.WriteLine(" А это значит, что i = log(n)");
            Console.WriteLine(" Значит, асимптотическая сложность равна O(log(n))");

            Console.WriteLine();
            Console.WriteLine(" Проверка:");

            Console.WriteLine($" Массив:");
            Console.WriteLine();

            foreach (int i in testArray)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
            Console.WriteLine();


            test = -20;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == -1) : 10}");

            test = -10;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == 0): 10}");

            test = -5;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == -1): 10}");

            test = 0;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == 3): 10}");

            test = 5;
            Console.WriteLine($" Ищем {test,5}   Индекс в массиве: {BinarySearch(testArray, test),10}   Проверка: {(BinarySearch(testArray, test) == 5): 10}");

            test = 15;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == -1): 10}");

            test = 127;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == 8): 10}");

            test = 200;
            Console.WriteLine($" Ищем {test, 5}   Индекс в массиве: {BinarySearch(testArray, test), 10}   Проверка: {(BinarySearch(testArray, test) == -1): 10}");

            Console.WriteLine();
            Console.WriteLine(" Нажмите любую клавишу для завершения работы ...");
            Console.ReadKey();

        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
