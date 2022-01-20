using NUnit.Framework;
using ListLibrary;
using System;
using System.Collections.Generic;

namespace BinaryTreeTests
{
    public class BinaryTreeTests
    {
        private static readonly object[] AddFirstElement = new[] { new object[] { new BinaryTree<int>(), 3, new BinaryTree<int> { 3 } } };
        private static readonly object[] AddToRight = new[] { new object[] { new BinaryTree<int> { 1, 2 }, 3, new BinaryTree<int> { 1, 2, 3 } } };
        private static readonly object[] AddToLeft = new[] { new object[] { new BinaryTree<int> { 1, 3 }, 2, new BinaryTree<int> { 1, 3, 2 } } };
        [TestCaseSource("AddFirstElement")]
        [TestCaseSource("AddToRight")]
        [TestCaseSource("AddToLeft")]
        public void Add_WhenElementIsNotNull_ShouldAddElement(BinaryTree<int> source, int item, BinaryTree<int> expected)
        {
            source.Add(item);

            Assert.AreEqual(source, expected);
            CollectionAssert.AreEqual(source, expected);
        }

        [Test]
        public void Add_WhenElementIsNull_ShouldThrowArgumentException()
        {
            try
            {
                BinaryTree<string> source = new BinaryTree<string>() { null };

            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Value  to remove can't be null!");
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void Add_WhenCollectionHaasTheSameElement_ShouldThrowArgumentException()
        {
            try
            {
                BinaryTree<int> source = new BinaryTree<int>() { 1, 2, 3 };

                source.Add(3);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Binary tree can't hold two same items!");

                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] RemoveFirstElement = new[] { new object[] { new BinaryTree<int>() { 1 }, 1, new BinaryTree<int>() } };
        private static readonly object[] RemoveToRight = new[] { new object[] { new BinaryTree<int> { 1, 2, 3 }, 3, new BinaryTree<int> { 1, 2 } } };
        private static readonly object[] RemoveToLeft = new[] { new object[] { new BinaryTree<int> { 1, 3, 2 }, 2, new BinaryTree<int> { 1, 3 } } };
        [TestCaseSource("RemoveFirstElement")]
        [TestCaseSource("RemoveToRight")]
        [TestCaseSource("RemoveToLeft")]
        public void Remove_WhenElementIsNotNull_ShouldRemoveElement(BinaryTree<int> source, int item, BinaryTree<int> expected)
        {
            source.Remove(item);

            Assert.AreEqual(source, expected);
            CollectionAssert.AreEqual(source, expected);
        }

        [Test]
        public void Remove_WhenElementIsNull_ShouldThrowArgumentException()
        {
            try
            {
                BinaryTree<string> source = new BinaryTree<string>();

                source.Remove(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Value  to remove can't be null!");
                Assert.Pass();

            }

            Assert.Fail();
        }
    }
}