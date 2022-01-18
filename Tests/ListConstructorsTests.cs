using NUnit.Framework;
using ListLibrary;
using System;



namespace Tests
{
    [TestFixture(typeof(MyList<int>))]

    public class ListConstructorsTests<T> where T : IMyList<int>, new()
    {
        IMyList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [Test]
        public void CreateEmptyIMyList_WhenAny_ShpuldCreateIMyListWithCapacity4()
        {
            Assert.AreEqual(_list.Capacity, 4);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 0);
            }
        }

        [TestCase(4)]
        [TestCase(1000)]
        public void CreateEmptyIMyListObjWithCapacity_WhenCapacityOverOrFour_ShouldCreateObjWithPointedCapacoty(int capacity)
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), capacity);

            Assert.AreEqual(_list.Capacity, capacity);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 0);
            }
        }

        [TestCase(0)]
        [TestCase(3)]
        public void CreateEmptyIMyListObjWithCapacity_WhenCapacityOverOrZero_ShouldCreateObjWithCapacity4(int capacity)
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), capacity);

            Assert.AreEqual(_list.Capacity, 4);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 0);
            }
        }

        [Test]
        public void CreateEmptyIMyListObjWithCapacity_WhenCapacityLessZero_ShouldThrowArgumentException()
        {
            try
            {
                IMyList<int> list = new MyList<int>(-1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Capacity should be >= 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] CreateIMyListFromOtherIMyList = new[] { new object[] { new MyList<int> { 1, 2, 4, 5, 6, 7, 8, 9 } } };
        private static readonly object[] CreateIMyListFromOtherIMyList_2 = new[] { new object[] { new MyList<int> { 1 } } };
        [TestCaseSource("CreateIMyListFromOtherIMyList")]
        [TestCaseSource("CreateIMyListFromOtherIMyList_2")]
        public void CreateIMyListFromOtherIMyList_WhenAny_ShouldCreateTheSameList(IMyList<int> expeectedResult)
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), expeectedResult);

            Assert.AreEqual(_list.Capacity, expeectedResult.Capacity);
               for (int i = 0; i < _list.Count; i++)
            {
                Assert.AreEqual(_list[i], expeectedResult[i]);
            }
        }

       
    }
}