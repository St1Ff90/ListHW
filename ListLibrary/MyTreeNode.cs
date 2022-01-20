using System;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public class MyTreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public MyTreeNode<T> Left { get; set; }
        public MyTreeNode<T> Right { get; set; }
    }
}
