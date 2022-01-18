using NUnit.Framework;
using ListLibrary;
using System;



namespace Tests
{
    [TestFixture(typeof(MyList<string>))]

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
                var insetance = _listStrings.CreateInstance(new MyList<string>());
                insetance.IndexOf(null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Item", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}