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
                3,2,3,4,5,10,2,8,9,10
            };

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
