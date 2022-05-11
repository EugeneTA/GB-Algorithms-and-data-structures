
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;


namespace Lesson_04_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }
    }

    public class BenchmarkSearch
    {
        public int N { get; set; } = 10000;

        string[] strArray;
        HashSet<string> hashSet;

        string symbols = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFJHIJKLMNOPQRSTUVWXYZ";
        string search;

        public BenchmarkSearch()
        {
            strArray = new string[N];
            hashSet = new HashSet<string>(N);

            for (int i = 0; i < N; i++)
            {
                string tmp = RandomString(15, symbols);
                strArray[i] = tmp;
                hashSet.Add(tmp);
            }

            search = strArray[(new Random()).Next(N - 1)];
        }

        private string RandomString(int lenght, string symbols)
        {
            Random random = new Random();
            String result = "";

            for (int i = 0; i < lenght; i++)
            {
                int x = random.Next(symbols.Length);
                result += symbols[x];
            }

            return result;
        }

        [Benchmark]
        public bool SearchInArray()
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                if (string.Equals(search, strArray[i]))
                {
                    return true;
                }
            }

            return false;
        }

        [Benchmark]
        public bool SearchInHashSet()
        {
            return hashSet.Contains(search);
        }
    }
}


