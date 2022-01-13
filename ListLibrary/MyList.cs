using System;
using System.Collections;
using System.Collections.Generic;

namespace ListLibrary
{
    public class MyList<T> : IEnumerable
    {
        private const int _defaultCapacity = 4;
        private const double _capacityRise = 1.5;

        private T[] _items;
        private int _size;

        static readonly T[] _emptyArray = new T[0];

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

        public int Count => _size;

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

            T[] newItems = new T[_items.Length + 1];
            newItems[0] = item;
            Array.Copy(_items, 0, newItems, 1, _items.Length);
            _items = newItems;
            _size++;
        }

        /// <summary>
        /// Add one item  in pointed possition.
        /// </summary>
        /// <param name="item"> item </param>
        /// <param name="pos"> position </param>

        public void AddByIndex(T item, int pos)
        {
            if (pos < 0 || pos >= _size)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }


            T[] newItems = new T[_items.Length];

            for (int i = 0; i < _size + 1; i++)
            {
                if (i < pos - 1)
                {
                    newItems[i] = _items[i];
                }
                else if (i == pos - 1)
                {
                    newItems[i] = item;
                }
                else
                {
                    newItems[i] = _items[i - 1];
                }
            }
            _size++;
            _items = newItems;
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

        public IEnumerator<T> GetEnumerator()
        {
            int currentItem = 0;
            foreach (T item in _items)
            {
                if (currentItem == _size)
                {
                    break;
                }
                else
                {
                    yield return item;
                }
                currentItem++;
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
