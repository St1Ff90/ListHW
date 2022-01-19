using NUnit.Framework;
using ListLibrary;
using System;

namespace Tests
{
    [TestFixture(typeof(MyArrayList<int>))]
    [TestFixture(typeof(MyLinkedList<int>))]
    public class ListSearchAndSortsMethodsTests<T> where T : IMyList<int>, new()
    {
        IMyList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 1, 99, new int[] { 1, 99, 3, 2 })]
        [TestCase(new int[] { 2 }, 0, 99, new int[] { 99 })]
        public void SetItemByIndex_WhenIndexMoreZeroAndLessThenSize_ShouldChengeItemByIndex(int[] sourceArray, int index, int element, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance[index] = element;
            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void SetItemByIndex_WhenIndexIsZeroOrMoreThenSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });
                _list[index] = 2;
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Index should be less than count and more than zero", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 1, 2)]
        [TestCase(new int[] { 2 }, 0, 2)]
        public void GetItemByIndex_WhenIndexMoreZeroAndLessThenSize_ShouldReturnItemByIndex(int[] sourceArray, int index, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance[index];
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void GetItemByIndex_WhenIndexIsZeroOrMoreThenSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });
                int item = _list[index];
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Index should be less than count and more than zero", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 2, 1)]
        [TestCase(new int[] { 2, 2, 2 }, 2, 0)]
        public void IndexOfItem_WhenItemIsNotNullAndItemExist_ShouldReturnIndex(int[] sourceArray, int element, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance.IndexOf(element);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 5)]
        [TestCase(new int[] { 2 }, 2)]
        public void MaxItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance.Max();
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void MaxItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.Max();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 2)]
        [TestCase(new int[] { 2 }, 2)]
        public void MinItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance.Min();
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void MinItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.Min();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 1)]
        [TestCase(new int[] { 2 }, 0)]
        public void IndexOfMaxItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance.IndexOfMax();
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IndexOfMaxItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.IndexOfMax();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 0)]
        [TestCase(new int[] { 2 }, 0)]
        public void IndexOfMinItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance.IndexOfMin();
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IndexOfMinItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.IndexOfMin();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void SortByDesc_WhenAny_ShouldSortByDesc(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.SortByDesc();
            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void SortByAsc_WhenAny_ShouldSortByDesc(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.SortByAsc();
            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, new int[] { 3, 4, 5, 2 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void Reverse_WhenAny_ShouldReverseItems(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.Reverse();
            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }
    }
}