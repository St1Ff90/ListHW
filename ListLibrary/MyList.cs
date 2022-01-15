using System;
using System.Collections;
using System.Collections.Generic;

namespace ListLibrary
{
    public class MyList<T> : IMyList<T> where T : IComparable<T>
    {
        private const int _defaultCapacity = 4;
        private const double _capacityRise = 1.33;

        private T[] _items;
        private int _size;

        public int Count => _size;

        public int Capacity => _items.Length;

        #region Constructors and Interfaces implementation

        public MyList()
        {
            _items = new T[_defaultCapacity];
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity should be >= 0");
            }

            if (capacity >= 0 && capacity < 4)
            {
                _items = new T[_defaultCapacity];
            }
            else
            {
                _items = new T[capacity];
            }
        }

        public MyList(IEnumerable<T> collection)
        {
            _items = new T[_defaultCapacity];

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
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
            AddByIndex(_size, item);
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
            if (pos < 0 || pos > _size)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            if (_size == _items.Length)
            {
                UpdateCapacity(_size + 1);
            }

            for (int i = _size; i >= 0; i--)
            {
                if (i == pos)
                {
                    _items[i] = item;
                    break;
                }
                else
                {
                    _items[i] = _items[i - 1];
                }
            }

            _size++;
        }

        public void Add(MyList<T> items)
        {
            AddByIndex(_size, items);
        }

        public void AddFront(MyList<T> items)
        {
            AddByIndex(0, items);
        }

        public void AddByIndex(int pos, MyList<T> items)
        {
            if (pos < 0 || pos > _size)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            var newSize = _size + items.Count;

            if (newSize >= _items.Length)
            {
                UpdateCapacity(newSize);
            }

            for (int i = _size - 1; i >= pos; i--)
            {
                _items[i + items.Count] = _items[i];
            }

            for (int i = pos; i < items.Count + pos; i++)
            {
                _items[i] = items[i - pos];
            }

            _size = newSize;
        }

        #endregion

        #region Remove

        public void RemoveBack()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            _size--;
        }

        public void RemoveFront()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            _size--;

            for (int i = 0; i < _size; i++)
            {
                _items[i] = _items[i + 1];
            }
        }

        public void RemoveAt(int index)
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            if (index < 0 || index > _size)
            {
                throw new ArgumentException("Wrong index");
            }

            _size--;

            for (int i = 0; i < _size; i++)
            {
                if (i >= index)
                {
                    _items[i] = _items[i + 1];
                }
            }
        }

        public void RemoveBack(int quantity)
        {
            if (_size < quantity)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            _size -= quantity;
        }

        public void RemoveFront(int quantity)
        {
            if (_size < quantity)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            _size -= quantity;

            for (int i = 0; i < _size; i++)
            {
                _items[i] = _items[i + quantity];
            }
        }

        public void RemoveAt(int index, int quantity)
        {
            if (_size == 0 || index + quantity > _size)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            if (_size < quantity + index || index < 0)
            {
                throw new ArgumentException("Wrong index setted");
            }

            _size -= quantity;

            for (int i = 0; i < _size; i++)
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
                throw new ArgumentNullException("Item can't be null");
            }

            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(element))
                {
                    RemoveAt(i);
                    result = i;
                }
            }

            return result;
        }

        public int RemoveAll(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Item can't be null");
            }

            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            int result = 0;

            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(element))
                {
                    RemoveAt(i);
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
                throw new ArgumentNullException("Item");
            }

            int result = -1;

            for (int i = 0; i < _size; i++)
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
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            T result = _items[0];

            for (int i = 1; i < _size; i++)
            {
                if (_items[i].CompareTo(result) == 1)
                {
                    result = _items[i];
                }
            }

            return result;
        }

        public T Min()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            T result = _items[0];

            for (int i = 1; i < _size; i++)
            {
                if (_items[i].CompareTo(result) == -1)
                {
                    result = _items[i];
                }
            }

            return result;
        }

        public int IndexOfMax()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            int result = 0;

            for (int i = 1; i < _size; i++)
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
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            int result = 0;

            for (int i = 1; i < _size; i++)
            {
                if (_items[i].CompareTo(_items[result]) == -1)
                {
                    result = i;
                }
            }

            return result;
        }

        public void SortByDesc()
        {
            Sort(-1);
        }

        public void SortByAsc()
        {
            Sort(1);
        }

        #endregion

        #region Other

        public void Reverse()
        {
            for (int i = 0; i < _size / 2; i++)
            {
                Swap(ref _items[i], ref _items[_size - 1 - i]);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= _size || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }

                return _items[index];
            }

            set
            {
                if (index >= _size || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range" + _size);
                }

                _items[index] = value;
            }
        }

        #endregion

        private void UpdateCapacity(int min)
        {
            if (min < _size)
            {
                throw new ArgumentOutOfRangeException("Capacity is too small");
            }

            if (_items.Length < min)
            {
                int newCapacity = (int)(_items.Length * _capacityRise);

                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                T[] newItems = new T[newCapacity];

                if (_size > 0)
                {
                    Array.Copy(_items, newItems, _size);
                }

                _items = newItems;

                if (newCapacity < 0)
                {
                    _items = new T[_defaultCapacity];
                }
            }
        }

        private void Sort(int type)
        {
            T x;
            int j;

            for (int i = 1; i < _size; i++)
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

        private void Swap(ref T i, ref T j)
        {
            T temp = i;
            i = j;
            j = temp;
        }
    }
}
