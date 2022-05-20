using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_06
{
    /// <summary>
    /// Graph edge class
    /// </summary>
    public class Edge
    {
        // Edge weight
        public int Weight { get; set; }
        // Edge destination node
        public GraphNode Node { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Edge)
            {
                if (
                    Weight == ((Edge)obj).Weight &&
                    Node.Equals(((Edge)obj).Node)
                    )
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Node != null)
            {
                return (Weight * Weight) + (Node.Value * Node.Value) + base.GetHashCode();
            }

            return Weight * Weight + base.GetHashCode();
        }
    }
} 
