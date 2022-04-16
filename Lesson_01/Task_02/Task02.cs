using Lesson_01.Common;
using System;


namespace Lesson_01.Task_02
{
    public class Task02 : ITask
    {
        public void Execute(bool ifDebug)
        {
            Console.WriteLine();
            Console.WriteLine(" Вычислите асимптотическую сложность функции.");
            Console.WriteLine();
            Console.Write(" Итоговая асимптотическая сложность: ");
            Helper<string>.WriteLineWithColor($"O(1) + O(f1(N) * f2(N) * f3(3N)) + O(1) = O(N ^ 3)", ConsoleColor.Green);

            Console.WriteLine(@"                
    public static int StrangeSum(int[] inputArray)
    {
        int sum = 0; -  - Сложность O(1) 

        for (int i = 0; i < inputArray.Length; i++) - f1 - Сложность  O(N)
        {
            for (int j = 0; j < inputArray.Length; j++) - f2- Сложность O(N)
            {
                for (int k = 0; k < inputArray.Length; k++) - f3 Сложность O(N)
                {
                   // сложностью выполнения этих операций можно пренебречь
                   int y = 0;   - Сложность O(1) 
        
                    if (j != 0) - Сложность O(1) 
                    {
                       y = k / j; 
                    }
    
                    sum += inputArray[i] + i + k + j + y; - Сложность O(1) 
                }
            }
        }
        
        return sum;  - Сложность O(1) - можно пренебречь
    }"
    );
        }
    }
}
