using NUnit.Framework;
using ListLibrary;
using System;



namespace Tests
{
    [TestFixture(typeof(MyList<string>))]

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
                var insetance = _listStrings.CreateInstance(new MyList<string>());
                insetance.Remove(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Item can't be null", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RemoveAll_WhenElementIsNull_ShouldThrowArgumentNullException()
        {
            try
            {
                IMyList<string> list = new MyList<string>() { "1" };
                list.Remove(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Item can't be null", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}