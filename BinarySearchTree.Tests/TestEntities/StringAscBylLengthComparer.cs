using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests.TestEntities
{
    class StringAscBylLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length - y.Length;
        }
    }
}
