using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests.TestEntities
{
    public class BookByNameComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if ((x == null) || (y == null))
            {
                throw new ArgumentException($"Can't compare books that are null: {nameof(x)}" +
                    $" and {nameof(y)}");
            }
            return x.Name.CompareTo(y.Name);
        }
    }
}
