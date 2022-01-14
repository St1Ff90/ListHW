using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>
            {
                1, 2, 3, 4, 5, 6
            };


            MyList<int> newMyList = new MyList<int>() {10, 11, 12, 13 };

            myList.AddByIndex(2, newMyList);


            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
