using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests.TestEntities
{
    public struct Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }
            var point = (Point)obj;
            return this.X == point.X && this.Y == point.Y;
        }

        public override int GetHashCode()
        {
            return (this.X, this.Y).GetHashCode();
        }
    }
}
