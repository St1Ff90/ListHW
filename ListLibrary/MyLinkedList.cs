using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class MyLinkedList<T> : IMyList<T> where T : IComparable<T>
    {
        private Node<T> _root;
        private int _size;

        public int Count => _size;
        public int Capacity => _size;

        #region Constructors and Interfaces implementation

        public MyLinkedList()
        {
        }

        public MyLinkedList(T element)
        {
            if (element != null)
            {
                Add(element);
            }
        }

        public MyLinkedList(IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = _root;
            for (int i = 0; i < Count; i++)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Add methods

        public void Add(T element)
        {
            if (_root != null)
            {
                GetNodeByIndex(Count - 1).Next = new Node<T> { Value = element };
            }
            else
            {
                _root = new Node<T> { Value = element };
            }

            ++_size;
        }

        public void AddFront(T item)
        {
            if (_root != null)
            {
                Node<T> newRoot = new Node<T>
                {
                    Value = item,
                    Next = _root
                };

                _root = newRoot;
            }
            else
            {
                _root = new Node<T> { Value = item };
            }

            ++_size;
        }

        public void AddByIndex(int index, T item)
        {
            if (_root != null)
            {
                GetNodeByIndex(index - 1).Next = new Node<T> { Value = item, Next = GetNodeByIndex(index) };
            }
            else
            {
                _root = new Node<T> { Value = item };
            }

            ++_size;
        }

        public void Add(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void AddFront(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        #endregion

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }

                GetNodeByIndex(index).Value = value;
            }
        }






        public IMyList<T> CreateInstance(IEnumerable<T> items)
        {
            return new MyLinkedList<T>(items);
        }



        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public int IndexOfMax()
        {
            throw new NotImplementedException();
        }

        public int IndexOfMin()
        {
            throw new NotImplementedException();
        }

        public T Max()
        {
            throw new NotImplementedException();
        }

        public T Min()
        {
            throw new NotImplementedException();
        }

        public int Remove(T element)
        {
            throw new NotImplementedException();
        }

        public int RemoveAll(T element)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index, int quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveBack()
        {
            throw new NotImplementedException();
        }

        public void RemoveBack(int quantity)
        {
            throw new NotImplementedException();
        }

        public void RemoveFront()
        {
            throw new NotImplementedException();
        }

        public void RemoveFront(int quantity)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void SortByAsc()
        {
            throw new NotImplementedException();
        }

        public void SortByDesc()
        {
            throw new NotImplementedException();
        }



        private Node<T> GetNodeByIndex(int index)
        {
            Node<T> temp = _root;
            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            return temp;
        }
    }
}
