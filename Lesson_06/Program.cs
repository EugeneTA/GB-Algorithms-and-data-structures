using System;
using System.Collections.Generic;

namespace Lesson_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lesson 06 Homework.");
            Console.WriteLine();

            #region Create Graph Nodes
            GraphNode node1 = new GraphNode();
            node1.Value = 1;

            GraphNode node2 = new GraphNode();
            node2.Value = 2;

            GraphNode node3 = new GraphNode();
            node3.Value = 3;

            GraphNode node4 = new GraphNode();
            node4.Value = 4;

            GraphNode node5 = new GraphNode();
            node5.Value = 5;

            GraphNode node6 = new GraphNode();
            node6.Value = 6;

            GraphNode node7 = new GraphNode();
            node7.Value = 7;

            GraphNode node8 = new GraphNode();
            node8.Value = 8;

            #endregion Graph Nodes

            #region Add edges to the nodes

            node1.Edges.Add(new Edge() { Weight = 1, Node = node2 });
            node1.Edges.Add(new Edge() { Weight = 2, Node = node3 });
            node1.Edges.Add(new Edge() { Weight = 3, Node = node4 });

            node2.Edges.Add(new Edge() { Weight = 4, Node = node5 });

            node3.Edges.Add(new Edge() { Weight = 5, Node = node6 });
            node3.Edges.Add(new Edge() { Weight = 1, Node = node4 });
            node3.Edges.Add(new Edge() { Weight = 2, Node = node1 });

            node4.Edges.Add(new Edge() { Weight = 6, Node = node8 });
            node4.Edges.Add(new Edge() { Weight = 1, Node = node3 });

            node5.Edges.Add(new Edge() { Weight = 8, Node = node7 });
            node5.Edges.Add(new Edge() { Weight = 2, Node = node6 });

            node6.Edges.Add(new Edge() { Weight = 1, Node = node8 });
            node6.Edges.Add(new Edge() { Weight = 5, Node = node3 });

            node7.Edges.Add(new Edge() { Weight = 3, Node = node8 });

            node8.Edges.Add(new Edge() { Weight = 1, Node = node6 });

            #endregion Add edges

            Console.WriteLine();
            Console.WriteLine("*********************************");
            Console.WriteLine($"Looking value = {8} from node 1:");
            Console.WriteLine();
            GraphSearch.BFSSearch(node1, 8);
            Console.WriteLine();
            GraphSearch.DFSSearch(node1, 8);

            Console.WriteLine();
            Console.WriteLine("*********************************");
            Console.WriteLine($"Looking value = {9} from node 1:");
            Console.WriteLine();
            GraphSearch.BFSSearch(node1, 9);
            Console.WriteLine();
            GraphSearch.DFSSearch(node1, 9);

            Console.WriteLine();
            Console.WriteLine("*********************************");
            Console.WriteLine($"Looking value = {1} from node 5:");
            Console.WriteLine();
            GraphSearch.BFSSearch(node5, 1);
            Console.WriteLine();
            GraphSearch.DFSSearch(node5, 1);

            Console.WriteLine();
            Console.WriteLine("*********************************");
            Console.WriteLine($"Looking value = {0} from node 5:");
            Console.WriteLine();
            GraphSearch.BFSSearch(node5, 0);
            Console.WriteLine();
            GraphSearch.DFSSearch(node5, 0);

            Console.ReadKey();
        }
    }
}
