using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bolshakov_1;
using System.Collections.Generic;

namespace Search_Tree_Tests
{
    [TestClass]
    public class SimpleMethTests
    {
        [TestMethod]
        public void ZeroBalanceFactor_1()
        {
            var a = 3;
            var testNode = new BinNode<int>(ref a);

            Assert.AreEqual(0, testNode.BalanceFactor);
        }

        [TestMethod]
        public void TreeAddResultTest()
        {
            var tree = new Tree<int>();
            tree.Add(3);
            bool result = tree.Add(3);
            var expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TreeIntCountTest()
        {
            var tree = new Tree<int>();
            tree.Add(3);
            tree.Add(4);
            var expected = 2;

            Assert.AreEqual(expected, tree.Count);
        }

        [TestMethod]
        public void TreeIntDublicateTest2()
        {
            var tree = new Tree<int>();
            tree.Add(3);
            tree.Add(3);
            tree.Add(4);
            tree.Add(4);
            var expected = 2;

            Assert.AreEqual(expected, tree.Count);
        }

        [TestMethod]
        public void TreeIntDublicateTest3()
        {
            var tree = new Tree<int>();
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(3);
            var expected = 3;

            Assert.AreEqual(expected, tree.Count);
        }

        [TestMethod]
        public void TreeReftypeDublicateTest1()
        {
            var tree = new Tree<List<int>>();
            var a = new List<int>();
            var b = new List<int>();
            var expected = 2;

            tree.Add(a);
            tree.Add(b);
            tree.Add(a);

            Assert.AreEqual(expected, tree.Count);
        }

        [TestMethod]
        public void TreeReftypeDublicateTest2()
        {
            var tree = new Tree<List<int>>();
            var a = new List<int>();
            var b = new List<int>();
            var expected = 2;

            tree.Add(a);
            tree.Add(b);

            a.Add(3);
            tree.Add(a);

            Assert.AreEqual(expected, tree.Count);
        }

        [TestMethod]
        public void SearchNulltest()
        {
            var tree = new Tree<List<int>>();
            var a = new List<int>();
            var b = new List<int>();
            var c = new List<int>();

            tree.Add(a);
            tree.Add(b);

            var result = tree.Search(c);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void SearchNonNulltest()
        {
            var tree = new Tree<List<int>>();
            var a = new List<int>();
            var b = new List<int>();
            var c = new List<int>();

            tree.Add(a);
            tree.Add(b);
            tree.Add(c);

            var result = tree.Search(c);

            Assert.AreNotEqual(null, result);
        }
    }
}
