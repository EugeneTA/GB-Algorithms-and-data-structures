using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_04_Task_02;

namespace Lesson_05
{
    public static class TreeExtra
    {
        public static TreeNode BFSSearch(TreeNode root, int value)
        {
            if (root == null) return root;

            Queue<TreeNode> queue = new Queue<TreeNode>(20);

            queue.Enqueue(root);

            Console.WriteLine("BFS search");
            Console.WriteLine($"Looking for value: {value}.");
            Console.WriteLine();

            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();

                if (currentNode != null)
                {
                    Console.Write($"({currentNode.Value}) -> ");
                    if (currentNode.Value == value)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Found ({currentNode.Value}).");
                        return currentNode;
                    }
                    if (currentNode.LeftChild != null) queue.Enqueue(currentNode.LeftChild);
                    if (currentNode.RightChild != null) queue.Enqueue(currentNode.RightChild);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Value: {value}, was not found.");
            return null;
        }

        public static TreeNode DFSSearch(TreeNode root, int value)
        {
            if (root == null) return root;

            Stack<TreeNode> stack = new Stack<TreeNode>(20);

            stack.Push(root);

            Console.WriteLine("DFS search");
            Console.WriteLine($"Looking for value: {value}.");
            Console.WriteLine();

            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();

                if (currentNode != null)
                {
                    Console.Write($"({currentNode.Value}) -> ");

                    if (currentNode.Value == value)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Found ({currentNode.Value}).");
                        return currentNode;
                    }
                    if (currentNode.RightChild != null) stack.Push(currentNode.RightChild);
                    if (currentNode.LeftChild != null) stack.Push(currentNode.LeftChild);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Value: {value}, was not found.");

            return null;
        }
    }
}
