using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var two = new MyArrayList<string>(null as string);


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
