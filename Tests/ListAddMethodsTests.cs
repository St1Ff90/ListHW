using NUnit.Framework;
using ListLibrary;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture(typeof(MyArrayList<int>))]
    [TestFixture(typeof(MyLinkedList<int>))]
    public class ListAddMethodsTests<T> where T : IMyList<int>, new()
    {

        IMyList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 3 })]
        public void Add_WhenAny_ShouldAddItemToEnd(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.Add(3);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 1, 2 })]
        [TestCase(new int[] { }, new int[] { 3 })]
        public void AddFront_WhenAny_ShouldAddFront(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddFront(3);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }





        private static readonly object[] AddByIndex_1 = new[] { new object[] { new int[] { 1, 2 }, 1, new int[] { 1, 3, 2 } } };
        private static readonly object[] AddByIndex_2 = new[] { new object[] { new int[] { 1, 2 }, 2, new int[] { 1, 2, 3 } } };
        [TestCaseSource("AddByIndex_1")]
        [TestCaseSource("AddByIndex_2")]
        [TestCase(new int[] { }, 0, new int[] { 3 })]
        public void AddByIndex_WhenIndexIsNotLessZeroOrIndexMoreThenSize_WhenAny_ShouldAddFront(int[] sourceArray, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddByIndex(index, 3);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void AddByIndex_WhenIndexLessZeroOfIndexMoreThenSize_ShouldThrowArgumentOutOfRangeException(int pos)
        {
            try
            {
                _list.AddByIndex(pos, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Position should be less than count and more than zero", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] AddMany_1 = new[] { new object[] { new int[] { 1, 2, 3 }, new List<int> { 4, 5 }, new int[] { 1, 2, 3, 4, 5 } } };
        private static readonly object[] AddMany_2 = new[] { new object[] { new int[] { }, new List<int> { 1, 2, 3 }, new int[] { 1, 2, 3 } } };
        [TestCaseSource("AddMany_1")]
        [TestCaseSource("AddMany_2")]
        public void AddMany_WhenAny_ShouldAddItemsToEnd(int[] sourceArray, IEnumerable<int> additionalList, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.Add(additionalList);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        private static readonly object[] AddFrontMany_1 = new[] { new object[] { new int[] { 1, 2, 3 }, new List<int> { 4, 5 }, new int[] { 4, 5, 1, 2, 3 } } };
        private static readonly object[] AddFrontMany_2 = new[] { new object[] { new int[0], new List<int> { 1, 2, 3 }, new int[] { 1, 2, 3 } } };
        [TestCaseSource("AddFrontMany_1")]
        [TestCaseSource("AddFrontMany_2")]
        public void AddManyFront_WhenAny_ShouldAddItemsToFront(int[] sourceArray, IEnumerable<int> additionalList, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddFront(additionalList);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        private static readonly object[] AddManyFromIndex_1 = new[] { new object[] { new int[0], 0, new List<int> { 1, 2, 3 }, new int[] { 1, 2, 3 } } };
        private static readonly object[] AddManyFromIndex_2 = new[] { new object[] { new int[] { 1, 2, 3 }, 3, new List<int> { 4, 5 }, new int[] { 1, 2, 3, 4, 5 } } };
        private static readonly object[] AddManyFromIndex_3 = new[] { new object[] { new int[] { 1, 2, 3 }, 2, new List<int> { 9, 8, 7 }, new int[] { 1, 2, 9, 8, 7, 3 } } };
        private static readonly object[] AddManyFromIndex_4 = new[] { new object[] { new int[0], 0, new List<int> { }, new int[] { } } };
        private static readonly object[] AddManyFromIndex_5 = new[] { new object[] { new int[] { 1, 2, 3 }, 0, new List<int>(), new int[] { 1, 2, 3 } } };
        [TestCaseSource("AddManyFromIndex_1")]
        [TestCaseSource("AddManyFromIndex_2")]
        [TestCaseSource("AddManyFromIndex_3")]
        [TestCaseSource("AddManyFromIndex_4")]
        [TestCaseSource("AddManyFromIndex_5")]
        public void AddManyFromIndex_WhenAny_ShouldAddItemsToFront(int[] sourceArray, int index, IEnumerable<int> additionalList, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddByIndex(index, additionalList);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void AddManyByIndex_WhenIndexLessZeroOfIndexMoreThenSize_ShouldThrowArgumentOutOfRangeException(int pos)
        {
            try
            {
                _list.AddByIndex(pos, new List<int>());
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Position should be less than count and more than zero", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}