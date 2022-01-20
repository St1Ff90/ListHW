using NUnit.Framework;
using ListLibrary;
using System;

namespace Tests
{
    [TestFixture(typeof(MyArrayList<int>))]
    [TestFixture(typeof(MyLinkedList<int>))]
    public class ListRemoveMethodsTests<T> where T : IMyList<int>, new()
    {
        IMyList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 0 }, new int[0])]
        public void RemoveBack_WhenSizeIsBiggerZero_ShouldRemoveLastItem(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveBack();

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 0 }, new int[0])]
        public void RemoveFront_WhenSizeIsBiggerZero_ShouldRemoveFirsttItem(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveFront();

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 0 }, 0, new int[0])]

        public void RemoveAt_WhenSizeAndIndexIsBiggerZeroAndIndexIsLessSize_ShouldRemoveItemByIndex(int[] sourceArray, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveAt(index);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAt_WhenIndexLessZeroOrBiggerThanSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 0 });

                instance.RemoveAt(index);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong index", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 0 }, 1, new int[0])]
        public void RemoveManyBack_WhenSizeIsBiggerThanQuantity_ShouldRemoveLastPointedItems(int[] sourceArray, int quantity, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveBack(quantity);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void RemoveManyBack_WhenSizeIsNotBiggerThanQuantity_ShouldThrowArgumentException()
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                _list.RemoveBack(2);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4 })]
        [TestCase(new int[] { 0 }, 1, new int[0])]
        public void RemoveManyFront_WhenSizeIsBiggerThanQuantity_ShouldRemoveFromStartPointedItems(int[] sourceArray, int quantity, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveFront(quantity);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void RemoveManyFront_WhenSizeIsNotBiggerThanQuantity_ShouldThrowArgumentException()
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                _list.RemoveFront(2);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 2, new int[] { 1, 4 })]
        [TestCase(new int[] { 2 }, 0, 1, new int[0])]
        public void RemoveManyAt_WhenSizeIsNotBiggerThanQuantityAndIndexIsLessSize_ShouldRemoveQuantityOfItemsStartFromIndex(int[] sourceArray, int index, int quantity, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveAt(index, quantity);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveManyAt_WhenIndexLessZeroOrBiggerThanSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                instance.RemoveAt(index, 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong index setted", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2 }, 2, new int[0])]
        public void Remove_WhenElementIsNotNullAndSizeIsNotZero_ShouldRemovePointedElement(int[] sourceArray, int elemeent, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.Remove(elemeent);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void Remove_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.Remove(0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 2, new int[] { 1, 3 })]
        [TestCase(new int[] { 2, 2, 2 }, 2, new int[0])]
        public void RemoveAll_WhenElementIsNotNullAndSizeIsNotZero_ShouldRemovePointedElement(int[] sourceArray, int elemeent, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveAll(elemeent);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void RemoveAll_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.RemoveAll(0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}