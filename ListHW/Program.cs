using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var two = new MyArrayList<int>() { 1, 9, 3, 14, };


            //two.AddByIndex(2, one);
            two.SortByAsc();
            two.SortByDesc();

            /*
            myList.AddByIndex(0, myLis2t);


            myList.AddFront(99);
            myList.AddByIndex(0, 999);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            */
        }
    }
}
