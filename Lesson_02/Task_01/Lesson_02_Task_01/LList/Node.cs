
using System;

namespace Lesson_02_Task_01.LList
{
    public class Node : ICloneable
    {
        public int Value { get; set; }
        internal Node NextNode { get; set; }
        internal Node PrevNode { get; set; }

        public Node() : this(0)
        {

        }

        public Node(int value) : this (value, null, null)
        {

        }

        public Node(int value, Node nextNode, Node prevNode)
        {
            Value = value;
            NextNode = nextNode;
            PrevNode = prevNode;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public object Clone() => new Node(Value, NextNode, PrevNode);
    }

}
