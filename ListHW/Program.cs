using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var one = new MyList<int>() {999, 7};
            var two = new MyList<int>() { 1, 9, 3, 14, };
            two.AddByIndex(0, one);
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
