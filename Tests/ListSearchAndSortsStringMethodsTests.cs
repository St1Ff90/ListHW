using NUnit.Framework;
using ListLibrary;
using System;



namespace Tests
{
    [TestFixture(typeof(MyArrayList<string>))]

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
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Item", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }
        /*
        [TestCase(null)]
        public void CreateListFromOneElement_WhenElementIsNull_ShoulThrowArgumentNullException(string str)
        {
            try
            {
                _listStrings = (IMyList<string>)Activator.CreateInstance(typeof(T), str);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Item", ex.InnerException.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
        */
    }
}