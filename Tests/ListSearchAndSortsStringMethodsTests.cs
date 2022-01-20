using NUnit.Framework;
using ListLibrary;
using System;

namespace Tests
{
    [TestFixture(typeof(MyArrayList<string>))]
    [TestFixture(typeof(MyLinkedList<string>))]
    public class ListSearchAndSortsStringMethodsTests<T> where T : IMyList<string>, new()
    {
        IMyList<string> _listStrings;

        [SetUp]
        public void Setup()
        {
            _listStrings = new T();
        }

        [Test]
        public void IndexOfItem_WhenItemIsNull_ShouldThrowArgumentNullException()
        {
            try
            {
                var insetance = _listStrings.CreateInstance(new MyArrayList<string>());

                insetance.IndexOf(null);
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