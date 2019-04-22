using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests.TestEntities
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point first, Point second)
        {
            if (first.X > second.X)
            {
                if (first.Y > second.Y)
                {
                    return 1;
                }
            }
            if (first.X == second.X && first.Y == second.Y)
            {
                return 0;
            }
            return -1;
        }
    }
}
