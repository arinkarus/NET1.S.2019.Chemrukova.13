using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests.TestEntities
{
    public class DescComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return (y - x);
        }
    }
}
