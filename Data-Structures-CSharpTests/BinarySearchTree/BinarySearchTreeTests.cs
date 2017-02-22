﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.BinarySearchTree.Tests
{
    /// <summary>
    /// Unit test class that tests all methods of the BinarySearchTree class.
    /// </summary>
    [TestClass]
    public class BinarySearchTreeTests
    {
        private const int TEST_BREADTH = 20;

        private const int TEST_DEPTH = 100;

        private TestEngine testDriver;

        private BinarySearchTree<int> bst;

        /// <summary>
        /// Default constructor.
        /// Initializes all class-wide test-dependent members.
        /// </summary>
        public BinarySearchTreeTests()
        {
            this.testDriver = new TestEngine(TEST_BREADTH, TEST_DEPTH);
            bst = new BinarySearchTree<int>(this.testDriver.generateRandomElement());
        }

        /// <summary>
        /// Tests if the BinarySearchTree object is properly seraching for values within it's underlying tree object.
        /// </summary>
        [TestMethod]
        public void searchTest()
        {
            // arrange
            foreach (int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int nonExistentValue;
            do
            {
                nonExistentValue = this.testDriver.generateRandomElement();
            } while (testDriver.elements.Contains(nonExistentValue));
            // act / assert
            Assert.IsFalse(bst.search(nonExistentValue));
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(bst.search(value));
            }
        }

        /// <summary>
        /// Tests if the BinarySearchTree object is able to properly find the smallest value within the tree.
        /// </summary>
        [TestMethod]
        public void findMinimumTest()
        {
            // arrange
            foreach (int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int expectedMinimum = this.testDriver.elements.Min();
            // act
            int actualMinimum = this.bst.findMinimum();
            // assert
            Assert.AreEqual(expectedMinimum, actualMinimum);
        }

        /// <summary>
        /// Tests if the BinarySearchTree object is able to properly find the largest value within the tree.
        /// </summary>
        [TestMethod]
        public void findMaximumTest()
        {
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int expectedMaximum = this.testDriver.elements.Max();
            // act
            int actualMaximum = this.bst.findMaximum();
            // assert
            Assert.AreEqual(expectedMaximum, actualMaximum);
        }

        /// <summary>
        /// Tests if the BinarySearchTree object is able to properly traverse the elements of the tree.
        /// </summary>
        [TestMethod]
        public void traverseTest()
        {
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                this.bst.insert(value);
            }
            int expectedTraversalSize = this.testDriver.elements.Length;
            // act
            int[] traversalOrder = this.bst.traverse();
            // assert
            Assert.AreEqual(expectedTraversalSize, traversalOrder.Length);
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(traversalOrder.Contains(value));
            }
        }

        /// <summary>
        /// Tests if the BinarySearchTree object is inserting nodes and incrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void insertTest()
        {
            // arrange
            int expectedSize = bst.getSize();
            // act / assert
            foreach(int value in testDriver.elements)
            {
                bst.insert(value);
                expectedSize++;
                Assert.IsTrue(bst.search(value));
                Assert.AreEqual(expectedSize, bst.getSize());
            }
        }

        /// <summary>
        /// Tests if the BinarySearchTree object is deleting nodes and decrementing it's size correctly.
        /// </summary>
        [TestMethod]
        public void deleteTest()
        {
            // arrange
            foreach(int value in this.testDriver.elements)
            {
                bst.insert(value);
            }
            int expectedSize = bst.getSize();
            // act / assert
            foreach(int value in this.testDriver.elements)
            {
                Assert.IsTrue(bst.search(value));
                bst.delete(value);
                expectedSize--;
                Assert.IsFalse(bst.search(value));
                Assert.AreEqual(expectedSize, bst.getSize());
            }
        }
    }
}