using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class MyDoublyLinkedList<T> : IMyList<T> where T : IComparable<T>
    {
        private MyDoublyLinkedListNode<T> _root;
        private int _size;

        public int Count => _size;
        public int Capacity => _size;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentException("Index should be less than count and more than zero");
                }

                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentException("Index should be less than count and more than zero");
                }

                GetNodeByIndex(index).Value = value;
            }
        }

        #region Constructors and Interfaces implementation

        public MyDoublyLinkedList()
        {
        }

        public MyDoublyLinkedList(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Element can't be null");
            }

            if (element != null)
            {
                Add(element);
            }
        }

        public MyDoublyLinkedList(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentException("Elements can't be null");
            }

            foreach (var item in elements)
            {
                Add(item);
            }
        }

        public IMyList<T> CreateInstance(IEnumerable<T> items)
        {
            return new MyDoublyLinkedList<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyDoublyLinkedListNode<T> temp = _root;
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
                GetNodeByIndex(Count - 1).Next = new MyDoublyLinkedListNode<T> { Value = element };
                GetNodeByIndex(Count).Previous = GetNodeByIndex(Count - 1);
            }
            else
            {
                _root = new MyDoublyLinkedListNode<T> { Value = element };
            }

            ++_size;
        }

        public void Add(IEnumerable<T> items)
        {
            int itemIndex = 0;

            foreach (var element in items)
            {
                if (_root != null)
                {
                    GetNodeByIndex(Count - 1).Next = new MyDoublyLinkedListNode<T> { Value = element };
                    GetNodeByIndex(Count).Previous = GetNodeByIndex(Count - 1);
                }
                else
                {
                    _root = new MyDoublyLinkedListNode<T> { Value = element };
                }

                itemIndex++;
                ++_size;
            }
        }

        public void AddByIndex(int pos, T item)
        {
            if (pos < 0 || pos > Count)
            {
                throw new ArgumentException("Position should be less than count and more than zero");
            }

            if (_root != null)
            {
                GetNodeByIndex(pos - 1).Next = new MyDoublyLinkedListNode<T> { Value = item, Next = GetNodeByIndex(pos), Previous = GetNodeByIndex(pos - 1) };

                if (pos < _size)
                {
                    GetNodeByIndex(pos + 1).Previous = GetNodeByIndex(pos);
                }
            }
            else
            {
                _root = new MyDoublyLinkedListNode<T> { Value = item };
            }

            ++_size;
        }

        public void AddByIndex(int pos, IEnumerable<T> items)
        {
            if (pos < 0 || pos > Count)
            {
                throw new ArgumentException("Position should be less than count and more than zero");
            }

            int itemsCount = 0;

            foreach (var item in items)
            {
                itemsCount++;
            }

            if (itemsCount != 0)
            {
                MyDoublyLinkedListNode<T> change = GetNodeByIndex(pos);

                foreach (var item in items)
                {
                    if (_root != null && pos > 0)
                    {
                        GetNodeByIndex(pos - 1).Next = new MyDoublyLinkedListNode<T> { Value = item, Next = GetNodeByIndex(pos), Previous = GetNodeByIndex(pos - 1) };

                        if (GetNodeByIndex(pos + 1) != null)
                        {
                            GetNodeByIndex(pos + 1).Previous = GetNodeByIndex(pos);
                        }
                    }
                    else
                    {
                        _root = new MyDoublyLinkedListNode<T> { Value = item };
                    }
                    pos++;
                    ++_size;
                }

                GetNodeByIndex(pos - 1).Next = change;

                if (GetNodeByIndex(pos) != null)
                {
                    GetNodeByIndex(pos).Previous = GetNodeByIndex(pos - 1);

                }
            }
        }

        public void AddFront(T item)
        {
            if (_root != null)
            {
                MyDoublyLinkedListNode<T> newRoot = new MyDoublyLinkedListNode<T>
                {
                    Value = item,
                    Next = _root
                };

                _root = newRoot;
                GetNodeByIndex(1).Previous = GetNodeByIndex(0);
            }
            else
            {
                _root = new MyDoublyLinkedListNode<T> { Value = item };
            }

            ++_size;
        }

        public void AddFront(IEnumerable<T> items)
        {
            AddByIndex(0, items);
        }

        #endregion


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

        public void Sort(bool byAsc)
        {
            throw new NotImplementedException();
        }

        private MyDoublyLinkedListNode<T> GetNodeByIndex(int index)
        {
            MyDoublyLinkedListNode<T> temp = _root;

            if (index < 0)
            {
                temp = new MyDoublyLinkedListNode<T>();
            }

            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            return temp;
        }
    }
}
