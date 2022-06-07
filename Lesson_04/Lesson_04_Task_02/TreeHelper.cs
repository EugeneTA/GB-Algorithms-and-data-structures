using System.Collections.Generic;

namespace Lesson_04_Task_02
{
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);
            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);
                var depth = element.Depth + 1;
                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }
            return returnArray.ToArray();
        }

        /// <summary>
        /// Rotate node to the right
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static TreeNode RotateRight(TreeNode node)
        {
            TreeNode root = node.LeftChild;
            node.LeftChild = root.RightChild;
            root.RightChild = node;
            RepairNodeHeight(node);
            RepairNodeHeight(root);
            return root;
        }

        /// <summary>
        /// Rotate node to the left
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static TreeNode RotateLeft(TreeNode node)
        {
            TreeNode root = node.RightChild;
            node.RightChild = root.LeftChild;
            root.LeftChild = node;
            RepairNodeHeight(node);
            RepairNodeHeight(root);
            return root;
        }

        /// <summary>
        /// Get node height
        /// </summary>
        /// <param name="node">node to check</param>
        /// <returns></returns>
        public static int GetNodeHeight(TreeNode node)
        {
            return node == null ? 0 : node.Height;
        }

        /// <summary>
        /// Get node child's height difference
        /// </summary>
        /// <param name="node">node to check</param>
        /// <returns></returns>
        public static int GetChildsHeightDiff(TreeNode node)
        {
            return GetNodeHeight(node.RightChild) - GetNodeHeight(node.LeftChild);
        }

        /// <summary>
        /// Repair node height parameter
        /// </summary>
        /// <param name="node"></param>
        public static void RepairNodeHeight(TreeNode node)
        {
            int leftNodeDepth = GetNodeHeight(node.LeftChild);
            int rightNodeDepth = GetNodeHeight(node.RightChild);

            node.Height = (leftNodeDepth > rightNodeDepth ? leftNodeDepth : rightNodeDepth) + 1;
        }

        /// <summary>
        /// Balance node childs
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static TreeNode BalanceNode(TreeNode node)
        {
            // Update node height parameter
            RepairNodeHeight(node);

            // Left child root is deeper than 2, rotate node to the left
            if (GetChildsHeightDiff(node) == 2)
            {
                if (GetChildsHeightDiff(node.RightChild) < 0)
                {
                    node.RightChild = RotateRight(node.RightChild);
                }

                return RotateLeft(node);
            }

            // Right child root is deeper than 2, rotate node to the right
            if (GetChildsHeightDiff(node) == -2)
            {
                if (GetChildsHeightDiff(node.LeftChild) > 0)
                {
                    node.LeftChild = RotateLeft(node.LeftChild);
                }

                return RotateRight(node);
            }

            return node;
        }
    }

}

