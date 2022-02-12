using NUnit.Framework;
using ListLibrary;
using System;

namespace Tests
{
    [TestFixture(typeof(MyArrayList<string>))]
    [TestFixture(typeof(MyLinkedList<string>))]
    [TestFixture(typeof(MyDoublyLinkedList<string>))]
    public class ListRemoveStringsMethodsTests<T> where T : IMyList<string>, new()
    {
        IMyList<string> _listStrings;

        [SetUp]
        public void Setup()
        {
            _listStrings = new T();
        }

        [Test]
        public void Remove_WhenElementIsNull_ShouldThrowArgumentNullException()
        {
            try
            {
                var insetance = _listStrings.CreateInstance(new MyArrayList<string>());

                insetance.Remove(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Item can't be null", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RemoveAll_WhenElementIsNull_ShouldThrowArgumentNullException()
        {
            try
            {
                _listStrings.Remove(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Item can't be null", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}