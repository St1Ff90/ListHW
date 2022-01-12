using System;
using System.Collections.Generic;
using ListLibrary;

namespace ListHW
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();
            myList.AddToEnd(1);
            myList.AddToEnd(2);
            myList.AddToEnd(3);
            myList[0] = 10;

            int dsds = myList[0];



            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }


            myList.AddToEnd(4);
            myList.AddByIndex(5, 3);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
