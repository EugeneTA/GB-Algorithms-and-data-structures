using System;
using System.Collections.Generic;
using ResultCheck;
using CreateTestData;

namespace Lesson_08_BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define sort array size
            int arraySize = 100_000_000;

            // Generate test array
            Console.WriteLine($"{DateTime.Now} - Start to fill up array");
            List<int> generatedList = TestData.CreateTestList(arraySize);
            Console.WriteLine($"{DateTime.Now} - Array fill up finished");
            Console.WriteLine($"{DateTime.Now} - Generated array sorted? - {Check.ListCheck(generatedList)}");

            // Sorting array
            Console.WriteLine($"{DateTime.Now} - Start to divide by buckets, sort buckets and merge ");
            BucketSort.Sort(generatedList);
            //generatedList.Sort();
            Console.WriteLine($"{DateTime.Now} - Finish divide by buckets, sort buckets and merge");

            // Check sort result
            Console.WriteLine($"{DateTime.Now} - Start result check");
            Console.WriteLine($"{DateTime.Now} - Result array sorted? - {Check.ListCheck(generatedList)}");

            Console.WriteLine("Hit any key to exit ...");
            Console.ReadKey();
        }
    }
}
