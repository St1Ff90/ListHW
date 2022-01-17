using NUnit.Framework;
using ListLibrary;
using System;


namespace Tests
{
    public class ListTests
    {
        #region Constructors

        [Test]
        public void CreateEmptyIMyList_WhenAny_ShpuldCreateIMyListWithCapacity4()
        {
            IMyList<int> list = new MyList<int>();
            Assert.AreEqual(list.Capacity, 4);
            foreach (int item in list)
            {
                Assert.AreEqual(item, 0);
            }
        }

        [TestCase(4)]
        [TestCase(1000)]
        public void CreateEmptyIMyListObjWithCapacity_WhenCapacityOverOrFour_ShouldCreateObjWithPointedCapacoty(int capacity)
        {
            IMyList<int> list = new MyList<int>(capacity);
            Assert.AreEqual(list.Capacity, capacity);
            foreach (int item in list)
            {
                Assert.AreEqual(item, 0);
            }
        }

        [TestCase(0)]
        [TestCase(3)]
        public void CreateEmptyIMyListObjWithCapacity_WhenCapacityOverOrZero_ShouldCreateObjWithCapacity4(int capacity)
        {
            IMyList<int> list = new MyList<int>(capacity);
            Assert.AreEqual(list.Capacity, 4);
            foreach (int item in list)
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
        public void CreateIMyListromFOtherIMyList_WhenAny_ShouldCreateTheSameList(IMyList<int> expeectedResult)
        {
            IMyList<int> list = new MyList<int>(expeectedResult);
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[i], expeectedResult[i]);
            }
        }

        #endregion

        #region Add methods

        private static readonly object[] Add_1 = new[] { new object[] { new MyList<int> { 1, 2 }, new MyList<int> { 1, 2, 3 } } };
        private static readonly object[] Add_2 = new[] { new object[] { new MyList<int>(), new MyList<int> { 3 } } };
        [TestCaseSource("Add_1")]
        [TestCaseSource("Add_2")]
        public void Add_WhenAny_ShouldAddItemToEnd(IMyList<int> list, IMyList<int> expeectedResult)
        {
            list.Add(3);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        private static readonly object[] AddFront_1 = new[] { new object[] { new MyList<int> { 1, 2 }, new MyList<int> { 3, 1, 2 } } };
        private static readonly object[] AddFront_2 = new[] { new object[] { new MyList<int>(), new MyList<int> { 3 } } };
        [TestCaseSource("AddFront_1")]
        [TestCaseSource("AddFront_2")]
        public void AddFront_WhenAny_ShouldAddFront(IMyList<int> list, IMyList<int> expeectedResult)
        {
            list.AddFront(3);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        private static readonly object[] AddByIndex_1 = new[] { new object[] { new MyList<int> { 1, 2 }, 1, new MyList<int> { 1, 3, 2 } } };
        private static readonly object[] AddByIndex_2 = new[] { new object[] { new MyList<int> { 1, 2 }, 2, new MyList<int> { 1, 2, 3 } } };
        private static readonly object[] AddByIndex_3 = new[] { new object[] { new MyList<int>(), 0, new MyList<int> { 3 } } };
        [TestCaseSource("AddByIndex_1")]
        [TestCaseSource("AddByIndex_2")]
        [TestCaseSource("AddByIndex_3")]
        public void AddByIndex_WhenIndexIsNotLessZeroOrIndexMoreThenSize_WhenAny_ShouldAddFront(IMyList<int> list, int index, IMyList<int> expeectedResult)
        {
            list.AddByIndex(index, 3);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void AddByIndex_WhenIndexLessZeroOfIndexMoreThenSize_ShouldThrowArgumentOutOfRangeException(int pos)
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.AddByIndex(pos, 0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Index is out of range", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] AddMany_1 = new[] { new object[] { new MyList<int> { 1, 2, 3 }, new MyList<int> { 4, 5 }, new MyList<int> { 1, 2, 3, 4, 5 } } };
        private static readonly object[] AddMany_2 = new[] { new object[] { new MyList<int>(), new MyList<int> { 1, 2, 3 }, new MyList<int> { 1, 2, 3 } } };
        [TestCaseSource("AddMany_1")]
        [TestCaseSource("AddMany_2")]
        public void AddMany_WhenAny_ShouldAddItemsToEnd(IMyList<int> list, MyList<int> additionalList, IMyList<int> expeectedResult)
        {
            list.Add(additionalList);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        private static readonly object[] AddFrontMany_1 = new[] { new object[] { new MyList<int> { 1, 2, 3 }, new MyList<int> { 4, 5 }, new MyList<int> { 4, 5, 1, 2, 3 } } };
        private static readonly object[] AddFrontMany_2 = new[] { new object[] { new MyList<int>(), new MyList<int> { 1, 2, 3 }, new MyList<int> { 1, 2, 3 } } };
        [TestCaseSource("AddFrontMany_1")]
        [TestCaseSource("AddFrontMany_2")]
        public void AddManyFront_WhenAny_ShouldAddItemsToFront(IMyList<int> list, MyList<int> additionalList, IMyList<int> expeectedResult)
        {
            list.AddFront(additionalList);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        private static readonly object[] AddManyFromIndex_1 = new[] { new object[] { new MyList<int>(), 0, new MyList<int> { 1, 2, 3 }, new MyList<int> { 1, 2, 3 } } };
        private static readonly object[] AddManyFromIndex_2 = new[] { new object[] { new MyList<int> { 1, 2, 3 }, 3, new MyList<int> { 4, 5 }, new MyList<int> { 1, 2, 3, 4, 5 } } };
        private static readonly object[] AddManyFromIndex_3 = new[] { new object[] { new MyList<int>() { 1, 2, 3 }, 2, new MyList<int> { 9, 8, 7 }, new MyList<int> { 1, 2, 9, 8, 7, 3 } } };
        private static readonly object[] AddManyFromIndex_4 = new[] { new object[] { new MyList<int>(), 0, new MyList<int> { }, new MyList<int> { } } };
        private static readonly object[] AddManyFromIndex_5 = new[] { new object[] { new MyList<int>() { 1, 2, 3 }, 0, new MyList<int>(), new MyList<int> { 1, 2, 3 } } };
        [TestCaseSource("AddManyFromIndex_1")]
        [TestCaseSource("AddManyFromIndex_2")]
        [TestCaseSource("AddManyFromIndex_3")]
        [TestCaseSource("AddManyFromIndex_4")]
        [TestCaseSource("AddManyFromIndex_5")]
        public void AddManyFromIndex_WhenAny_ShouldAddItemsToFront(IMyList<int> list, int index, MyList<int> additionalList, IMyList<int> expeectedResult)
        {
            list.AddByIndex(index, additionalList);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void AddManyByIndex_WhenIndexLessZeroOfIndexMoreThenSize_ShouldThrowArgumentOutOfRangeException(int pos)
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.AddByIndex(pos, new MyList<int>());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Index is out of range", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        #endregion

        #region Remove

        private static readonly object[] RemoveBack_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3 }, new MyList<int>() { 1, 2 }, } };
        private static readonly object[] RemoveBack_2 = new[] { new object[] { new MyList<int>() { 0 }, new MyList<int>() } };
        [TestCaseSource("RemoveBack_1")]
        [TestCaseSource("RemoveBack_2")]
        public void RemoveBack_WhenSizeIsBiggerZero_ShouldRemoveLastItem(IMyList<int> list, MyList<int> expeectedResult)
        {
            list.RemoveBack();
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveBack_WhenSizeIsZero_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.RemoveBack();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] RemoveFront_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3 }, new MyList<int>() { 2, 3 }, } };
        private static readonly object[] RemoveFront_2 = new[] { new object[] { new MyList<int>() { 0 }, new MyList<int>() } };
        [TestCaseSource("RemoveFront_1")]
        [TestCaseSource("RemoveFront_2")]
        public void RemoveFront_WhenSizeIsBiggerZero_ShouldRemoveFirsttItem(IMyList<int> list, IMyList<int> expeectedResult)
        {
            list.RemoveFront();
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveFront_WhenSizeIsZero_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.RemoveFront();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] RemoveAt_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3 }, 1, new MyList<int>() { 1, 3 }, } };
        private static readonly object[] RemoveAt_2 = new[] { new object[] { new MyList<int>() { 0 }, 0, new MyList<int>() } };
        [TestCaseSource("RemoveAt_1")]
        [TestCaseSource("RemoveAt_2")]
        public void RemoveAt_WhenSizeAndIndexIsBiggerZeroAndIndexIsLessSize_ShouldRemoveItemByIndex(IMyList<int> list, int index, IMyList<int> expeectedResult)
        {
            list.RemoveAt(index);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveAt_WhenSizeIsZero_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAt_WhenIndexLessZeroOrBiggerThanSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                IMyList<int> list = new MyList<int>() { 0 };
                list.RemoveAt(index);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong index", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] RemoveManyBack_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3, 4 }, 2, new MyList<int>() { 1, 2 }, } };
        private static readonly object[] RemoveManyBack_2 = new[] { new object[] { new MyList<int>() { 0 }, 1, new MyList<int>() } };
        [TestCaseSource("RemoveManyBack_1")]
        [TestCaseSource("RemoveManyBack_2")]
        public void RemoveManyBack_WhenSizeIsBiggerThanQuantity_ShouldRemoveLastPointedItems(IMyList<int> list, int quantity, IMyList<int> expeectedResult)
        {
            list.RemoveBack(quantity);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveManyBack_WhenSizeIsNotBiggerThanQuantity_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>(1);
                list.RemoveBack(2);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] RemoveManyFront_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3, 4 }, 2, new MyList<int>() { 3, 4 }, } };
        private static readonly object[] RemoveManyFront_2 = new[] { new object[] { new MyList<int>() { 0 }, 1, new MyList<int>() } };
        [TestCaseSource("RemoveManyFront_1")]
        [TestCaseSource("RemoveManyFront_2")]
        public void RemoveManyFront_WhenSizeIsBiggerThanQuantity_ShouldRemoveFromStartPointedItems(IMyList<int> list, int quantity, IMyList<int> expeectedResult)
        {
            list.RemoveFront(quantity);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveManyFront_WhenSizeIsNotBiggerThanQuantity_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>(1);
                list.RemoveFront(2);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] RemoveManyAt_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3, 4 }, 1, 2, new MyList<int>() { 1, 4 }, } };
        private static readonly object[] RemoveManyAt_2 = new[] { new object[] { new MyList<int>() { 2 }, 0, 1, new MyList<int>() } };
        [TestCaseSource("RemoveManyAt_1")]
        [TestCaseSource("RemoveManyAt_2")]
        public void RemoveManyAt_WhenSizeIsNotBiggerThanQuantityAndIndexIsLessSize_ShouldRemoveQuantityOfItemsStartFromIndex(IMyList<int> list, int index, int quantity, IMyList<int> expeectedResult)
        {
            list.RemoveAt(index, quantity);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveManyAt_WhenSizeIsZero_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.RemoveAt(0, 1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveManyAt_WhenIndexLessZeroOrBiggerThanSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                IMyList<int> list = new MyList<int>() { 0 };
                list.RemoveAt(index, 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong index setted", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] Remove_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3, 4 }, 2, new MyList<int>() { 1, 3, 4 }, } };
        private static readonly object[] Remove_2 = new[] { new object[] { new MyList<int>() { 2 }, 2, new MyList<int>() } };
        [TestCaseSource("Remove_1")]
        [TestCaseSource("Remove_2")]
        public void Remove_WhenElementIsNotNullAndSizeIsNotZero_ShouldRemovePointedElement(IMyList<int> list, int element, IMyList<int> expeectedResult)
        {
            list.Remove(element);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void Remove_WhenSizeIsZero_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.Remove(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void Remove_WhenElementIsNull_ShouldThrowArgumentNullException()
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

        private static readonly object[] RemoveAll_1 = new[] { new object[] { new MyList<int>() { 1, 2, 3, 2 }, 2, new MyList<int>() { 1, 3 }, } };
        private static readonly object[] RemoveAll_2 = new[] { new object[] { new MyList<int>() { 2, 2, 2 }, 2, new MyList<int>() } };
        [TestCaseSource("RemoveAll_1")]
        [TestCaseSource("RemoveAll_2")]
        public void RemoveAll_WhenElementIsNotNullAndSizeIsNotZero_ShouldRemovePointedElement(IMyList<int> list, int element, IMyList<int> expeectedResult)
        {
            list.RemoveAll(element);
            Assert.AreEqual(expeectedResult.Count, list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(expeectedResult[i], list[i]);
            }
        }

        [Test]
        public void RemoveAll_WhenSizeIsZero_ShouldThrowArgumentOutOfRangeException()
        {
            try
            {
                IMyList<int> list = new MyList<int>();
                list.RemoveAll(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Size", ex.ParamName);
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

        #endregion

        #region Search and Sort

        #endregion



        private static readonly object[] data = new[] { new object[] { new MyList<int> { 3, 2, 1 }, new MyList<int> { 1, 2, 3 } } };
        [TestCaseSource("data")]
        public void sort(IMyList<int> list, IMyList<int> expeectedResult)
        {
            list.SortByAsc();
            Assert.AreEqual(expeectedResult, list);
        }
    }
}