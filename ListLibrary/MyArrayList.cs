using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListLibrary
{
    public class MyArrayList<T> : IMyList<T> where T : IComparable<T>
    {
        private const int _defaultCapacity = 4;
        private const double _capacityRise = 1.33;
        private T[] _items;
        private int _size;

        public int Count => _size;
        public int Capacity => _items.Length;
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentException("Index should be less than count and more than zero");
                }

                return _items[index];
            }

            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentException("Index should be less than count and more than zero");
                }

                _items[index] = value;
            }
        }

        #region Constructors and Interfaces implementation

        public MyArrayList()
        {
            _items = new T[_defaultCapacity];
        }

        public MyArrayList(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Element can't be null");
            }

            _items = new T[_defaultCapacity];
            Add(element);
        }

        public MyArrayList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentException("Elements can't be null");
            }

            T[] tempArr = collection.ToArray();
            _items = new T[_defaultCapacity];
            UpdateCapacity(tempArr.Length);
            _size += tempArr.Length;

            for (int i = 0; i < tempArr.Length; i++)
            {
                _items[i] = tempArr[i];
            }
        }

        public IMyList<T> CreateInstance(IEnumerable<T> items)
        {
            return new MyArrayList<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Add methods

        /// <summary>
        /// Add to end.
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            AddByIndex(Count, item);
        }

        /// <summary>
        /// Add one item to the start of list.
        /// </summary>
        /// <param name="item">item</param>
        public void AddFront(T item)
        {
            AddByIndex(0, item);
        }

        /// <summary>
        /// Add one item  in pointed possition.
        /// </summary>
        /// <param name="item"> item </param>
        /// <param name="pos"> position </param>
        public void AddByIndex(int pos, T item)
        {
            if (pos < 0 || pos > Count)
            {
                throw new ArgumentException("Position should be less than count and more than zero");
            }

            if (Count == _items.Length)
            {
                UpdateCapacity(Count + 1);
            }

            if (Count > 0 && pos < Count)
            {
                for (int i = Count; i > pos; i--)
                {
                    _items[i] = _items[i - 1];
                }
            }

            _items[pos] = item;
            _size++;
        }

        public void Add(IEnumerable<T> items)
        {
            AddByIndex(Count, items);
        }

        public void AddFront(IEnumerable<T> items)
        {
            AddByIndex(0, items);
        }

        public void AddByIndex(int pos, IEnumerable<T> items)
        {
            if (pos < 0 || pos > Count)
            {
                throw new ArgumentException("Position should be less than count and more than zero");
            }

            int itemsCount = items.ToArray().Count();

            if (itemsCount > 0)
            {
                var newSize = Count + itemsCount;

                if (newSize >= _items.Length)
                {
                    UpdateCapacity(newSize);
                }

                for (int i = Count - 1; i >= pos; i--)
                {
                    _items[i + itemsCount] = _items[i];
                }

                foreach (T item in items)
                {
                    _items[pos++] = item;
                }

                _size = newSize;
            }
        }

        #endregion

        #region Remove

        public void RemoveBack()
        {
            RemoveAt(Count - 1);
        }

        public void RemoveFront()
        {
            RemoveAt(0);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException("Wrong index");
            }

            _size--;

            for (int i = 0; i < Count; i++)
            {
                if (i >= index)
                {
                    _items[i] = _items[i + 1];
                }
            }
        }

        public void RemoveBack(int quantity)
        {
            if (Count < quantity)
            {
                throw new ArgumentException("Size is 0");
            }

            _size -= quantity;
        }

        public void RemoveFront(int quantity)
        {
            if (Count < quantity)
            {
                throw new ArgumentException("Size is 0");
            }

            _size -= quantity;

            for (int i = 0; i < Count; i++)
            {
                _items[i] = _items[i + quantity];
            }
        }

        public void RemoveAt(int index, int quantity)
        {
            if (Count < quantity + index || index < 0)
            {
                throw new ArgumentException("Wrong index setted");
            }

            _size -= quantity;

            for (int i = 0; i < Count; i++)
            {
                if (i >= index)
                {
                    _items[i] = _items[i + quantity];
                }
            }
        }

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
                if (_items[i].Equals(element))
                {
                    RemoveAt(i);
                    result = i;
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
                if (_items[i].Equals(element))
                {
                    RemoveAt(i--);
                    result++;
                }
            }

            return result;
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
                if (_items[i].Equals(item))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public T Max()
        {
            return _items[IndexOfMax()];
        }

        public T Min()
        {
            return _items[IndexOfMin()];
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
                if (_items[i].CompareTo(_items[result]) == 1)
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
                if (_items[i].CompareTo(_items[result]) == -1)
                {
                    result = i;
                }
            }

            return result;
        }

        public void Sort(bool byAsc)
        {
            int type = byAsc ? 1 : -1;
            T x;
            int j;

            for (int i = 1; i < Count; i++)
            {
                x = _items[i];
                j = i;
                while (j > 0 && _items[j - 1].CompareTo(x) == type)
                {
                    Swap(ref _items[j], ref _items[j - 1]);
                    j -= 1;
                }

                _items[j] = x;
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                Swap(ref _items[i], ref _items[Count - 1 - i]);
            }
        }

        #endregion

        #region Private methods

        private void UpdateCapacity(int min)
        {
            if (min < Count)
            {
                throw new ArgumentException("Capacity shouldn't be resized!");
            }

            if (_items.Length < min)
            {
                int newCapacity = (int)(_items.Length * _capacityRise);

                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                T[] newItems = new T[newCapacity];

                if (Count > 0)
                {
                    Array.Copy(_items, newItems, Count);
                }

                _items = newItems;
            }
        }

        private void Swap(ref T i, ref T j)
        {
            T temp = i;
            i = j;
            j = temp;
        }

        #endregion

    }
}
