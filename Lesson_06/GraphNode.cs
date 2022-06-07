using System.Collections.Generic;
using System.Linq;

namespace Lesson_06
{
    /// <summary>
    /// Graph node
    /// </summary>
    public class GraphNode
    {
        // Node value
        public int Value { get; set; }
        // Node edges to the other nodes
        public List<Edge> Edges { get; set; } = new List<Edge>();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is GraphNode)
            {
                if (
                    Value == ((GraphNode)obj).Value &&
                    Edges.Equals(((GraphNode)obj).Edges)
                    )
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            int resultHashCode = 0;

            foreach (var edge in Edges)
            {
                resultHashCode += edge != null ? edge.Weight : 1;
            }

            return (Value * Value) + (resultHashCode * resultHashCode) + base.GetHashCode();
        }
    }
}