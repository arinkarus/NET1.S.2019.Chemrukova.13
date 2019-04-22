using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree.Exceptions;
using NUnit.Framework;
using BinarySearchTree.Tests.TestEntities;

namespace BinarySearchTree.Tests
{
    public class BinarySearchTests
    {
        [Test]
        public void IsEmpty_NoNodesInTree_ReturnTrue()
        {
            var tree = new BinarySearchTree<string>();
            Assert.IsTrue(tree.IsEmpty);
        }

        [Test]
        public void CreateBinaryTree_ComparerNotPassed_UseDefault()
        {
            var tree = new BinarySearchTree<int>();
            Assert.IsTrue(tree != null);
        }

        [Test]
        public void CreateBinaryTree_NotComparableType_ThrowDefaultComparerNotFound() =>
            Assert.Throws<DefaultComparerNotFound>(() => new BinarySearchTree<object>());

        #region Test cases with string

        [Test]
        public void Contains_TreeContainsInteger_ReturnTrue()
        {
            var tree = new BinarySearchTree<int>();
            var array = new int[] { 1, 5, 7, 3, 10 };
            tree.AddRange(array);
            Assert.IsTrue(tree.Contains(5));
        }

        [Test]
        public void PreOrder_DescIntegerComparer_ReturnItems()
        {
            var array = new int[] { 5, 6, 3, 2, 1 };
            var actual = new int[array.Length];
            var tree = new BinarySearchTree<int>(new DescComparer());
            tree.AddRange(array);
            int i = 0;
            foreach (var item in tree.PreOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(array, actual);
        }

        [Test]
        public void PreOrder_ComparerNotPassedInt_ReturnItems()
        {
            var array = new int[] { 7, 5, 4, 6, 1, 9, 8, 10 };
            var tree = new BinarySearchTree<int>(array);
            var actual = new int[array.Length];
            var expected = new int[] { 7, 5, 4, 1, 6, 9, 8, 10 };
            int i = 0;
            foreach (var item in tree.PreOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PostOrder_ComparerNotPassedInt_ReturnItems()
        {
            var array = new int[] { 7, 5, 4, 6, 1, 9, 8, 10 };
            var tree = new BinarySearchTree<int>(array);
            var actual = new int[array.Length];
            var expected = new int[] { 1, 4, 6, 5, 8, 10, 9, 7 };
            int i = 0;
            foreach (var item in tree.PostOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InOrder_ComparerNotPassedInt_ReturnItems()
        {

            var array = new int[] { 7, 5, 4, 6, 1, 9, 8, 10 };
            var tree = new BinarySearchTree<int>(array);
            var actual = new int[array.Length];
            var expected = new int[] { 1, 4, 5, 6, 7, 8, 9, 10 };
            int i = 0;
            foreach (var item in tree.InOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region tests for string

        [Test]
        public void Contains_TreeContainsString_ReturnTrue()
        {
            var tree = new BinarySearchTree<string>
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five"
            };
            Assert.IsTrue(tree.Contains("One"));
        }

        [Test]
        public void InOrder_ComparerForString_ReturnItems()
        {
            var input = new string[] { "day", "o", "three", "four", "one hundred" };
            var tree = new BinarySearchTree<string>(input, new StringAscBylLengthComparer());
            var actual = new string[input.Length];
            int i = 0;
            foreach (var item in tree.InOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(new string[] { "o", "day", "four", "three", "one hundred" }, actual);
        }

        [Test]
        public void PreOrder_ComparerForString_ReturnItems()
        {
            var input = new string[] { "day", "o", "three", "four", "one hundred" };
            var tree = new BinarySearchTree<string>(input, new StringAscBylLengthComparer());
            var actual = new string[input.Length];
            int i = 0;
            foreach (var item in tree.PreOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(new string[] { "day",  "o", "three", "four", "one hundred" }, actual);
        }
        
        [Test]
        public void PostOrder_ComparerForString_ReturnItems()
        {
            var input = new string[] { "day", "o", "three", "four", "one hundred" };
            var tree = new BinarySearchTree<string>(input, new StringAscBylLengthComparer());
            var actual = new string[input.Length];
            int i = 0;
            foreach (var item in tree.PostOrder())
            {
                actual[i++] = item;
            }
            Assert.AreEqual(new string[] { "o", "four", "one hundred", "three", "day" }, actual);
        }

        #endregion

        #region Tests for books

        [Test]
        public void CreateTree_WithoutComparerForBooks_ReturnItems()
        {
            int[] pages = new int[5];
            var books = new Book[]
            {
                new Book { Name = "Name1", Pages = 80 },
                new Book { Name = "Name2", Pages  = 40 },
                new Book { Name = "Name3", Pages = 100 },
                new Book { Name = "Name4", Pages = 20 },
                new Book { Name = "Name4", Pages = 60 }
            };
            var tree = new BinarySearchTree<Book>(books);
            int i = 0;
            foreach (var item in tree.PostOrder())
            {
                pages[i++] = item.Pages;
            }
            int[] expected = { 20, 60, 40, 100, 80 };
            Assert.AreEqual(expected, pages);
        }

        [Test]
        public void CreateTree_ComparerByNameForBooks_ReturnItems()
        {
            var firstBook = new Book { Name = "Bob", Pages = 300 };
            var secondBook = new Book { Name = "Alex", Pages = 100 };
            var thirdBook = new Book { Name = "Daniel", Pages = 50 };
            var array = new Book[] { firstBook, secondBook, thirdBook };
            var actual = new Book[3];
            var tree = new BinarySearchTree<Book>(array, new BookByNameComparer());
            int i = 0;
            foreach (var item in tree.PostOrder())
            {
                actual[i++] = item;
            }
            CollectionAssert.AreEqual(new Book[] { secondBook, thirdBook, firstBook }, actual);
        }

        #endregion

        #region Tests for books

        [Test]
        public void CreateTree_ComparerForPoint_ReturnItems()
        {
            var firstPoint = new Point(4, 5);
            var secondPoint = new Point(3, 5);
            var thirdPoint = new Point(3, 3);
            var points = new Point[] { firstPoint, secondPoint, thirdPoint };
            var tree = new BinarySearchTree<Point>(points, new PointComparer());
            var actual = new Point[3];
            int i = 0;
            foreach (var item in tree.PostOrder())
            {
                actual[i++] = item;
            }
            CollectionAssert.AreEqual(new Point[] { thirdPoint, secondPoint, firstPoint }, actual);
        }

        #endregion
    }
}
