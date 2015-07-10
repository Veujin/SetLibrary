using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bolshakov_1;

namespace Search_Tree_Tests
{
    [TestClass]
    public class SimpleMethTests
    {
        [TestMethod]
        public void ZeroBalanceFactor_1()
        {
            var testNode = new BinNode<int>(3);

            Assert.AreEqual(0, testNode.BalanceFactor);
        }

        [TestMethod]
        public void ZeroBalanceFactor_2()
        {
            var testNode = new BinNode<int>(3);
            int expectBFactor = 0;

            testNode.LeftChild = new BinNode<int>(5);
            testNode.RightChild = new BinNode<int>(7);

            Assert.AreEqual(expectBFactor, testNode.BalanceFactor);
        }

        [TestMethod]
        public void OneNodeHeight()
        {
            var testNode = new BinNode<int>(3);
            Assert.AreEqual(1, testNode.Height);
        }

        [TestMethod]
        public void TwoNodeHeight()
        {
            var testNode = new BinNode<int>(3);
            testNode.LeftChild = new BinNode<int>(5);
            testNode.FixHeight();
            Assert.AreEqual(2, testNode.Height);
        }

        [TestMethod]
        public void DisbalanceHeightFix()
        {
            var testNode = new BinNode<int>(3);
            testNode.LeftChild = new BinNode<int>(5);
            testNode.RightChild = new BinNode<int>(7);
            testNode.LeftChild.LeftChild = new BinNode<int>(3);
            testNode.LeftChild.LeftChild.RightChild = new BinNode<int>(2);
            testNode.LeftChild.LeftChild.RightChild.LeftChild = new BinNode<int>(2);
            testNode.LeftChild.LeftChild.RightChild.RightChild = new BinNode<int>(9);

            int expectHeight = 5;

            RecFixHeight<int>(testNode);

            Assert.AreEqual(expectHeight, testNode.Height);
        }

        private void RecFixHeight<T>(BinNode<T> node)
        {
            if (node.LeftChild != null)
                RecFixHeight<T>(node.LeftChild);
            if (node.RightChild != null)
                RecFixHeight<T>(node.RightChild);
            node.FixHeight();
        }
    }
}
