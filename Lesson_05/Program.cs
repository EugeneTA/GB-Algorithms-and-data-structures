using Lesson_04_Task_02;
using System;

namespace Lesson_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            for (int i=1; i < 16; i++)
            {
                tree.AddItem(i);
            }

            Console.WriteLine();
            tree.PrintTree();

            Console.WriteLine();
            TreeExtra.BFSSearch(tree.GetRoot(), 10);

            Console.WriteLine();
            TreeExtra.DFSSearch(tree.GetRoot(), 10);

            Console.WriteLine();
            TreeExtra.BFSSearch(tree.GetRoot(), 20);

            Console.WriteLine();
            TreeExtra.DFSSearch(tree.GetRoot(), 20);
        }
    }
}
