using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lesson_04_Task_02
{
    public class Tree : ITree
    {
        private TreeNode _rootNode;

        public bool Debug { get; set; }


        /// <summary>
        /// Add node to the tree
        /// </summary>
        /// <param name="value">node value</param>
        public void AddItem(int value)
        {
            if (Debug)
            {
                Console.WriteLine();
                Console.WriteLine($"Trying to add value {value}");
            }
            _rootNode = InsertNode(_rootNode, value);
        }


        /// <summary>
        /// Add node to the tree with defined value
        /// </summary>
        /// <param name="node">tree root</param>
        /// <param name="k">new node value</param>
        /// <returns>updated tree structure</returns>
        private TreeNode InsertNode(TreeNode node, int value)
        {
            // if root node is null, then return new node
            if (node == null) return new TreeNode() { Value = value };

            // if value is less, than node value, then trying add to the left side
            // else trying add to the right side
            if (value < node.Value)
            {
                node.LeftChild = InsertNode(node.LeftChild, value);

                // update node height parameter
                TreeHelper.RepairNodeHeight(node.LeftChild);
            }
            else if (value > node.Value)
            {
                node.RightChild = InsertNode(node.RightChild, value);

                // update node height parameter
                TreeHelper.RepairNodeHeight(node.RightChild);
            }

            // Trying to balance node and return root
            return TreeHelper.BalanceNode(node);
        }


        /// <summary>
        /// Get tree node by the value
        /// </summary>
        /// <param name="value">need value</param>
        /// <returns></returns>
        public TreeNode GetNodeByValue(int value)
        {
            if (Debug)
            {
                Console.WriteLine($"Getting node with value {value}");
            }

            // Check that tree is not empty
            if (_rootNode != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>(20);

                TreeNode node;
                queue.Enqueue(_rootNode);

                // Search node with need value
                do
                {
                    node = queue.Dequeue();

                    // Check node value
                    if (node != null)
                    {
                        if (node.Value == value)
                        {
                            if (Debug)
                            {
                                Console.WriteLine($"Find node with value {value}");
                            }

                            return node;
                        }

                        // Add child's to the queue
                        if (value < node.Value)
                        {
                            queue.Enqueue(node.LeftChild);
                        }
                        else
                        {
                            queue.Enqueue(node.RightChild);
                        }
                    }

                } while (queue.Count > 0);
            }

            if (Debug)
            {
                Console.WriteLine($"Node with value {value} was not found");
            }

            return null;
        }


        /// <summary>
        /// Get root node
        /// </summary>
        /// <returns></returns>
        public TreeNode GetRoot()
        {
            return _rootNode;
        }

        /// <summary>
        /// Remove node with value from the tree
        /// </summary>
        /// <param name="value">node value</param>
        public void RemoveItem(int value)
        {
            if (Debug)
            {
                Console.WriteLine();
                Console.WriteLine($"Trying to remove value {value}");
            }
            _rootNode = Remove(_rootNode, value);
        }

        /// <summary>
        /// Find node with minimum value
        /// </summary>
        /// <param name="node">start node</param>
        /// <returns></returns>
        private TreeNode FindMin(TreeNode node)
        {
            return node.LeftChild != null ? FindMin(node.LeftChild) : node;
        }

        /// <summary>
        /// Delete node with minimum value
        /// </summary>
        /// <param name="node">start node</param>
        /// <returns></returns>
        private TreeNode RemoveMin(TreeNode node)
        {
            // return right child if left is null
            if (node.LeftChild == null)
            {
                return node.RightChild;
            }

            node.LeftChild = RemoveMin(node.LeftChild);

            return TreeHelper.BalanceNode(node);
        }

        /// <summary>
        /// Remove node from the tree
        /// </summary>
        /// <param name="node">root node</param>
        /// <param name="value">value to delete</param>
        /// <returns>return updated root</returns>
        private TreeNode Remove(TreeNode node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
            {
                node.LeftChild = Remove(node.LeftChild, value);
            }
            else if (value > node.Value)
            {
                node.RightChild = Remove(node.RightChild, value);
            }
            else
            {
                TreeNode nextLeft = node.LeftChild;
                TreeNode nextRight = node.RightChild;

                node = null;

                if (nextRight == null) return nextLeft;

                TreeNode min = FindMin(nextRight);

                min.RightChild = RemoveMin(nextRight);
                min.LeftChild = nextLeft;

                return TreeHelper.BalanceNode(min);
            }

            return TreeHelper.BalanceNode(node);
        }


        /// <summary>
        /// Print tree to the console
        /// </summary>
        public void PrintTree()
        {
            Console.SetWindowSize(250, 80);

            if (_rootNode != null)
            {
                // Search queue
                Queue<NodeInfo> queue = new Queue<NodeInfo>(20);

                //Tree treeNodesList list
                List<NodeInfo> treeNodesList = new List<NodeInfo>();

                // Get console cursor positions
                (int offsetLeft, int offsetTop) = Console.GetCursorPosition();

                // Operating node
                var tmpNode = new NodeInfo() { Node = _rootNode };

                // Tree depth
                int treeDepth = tmpNode.Depth;

                // Add first node to the queue
                queue.Enqueue(tmpNode);

                // Fill up treeNodesList with tree node
                do
                {
                    // Get node from the queue
                    tmpNode = queue.Dequeue();

                    // Add node to the list
                    //treeNodesList.Add(tmpNode);

                    if (tmpNode != null)
                    {
                        if (tmpNode.Node != null)
                        {
                            // Check tree depth. If greater, then save new tree depth
                            if (treeDepth < tmpNode.Depth)
                            {
                                treeDepth = tmpNode.Depth;
                            }

                            // Add node childs to the queue 
                            queue.Enqueue(new NodeInfo() { Node = tmpNode.Node.LeftChild, Depth = tmpNode.Depth + 1 });
                            queue.Enqueue(new NodeInfo() { Node = tmpNode.Node.RightChild, Depth = tmpNode.Depth + 1 });
                        }
                    }
                } while (queue.Count != 0);

                // Operating node
                tmpNode = new NodeInfo() { Node = _rootNode };

                // Tree depth
                int tempDepth = tmpNode.Depth;

                // Add first node to the queue
                queue.Enqueue(tmpNode);
                // Fill up treeNodesList with tree node
                do
                {
                    // Get node from the queue
                    tmpNode = queue.Dequeue();

                    // Add node to the list
                    treeNodesList.Add(tmpNode);

                    if (tmpNode != null)
                    {
                        if (tmpNode.Node != null)
                        {
                            // Check tree depth. If greater, then save new tree depth
                            if (treeDepth < tmpNode.Depth)
                            {
                                tempDepth = tmpNode.Depth;
                            }

                            // Add node childs to the queue 
                            queue.Enqueue(new NodeInfo() { Node = tmpNode.Node.LeftChild, Depth = tmpNode.Depth + 1 });
                            queue.Enqueue(new NodeInfo() { Node = tmpNode.Node.RightChild, Depth = tmpNode.Depth + 1 });
                        }
                        else
                        {
                            // Check tree depth. If greater, then save new tree depth
                            if (treeDepth < tmpNode.Depth)
                            {
                                tempDepth = tmpNode.Depth;
                            }

                            queue.Enqueue(new NodeInfo() { Node = null, Depth = tmpNode.Depth + 1 });
                            queue.Enqueue(new NodeInfo() { Node = null, Depth = tmpNode.Depth + 1 });
                        }
                    }

                } while (queue.Count != 0 && treeDepth >= tempDepth);

                Console.SetCursorPosition(0, offsetTop + (2 * treeDepth));

                (List<int> prevNodeEndOffset, List<int> nodeMiddleOffset) = CalculateBaseNodesLeftOffset(treeNodesList, treeDepth);

                int index = 0;

                // Left offset
                int tmpLeftOffset = 0;

                List<int> tempPrevNodeEndOffset = new List<int>((int)Math.Pow(2, treeDepth));
                List<int> tempNodeMiddleOffset = new List<int>((int)Math.Pow(2, treeDepth));

                for (int i = 1; i <= treeDepth; i++)
                {
                    // Clear temporary offset lists
                    tempPrevNodeEndOffset.Clear();
                    tempNodeMiddleOffset.Clear();

                    tmpLeftOffset = 0;

                    // Get nodes list for depth level
                    var nodes = treeNodesList.Where(x => x.Depth == (treeDepth - i)).ToList();

                    // If nodes exist in depth level, then print them to the console
                    if ((nodes.FindAll(x => x.Node != null)).Count > 0)
                    {
                        // Space string
                        string space = "";

                        // Node value string
                        string nodeString = "";

                        // Node level string
                        //StringBuilder nodesStr = new StringBuilder();

                        // Node connection string
                        //StringBuilder connectionsStr = new StringBuilder();

                        // Go throut all items in list to print them to the console
                        for (int y = 0; y < nodes.Count; y++)
                        {
                            // Calculate index
                            index = y / 2;

                            // Add zero space to the list, if current loop index is >= list items
                            if (prevNodeEndOffset.Count <= y)
                            {
                                prevNodeEndOffset.Add(0);
                            }

                            // Make node value string
                            nodeString = nodes[y].Node != null ? $"({nodes[y].Node.Value})" : "(  )";


                            // Print conections to childs to the console
                            Console.SetCursorPosition(nodeMiddleOffset[2 * y], offsetTop + 2 * treeDepth - 2 * i + 1);
                            Console.Write($"/");

                            Console.SetCursorPosition(nodeMiddleOffset[2 * y + 1], offsetTop + 2 * treeDepth - 2 * i + 1);
                            Console.Write($"\\");


                            // Calculate distance between childs
                            int distance = nodeMiddleOffset[2 * y + 1] - nodeMiddleOffset[2 * y] - nodeString.Length;

                            // Set cursor position for the node value string
                            if (distance <= 0)
                            {
                                Console.SetCursorPosition(nodeMiddleOffset[2 * y], offsetTop + 2 * treeDepth - 2 * i);
                            }
                            else if (distance <= 2)
                            {
                                Console.SetCursorPosition(nodeMiddleOffset[2 * y] + 1, offsetTop + 2 * treeDepth - 2 * i);
                            }
                            else
                            {
                                Console.SetCursorPosition(nodeMiddleOffset[2 * y] + 1, offsetTop + 2 * treeDepth - 2 * i);

                                // add additional horizontal connections for the node value
                                string addition = new string('-', distance / 2);
                                nodeString = $"{addition}{nodeString}{addition}";
                            }

                            // print node value to the console
                            Console.Write($"{nodeString}");


                            // Add node middle offset to the temporary list
                            tempNodeMiddleOffset.Add(nodeMiddleOffset[2 * y] + nodeString.Length / 2 + 1);

                            // Calculate node end offset
                            tmpLeftOffset += nodeMiddleOffset[2 * y] + nodeString.Length;

                            // Add node end offset to the list
                            if (tempPrevNodeEndOffset.Count < index + 1)
                            {
                                tempPrevNodeEndOffset.Add(prevNodeEndOffset[y]);
                            }
                            else
                            {
                                tempPrevNodeEndOffset[index] += prevNodeEndOffset[y];
                            }
                        }
                    }

                    // Copy temporary list's to operating list's
                    prevNodeEndOffset.Clear();
                    prevNodeEndOffset.AddRange(tempPrevNodeEndOffset);

                    nodeMiddleOffset.Clear();
                    nodeMiddleOffset.AddRange(tempNodeMiddleOffset);
                }

                Console.SetCursorPosition(0, offsetTop + 2 * treeDepth + 1);
            }
            else
            {
                Console.WriteLine("Tree is empty");
            }
        }


        private (List<int>, List<int>) CalculateBaseNodesLeftOffset(List<NodeInfo> nodes, int treeDepthLevel)
        {
            if (nodes != null)
            {
                // Maximum nudes in depth level
                int nodesInTreeLevel = (int)Math.Pow(2, treeDepthLevel);

                // Spaces between nodes list
                List<int> prevNodeEndPosition = new List<int>((int)Math.Pow(2, treeDepthLevel));

                // Console left offset for the every node
                List<int> nodeMiddleLeftOffset = new List<int>(nodesInTreeLevel);

                var operatingList = nodes.Where(x => x.Depth == (treeDepthLevel)).ToList();

                int tmpLeftOffset = 0;
                string space = "\x20\x20";
                string node = "";

                for (int i = 0; i < nodesInTreeLevel; i++)
                {
                    if (operatingList.Count > i)
                    {
                        if (operatingList[i].Node != null)
                        {
                            node = $"({operatingList[i].Node.Value})";
                        }
                        else
                        {
                            node = "( )";
                        }
                    }
                    else
                    {
                        node = "( )";
                    }

                    Console.Write($"{node}{space}");

                    prevNodeEndPosition.Add(tmpLeftOffset);
                    nodeMiddleLeftOffset.Add(tmpLeftOffset + node.Length / 2);
                    tmpLeftOffset += node.Length + space.Length;
                }

                return (prevNodeEndPosition, nodeMiddleLeftOffset);
            }

            return (null, null);
        }


    }

}

