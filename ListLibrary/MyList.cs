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



        /*
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Index is out of range");
            }


            ICollection<T> c = collection as ICollection<T>;
            if (c != null)
            {    // if collection is ICollection<T>
                int count = c.Count;
                if (count > 0)
                {
                    EnsureCapacity(_size + count);
                    if (index < _size)
                    {
                        Array.Copy(_items, index, _items, index + count, _size - index);
                    }

                    // If we're inserting a List into itself, we want to be able to deal with that.
                    if (this == c)
                    {
                        // Copy first part of _items to insert location
                        Array.Copy(_items, 0, _items, index, index);
                        // Copy last part of _items back to inserted location
                        Array.Copy(_items, index + count, _items, index * 2, _size - index);
                    }
                    else
                    {
                        T[] itemsToInsert = new T[count];
                        c.CopyTo(itemsToInsert, 0);
                        itemsToInsert.CopyTo(_items, index);
                    }
                    _size += count;
                }
            }
            else
            {
                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Insert(index++, en.Current);
                    }
                }
            }
            _version++;
        }
        */


        /*
      public MyList(IEnumerable<T> collection)
      {
          if (collection == null)
          {
              throw new ArgumentException("Collection can't be null");
          }

          ICollection<T> c = collection as ICollection<T>;
          if (c != null)
          {
              int count = c.Count;
              if (count == 0)
              {
                  _items = _emptyArray;
              }
              else
              {
                  _items = new T[count];
                  c.CopyTo(_items, 0);
                  _size = count;
              }
          }
          else
          {
              _size = 0;
              _items = _emptyArray;
              // This enumerable could be empty.  Let Add allocate a new array, if needed.
              // Note it will also go to _defaultCapacity first, not 1, then 2, etc.

              using (IEnumerator<T> en = collection.GetEnumerator())
              {
                  while (en.MoveNext())
                  {
                      Add(en.Current);
                  }
              }
          }
      }
      */

    }

}
