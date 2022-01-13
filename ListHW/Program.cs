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

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList[0] = 10;

            int dsds = myList[0];

            List<int> vs = new List<int>() { 1, 2 };

            myList.AddRange(new List<int> { 1, 2 });

            myList.Add(4);
            myList.AddByIndex(3, 4);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
