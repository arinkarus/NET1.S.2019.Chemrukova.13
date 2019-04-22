using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests.TestEntities
{
    public class Book : IComparable<Book>, IComparable
    {
        public int Pages { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int CompareTo(Book other) => this.Pages - other.Pages;

        public int CompareTo(object obj)
        {
            if (!(obj is Book book))
            {
                throw new InvalidOperationException("Can't compare with book!");
            }

            return CompareTo((Book)obj);
        }
    }
}
