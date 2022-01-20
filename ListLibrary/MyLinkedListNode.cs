using System;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class MyLinkedListNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }
    }
}
