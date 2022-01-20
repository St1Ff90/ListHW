using System;
using System.Collections.Generic;
using System.Text;

namespace ListLibrary
{
    public interface IMyList<T> : IEnumerable<T> 
    {
        void Add(T item); //1

        void AddFront(T item); //2

        void AddByIndex(int index, T item); //3

        void RemoveBack(); //4

        void RemoveFront(); //5

        void RemoveAt(int index); //6

        void RemoveBack(int quantity); //7

        void RemoveFront(int quantity); //8

        void RemoveAt(int index, int quantity); //9

        int Count { get; }  //10

        int Capacity { get; }  //10

        T this[int index] { get; set; } //11, 13

        int IndexOf(T item); //12

        void Reverse(); //14

        T Max(); //15

        T Min(); //16

        int IndexOfMax(); //17

        int IndexOfMin(); //18

        void Sort(bool byAsc); //19

        int Remove(T element); //21

        int RemoveAll(T element); //22

        // Constructors //23

        void Add(IEnumerable<T> items); // 24

        void AddFront(IEnumerable<T> items); //25

        void AddByIndex(int index, IEnumerable<T> items); //26

        IMyList<T> CreateInstance(IEnumerable<T> items);

    }
}
