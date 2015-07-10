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
            Assert.AreEqual(testNode.BalanceFactor, 0);
        }

        [TestMethod]
        public void ZeroBalanceFactor_2()
        {
            var testNode = new BinNode<int>(3);
            testNode.LeftChild = new BinNode<int>(5);
            testNode.RightChild = new BinNode<int>(7);
            Assert.AreEqual(testNode.BalanceFactor, 0);
        }
    }
}
