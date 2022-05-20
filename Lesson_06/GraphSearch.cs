using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06
{
    public static class GraphSearch
    {
        /// <summary>
        /// Breadth-first search method
        /// </summary>
        /// <param name="root">graph start search node</param>
        /// <param name="value">value to search</param>
        /// <returns></returns>
        public static GraphNode BFSSearch(GraphNode root, int value)
        {
            // return null if root is null
            if (root == null) return root;

            // Hashset for visited nodes
            HashSet<GraphNode> visitedNodes = new HashSet<GraphNode>();

            // Queue for found nodes
            Queue<GraphNode> queue = new Queue<GraphNode>(20);

            // Put root node to the queue            
            queue.Enqueue(root);

            // Print info to the console
            Console.WriteLine("BFS search");
            Console.WriteLine($"Looking for value: {value}.");
            Console.WriteLine();

            // Begin search
            while (queue.Count > 0)
            {
                // Get next node from the queue
                GraphNode currentNode = queue.Dequeue();

                // If node not Null and not visited yet
                if (currentNode != null && (visitedNodes.Contains(currentNode) == false))
                {
                    // then add this node to the visited nodes hashset
                    visitedNodes.Add(currentNode);

                    // print debug info to the console
                    Console.Write($"({currentNode.Value}) -> ");

                    // if node value is what we looking for,
                    // then print debug info to console and return from the method
                    if (currentNode.Value == value)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Found ({currentNode.Value}).");
                        return currentNode;
                    }
                    
                    // if node value is not, what we looking for,
                    // than add all connected nodes to the queue, if they not null and do not visited yet
                    foreach(var edge in currentNode.Edges)
                    {
                        if (edge.Node != null)
                        {
                            if (visitedNodes.Contains(edge.Node) == false)
                            {
                                queue.Enqueue(edge.Node);
                            }     
                        }
                    }
                }
            }

            // Print debebug info, that looking value was not found and return null
            Console.WriteLine();
            Console.WriteLine($"Value: {value}, was not found.");
            return null;
        }

        /// <summary>
        /// Depth-first search method
        /// </summary>
        /// <param name="root">graph start search node</param>
        /// <param name="value">value to search</param>
        /// <returns></returns>
        public static GraphNode DFSSearch(GraphNode root, int value)
        {
            // return null if root is null
            if (root == null) return root;

            // Hashset for visited nodes
            HashSet<GraphNode> visitedNodes = new HashSet<GraphNode>();

            // Stack for found nodes
            Stack<GraphNode> stack = new Stack<GraphNode>(20);

            // Put root node to the stack 
            stack.Push(root);

            // Print info to the console
            Console.WriteLine("DFS search");
            Console.WriteLine($"Looking for value: {value}.");
            Console.WriteLine();

            // Begin search
            while (stack.Count > 0)
            {
                // Get next node from the stack
                GraphNode currentNode = stack.Pop();

                // If node not Null and not visited yet
                if (currentNode != null && (visitedNodes.Contains(currentNode) == false))
                {
                    // then add this node to the visited nodes hashset
                    visitedNodes.Add(currentNode);

                    // print debug info to the console
                    Console.Write($"({currentNode.Value}) -> ");

                    // if node value is what we looking for,
                    // then print debug info to console and return from the method
                    if (currentNode.Value == value)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Found ({currentNode.Value}).");
                        return currentNode;
                    }

                    // if node value is not, what we looking for,
                    // than add all connected nodes to the stack, if they not null and do not visited yet
                    foreach (var edge in currentNode.Edges)
                    {
                        if (edge.Node != null)
                        {
                            if (visitedNodes.Contains(edge.Node) == false)
                            {
                                stack.Push(edge.Node);
                            }
                        }
                    }
                }
            }

            // Print debebug info, that looking value was not found and return null
            Console.WriteLine();
            Console.WriteLine($"Value: {value}, was not found.");

            return null;
        }
    }
}
