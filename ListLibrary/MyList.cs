using System;
using System.Collections;
using System.Collections.Generic;

namespace ListLibrary
{
    public class MyList<T> : IMyList<T>, IEnumerable<T> where T : IComparable<T>
    {
        private const int _defaultCapacity = 4;
        private const double _capacityRise = 1.33;

        private T[] _items;
        private int _size;

        static readonly T[] _emptyArray = new T[0];


        #region Constructors, Propeerties and Interfaces implementation

        public MyList()
        {
            _items = _emptyArray;
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity should be >= 0");
            }

            if (capacity == 0)
            {
                _items = _emptyArray;

            }
            else
            {
                _items = new T[capacity];
            }
        }

        public MyList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentException("Collection can't be null");
            }

            _items = _emptyArray;

            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public int Count => _size;

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException("Capacity is too small");
                }
                else
                {
                    T[] newItems = new T[value];

                    if (_size > 0)
                    {
                        Array.Copy(_items, newItems, _size);
                    }

                    _items = newItems;

                    if (value < 0)
                    {
                        _items = _emptyArray;
                    }
                }
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

        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity;
                if (_items.Length == 0)
                {
                    newCapacity = _defaultCapacity;
                }
                else
                {
                    newCapacity = (int)(_items.Length * _capacityRise);
                }

                if (newCapacity > int.MaxValue)
                {
                    newCapacity = int.MaxValue;
                }
                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                Capacity = newCapacity;
            }
        }

        #endregion

        #region Add methods

        /// <summary>
        /// Add to end.
        /// </summary>
        /// <param name="item">item</param>
        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = item;
        }

        /// <summary>
        /// Add one item to the start of list.
        /// </summary>
        /// <param name="item">item</param>
        public void AddToFront(T item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }

            for (int i = _size - 1; i >= 0; i--)
            {
                _items[i + 1] = _items[i];
            }

            _items[0] = item;
            _size++;
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
                EnsureCapacity(_size + 1);
            }

            for (int i = _size; i > 0; i--)
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
            var newSize = _size + items.Count;
            if (newSize >= _items.Length)
            {
                EnsureCapacity(newSize);
            }

            for (int i = Count, j = 0; i < newSize; i++, j++)
            {
                _items[i] = items[j];
            }

            _size = newSize;
        }

        public void AddToFront(MyList<T> items)
        {

            var newSize = _size + items.Count;
            if (newSize >= _items.Length)
            {
                EnsureCapacity(newSize);
            }

            for (int i = _size - 1; i >= 0; i--)
            {
                _items[i + items.Count] = _items[i];
            }

            for (int i = 0; i < items.Count; i++)
            {
                _items[i] = items[i];
            }

            _size += items.Count;
        }

        public void AddByIndex(int pos, MyList<T> items)
        {
            var newSize = _size + items.Count;
            if (newSize >= _items.Length)
            {
                EnsureCapacity(newSize);
            }

            _size += items.Count;

            for (int i = _size - 1, j = items.Count - 1; j >= 0; i--)
            {
                if (i == pos + j)
                {
                    _items[i] = items[j];
                    j--;
                }
                else
                {
                    _items[i] = _items[i - items.Count];
                }
            }
        }

        #endregion

        #region Remove

        public void RemoveOneFromEnd()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            _size--;
        }

        public void RemoveOneFromStart()
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
            if (_size == 0 || index < 0 || index > _size)
            {
                throw new ArgumentOutOfRangeException("Size");
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

        public void RemoveNFromEnd(int quantity)
        {
            if (_size < quantity)
            {
                throw new ArgumentOutOfRangeException("Size");
            }

            _size -= quantity;
        }

        public void RemoveNFromStart(int quantity)
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

        public void RemoveNFromIndex(int index, int quantity)
        {
            if (_size < quantity + index || index < 0 || index + quantity > _size)
            {
                throw new ArgumentOutOfRangeException("Size");
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
                if (_items == element)
                {
                    return i;
                }
            }
            return -1;
        }

        public int RemoveAll(T elements)
        {
            throw new NotImplementedException();
        }

        #endregion




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










    }

}
