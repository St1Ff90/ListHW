using System;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public interface IMyList<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Add(T item); //1

        void AddFront(T item); //2

        void AddByIndex(int index, T item); //3

        void RemoveOneFromEnd(); //4

        void RemoveOneFromStart(); //5

        void RemoveAt(int index); //6

        void RemoveNFromEnd(int quantity); //7

        void RemoveNFromStart(int quantity); //8

        void RemoveNFromIndex(int index, int quantity); //9

        int Count { get; }  //10

        T this[int index] { get; set; } //11, 13

        int IndexOf(T item); //12

        void Reverse(); //14

        T Max(); //15

        T Min(); //16

        int IndexOfMax(); //17

        int IndexOfMin(); //18

        void SortByAsc(); //19

        void SortByDesc(); //20

        int Remove(T element); //21

        int RemoveAll(T element); //22

        // Constructors //23

        void Add(MyList<T> items); // 24

        void AddFront(MyList<T> items); //25

        void AddByIndex(int index, MyList<T> items); //26
    }
}
