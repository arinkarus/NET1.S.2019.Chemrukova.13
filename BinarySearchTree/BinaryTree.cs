using BinarySearchTree.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary search tree class.
    /// </summary>
    /// <typeparam name="T">Selected type.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// Comparer: default of provided.
        /// </summary>
        private IComparer<T> comparer;

        /// <summary>
        /// Tree node.
        /// </summary>
        private Node<T> root;

        #endregion

        #region Constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">Given comparer.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentException($"Comparer can't be null: {nameof(comparer)}");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            if (!(typeof(IComparable<T>).IsAssignableFrom(typeof(T)) || 
                 typeof(IComparable).IsAssignableFrom(typeof(T))))
            {
                throw new DefaultComparerNotFound($"Default comparer is not found for {nameof(T)}");
            }
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="values">Given values.</param>
        public BinarySearchTree(IEnumerable<T> values) : this()
        {
            this.AddRange(values);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="values">Given values.</param>
        /// <param name="comparer">Given comparer.</param>
        public BinarySearchTree(IEnumerable<T> values, IComparer<T> comparer) : this(comparer)
        {
            this.AddRange(values);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets if 
        /// </summary>
        public bool IsEmpty => root == null;

        #endregion

        #region Public methods

        /// <summary>
        /// Adds item to the tree.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void Add(T value)
        {
            root = this.Insert(this.root, value);
        }

        /// <summary>
        /// Adds range of items.
        /// </summary>
        /// <param name="values">Values to add to the tree.</param>
        public void AddRange(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        /// <summary>
        /// Returns true if value is in the tree.
        /// </summary>
        /// <param name="value">Selected value.</param>
        /// <returns>True if tree contains element, otherwise - false.</returns>
        public bool Contains(T value) => this.Contains(root, value);

        /// <summary>
        /// Preorder traversal.
        /// </summary>
        /// <returns>Elements as a result of traversal.<returns>
        public IEnumerable<T> PreOrder() => this.ScanPreorder(this.root);

        /// <summary>
        /// Postorder traversal.
        /// </summary>
        /// <returns>Elements as a result of traversal.<returns>
        public IEnumerable<T> PostOrder() => this.ScanPostOrder(this.root);

        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns>Elements as a result of traversal.<returns>
        public IEnumerable<T> InOrder() => this.ScanInOrder(this.root);

        public IEnumerator<T> GetEnumerator()
        {
            return this.ScanPreorder(root).GetEnumerator();
        }

        #endregion

        #region Private methods

        private bool Contains(Node<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            int comparisonResult = this.comparer.Compare(value, node.Value);
            if (comparisonResult == 0)
            {
                return true;
            }

            if (comparisonResult < 0)
            {
                return Contains(node.Left, value);
            }
            else
            {
                return Contains(node.Right, value);
            }
        }

        private Node<T> Insert(Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
                return node;
            }

            int comparisonResult = this.comparer.Compare(value, node.Value);
            if (comparisonResult < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }
  
            return node;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> ScanPreorder(Node<T> node)
        {
            yield return node.Value;
            if (node.Left != null)
            {
                foreach  (var item in ScanPreorder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach(var item in ScanPreorder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> ScanInOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in ScanInOrder(node.Left))
                {
                    yield return item;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var item in ScanInOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> ScanPostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in ScanPostOrder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in ScanPostOrder(node.Right))
                {
                    yield return item;
                }
            }

            yield return node.Value;
        }

        #endregion

        #region Node class

        /// <summary>
        /// Node for tree.
        /// </summary>
        /// <typeparam name="T">Type that is selected for tree.</typeparam>
        private class Node<T>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Node{T}"/> class.
            /// </summary>
            /// <param name="value">Data for node.</param>
            public Node(T value)
            {
                this.Value = value;
            }

            /// <summary>
            /// Gets value that node holds.
            /// </summary>
            public T Value { get; private set; }

            /// <summary>
            /// Gets or sets right node.
            /// </summary>
            public Node<T> Right { get; set; }

            /// <summary>
            /// Gets or sets left node.
            /// </summary>
            public Node<T> Left { get; set; }
        }

        #endregion
    }
}
