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

        #region Remove

        public int Remove(T element)
        {
            int result = -1;

            if (element == null)
            {
                throw new ArgumentException("Item can't be null");
            }

            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            for (int i = 0; i < Count; i++)
            {
                if (GetNodeByIndex(i).Value.Equals(element))
                {
                    GetNodeByIndex(i - 1).Next = GetNodeByIndex(i + 1);

                    if (GetNodeByIndex(i + 1) != null)
                    {
                        GetNodeByIndex(i + 1).Previous = GetNodeByIndex(i - 1);
                    }

                    result = i;
                    _size--;
                    break;
                }
            }

            return result;
        }

        public int RemoveAll(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Item can't be null");
            }

            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            int result = 0;

            for (int i = 0; i < Count; i++)
            {
                if (GetNodeByIndex(i).Value.Equals(element))
                {
                    GetNodeByIndex(i - 1).Next = GetNodeByIndex(i + 1);

                    if (GetNodeByIndex(i) != null)
                    {
                        GetNodeByIndex(i).Previous = GetNodeByIndex(i - 1);
                    }

                    i--;
                    _size--;
                }
            }

            return result;
        }

        public void RemoveAt(int index)
        {
            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentException("Wrong index");
            }

            GetNodeByIndex(index - 1).Next = GetNodeByIndex(index + 1);

            if (GetNodeByIndex(index) != null)
            {
                GetNodeByIndex(index).Previous = GetNodeByIndex(index - 1);
            }

            --_size;
        }

        public void RemoveAt(int index, int quantity)
        {
            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            if (Count < quantity + index || index < 0)
            {
                throw new ArgumentException("Wrong index setted");
            }

            GetNodeByIndex(index - 1).Next = GetNodeByIndex(index + quantity);

            if (GetNodeByIndex(index + quantity - 1) != null)
            {
                GetNodeByIndex(index + quantity - 1).Previous = GetNodeByIndex(index - 1);
            }

            _size -= quantity;
        }

        public void RemoveBack()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            _size--;
            GetNodeByIndex(Count - 1).Next = null;
        }

        public void RemoveBack(int quantity)
        {
            if (Count < quantity)
            {
                throw new ArgumentException("Size is 0");
            }

            GetNodeByIndex(Count - quantity - 1).Next = null;
            _size -= quantity;
        }

        public void RemoveFront()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            _root = GetNodeByIndex(1);
            _size--;
        }

        public void RemoveFront(int quantity)
        {
            if (Count < quantity)
            {
                throw new ArgumentException("Size is 0");
            }

            _root = GetNodeByIndex(quantity);
            _size -= quantity;
        }

        #endregion

        #region Search and Sort

        public int IndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item can't be null");
            }

            int result = -1;

            for (int i = 0; i < Count; i++)
            {
                if (GetNodeByIndex(i).Value.Equals(item))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public int IndexOfMax()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            int result = 0;

            for (int i = 1; i < Count; i++)
            {
                if (GetNodeByIndex(i).Value.CompareTo(GetNodeByIndex(result).Value) == 1)
                {
                    result = i;
                }
            }

            return result;
        }

        public int IndexOfMin()
        {
            if (Count == 0)
            {
                throw new ArgumentException("Size is 0");
            }

            int result = 0;

            for (int i = 1; i < Count; i++)
            {
                if (GetNodeByIndex(i).Value.CompareTo(GetNodeByIndex(result).Value) == -1)
                {
                    result = i;
                }
            }

            return result;
        }

        public T Max()
        {
            return this[IndexOfMax()];
        }

        public T Min()
        {
            return this[IndexOfMin()];
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                Swap(i, Count - 1 - i);
            }
        }

        public void Sort(bool byAsc)
        {
            int type = byAsc ? 1 : -1;
            T x;
            int j;

            for (int i = 1; i < Count; i++)
            {
                x = GetNodeByIndex(i).Value;
                j = i;
                while (j > 0 && GetNodeByIndex(j - 1).Value.CompareTo(x) == type)
                {
                    Swap(j, j - 1);
                    j -= 1;
                }

                GetNodeByIndex(j).Value = x;
            }
        }

        #endregion

        #region Private methods

        private void Swap(int i, int j)
        {
            T temp = GetNodeByIndex(i).Value;
            GetNodeByIndex(i).Value = GetNodeByIndex(j).Value;
            GetNodeByIndex(j).Value = temp;
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

        #endregion

    }
}
