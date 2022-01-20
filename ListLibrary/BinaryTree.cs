using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> _root;
        private int _size;

        public int Count => _size;
        public int Height => GetHeight(_root);

        public IEnumerator<T> GetEnumerator()
        {
            return Enumerate(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Value  to remove can't be null!");
            }

            Node<T> before = null;
            Node<T> after = _root;

            while (after != null)
            {
                before = after;

                if (value.CompareTo(after.Value) == -1)
                {
                    after = after.Left;

                }
                else if (value.CompareTo(after.Value) == 1)
                {
                    after = after.Right;
                }
                else
                {
                    throw new ArgumentException("Binary tree can't hold two same items!");
                }
            }

            Node<T> newNode = new Node<T> { Value = value };

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                if (value.CompareTo(before.Value) == -1)
                {
                    before.Left = newNode;
                }
                else
                {
                    before.Right = newNode;
                }
            }

            _size++;
        }
        public void Remove(T value)
        {
             if(value == null)
            {
                throw new ArgumentException("Value  to remove can't be null!");
            }
            _root = Remove(_root, value);
            _size--;
        }

        private Node<T> Remove(Node<T> parent, T element)
        {
            if (parent == null)
            {
                return parent;
            }

            if (element.CompareTo(parent.Value) == -1)
            {
                parent.Left = Remove(parent.Left, element);
            }
            else if (element.CompareTo(parent.Value) == 1)
                parent.Right = Remove(parent.Right, element);
            else
            {
                if (parent.Left == null)
                {
                    return parent.Right;
                }
                else if (parent.Right == null)
                {
                    return parent.Left;
                }

                Node<T> temp = parent.Right;
                T minv = temp.Value;

                while (temp.Left != null)
                {
                    minv = temp.Left.Value;
                    temp = temp.Left;
                }

                parent.Value = minv;
                parent.Right = Remove(parent.Right, parent.Value);
            }

            return parent;
        }

        private int GetHeight(Node<T> parent)
        {
            int result = 0;

            if (parent != null)
            {
                result = Math.Max(GetHeight(parent.Left), GetHeight(parent.Right)) + 1;
            }
            return result;
        }

        private IEnumerable<T> Enumerate(Node<T> root)
        {
            if (root == null)
                yield break;

            yield return root.Value;

            foreach (var value in Enumerate(root.Left))
                yield return value;

            foreach (var value in Enumerate(root.Right))
                yield return value;
        }
    }
}
