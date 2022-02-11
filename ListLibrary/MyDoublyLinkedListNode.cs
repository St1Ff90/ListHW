using System;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class MyDoublyLinkedListNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public MyDoublyLinkedListNode<T> Next { get; set; }
        public MyDoublyLinkedListNode<T> Previous { get; set; }

    }
}
