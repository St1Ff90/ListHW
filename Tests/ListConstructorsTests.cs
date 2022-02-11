using NUnit.Framework;
using ListLibrary;
using System;

namespace Tests
{
    [TestFixture(typeof(MyArrayList<int>))]
    [TestFixture(typeof(MyLinkedList<int>))]
    [TestFixture(typeof(MyDoublyLinkedList<int>))]
    public class ListConstructorsTests<T> where T : IMyList<int>, new()
    {
        IMyList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [Test]
        public void CreateEmptyIMyList_WhenAny_ShpuldCreateIMyListWithCountIsZero()
        {
            Assert.AreEqual(_list.Count, 0);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 0);
            }
        }

        [Test]
        public void CreateIMyListFromOneElemeent_WhenElementIsNotNull_ShpuldCreateIMyListWithCountIsOne()
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), 1);

            Assert.AreEqual(_list.Count, 1);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 1);
            }
        }

        [TestCase(new int[] { 1, 2, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 })]
        public void CreateIMyListFromOtherIMyList_WhenAny_ShouldCreateTheSameList(int[] expeectedResult)
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), expeectedResult);

            Assert.AreEqual(_list.Count, expeectedResult.Length);
            for (int i = 0; i < _list.Count; i++)
            {
                Assert.AreEqual(_list[i], expeectedResult[i]);
            }
        }
    }
}