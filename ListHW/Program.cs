using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDoublyLinkedList<int> vs = new MyDoublyLinkedList<int>();
            vs.Add(1);
            vs.Add(2);
            vs.AddByIndex(2, 3);
            int[] ints = new int[3] { 4, 5, 6 };
            vs.Add(ints);
            int[] ints2 = new int[3] { 44, 445, 543 };
            vs.AddByIndex(3, ints2);



        }
    }
}
