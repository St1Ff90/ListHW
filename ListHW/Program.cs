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
                1,2,3,4,5,6,7,8,9,10
            };

           // myList.RemoveOneFromStart();

            myList.RemoveNFromIndex(9, 2);


            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
