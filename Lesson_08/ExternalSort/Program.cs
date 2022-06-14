using System;
using System.Collections.Generic;
using ResultCheck;
using CreateTestData;

namespace Lesson_08_ExternalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            long records;
            string testFileName = "testfile.txt";
            string resultFileName = "sorted.txt";

            Console.Write(" Enter record's number for the test file: ");

            if (long.TryParse(Console.ReadLine(), out records))
            {
                Console.WriteLine();
                Console.WriteLine($" {DateTime.Now} - Creating test file: {testFileName}");
                TestData.CreateTestFile(testFileName, records);

                Console.WriteLine();
                Console.WriteLine($" {DateTime.Now} - Test file \'{testFileName}\' created with {ExternalSort.GetRecordsNumber(testFileName)} record.");

                (bool isSorted, long items) = Check.FileCheck(testFileName, ExternalSort.GetRecordsNumber(testFileName));

                Console.WriteLine();
                Console.WriteLine($" {DateTime.Now} - Check if test file \'{testFileName}\' is sorted.");
                Console.WriteLine($" {DateTime.Now} - Record's checked: {items}, Sorted?: {isSorted}");


                Console.WriteLine();
                Console.WriteLine($" {DateTime.Now} - Start external sort.");
                ExternalSort.Sort(testFileName, resultFileName);

                Console.WriteLine();
                Console.WriteLine($" {DateTime.Now} - Checking result file \'{resultFileName}\'.");
                (isSorted, items) = Check.FileCheck(resultFileName, ExternalSort.GetRecordsNumber(resultFileName));
                Console.WriteLine($" {DateTime.Now} - Record's checked: {items}, Sorted?: {isSorted}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You entered wrong number.");
            }

            Console.WriteLine();
            Console.Write("Hit any key to exit ...");
            Console.ReadKey();
        }
    }
}
