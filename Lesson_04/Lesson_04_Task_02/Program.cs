using System;

namespace Lesson_04_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree() { Debug = true };

            Console.WriteLine();

            for (int i = 1; i < 16; i++)
            {
                tree.AddItem(i);
                tree.PrintTree();
                Console.WriteLine();
            }

            Console.WriteLine("Add 15");
            tree.AddItem(15);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(8);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(6);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(10);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(14);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(12);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(13);
            Console.WriteLine();
            tree.PrintTree();

            tree.RemoveItem(15);
            Console.WriteLine();
            tree.PrintTree();

            tree.AddItem(100);
            Console.WriteLine();
            tree.PrintTree();

            tree.AddItem(65);
            Console.WriteLine();
            tree.PrintTree();

            tree.AddItem(200);
            Console.WriteLine();
            tree.PrintTree();


            Console.ReadKey();
        }
    }

}

