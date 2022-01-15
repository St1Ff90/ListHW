using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var one = new MyList<int>() {999, 988};
            var two = new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            two.Add(one);

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
