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
    }
}
