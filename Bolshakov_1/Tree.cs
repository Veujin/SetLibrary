using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolshakov_1
{
    class Tree<T>
    {
        #region Properties
        
        public BinNode<T> Root { get; private set; }

        public int Count { get; private set; }
        #endregion

        #region Public Methods
        
        public Tree()
        {
            Root = null;
            Count = 0;
        }
        #endregion

        #region Private methods

        private static BinNode<T> RightTurn<T>(BinNode<T> p)
        {
            var q = p.LeftChild;

            p.LeftChild = q.RightChild;
            q.RightChild = p;
            p.FixHeight();
            q.FixHeight();

            return q;
        }

        private static BinNode<T> LeftTurn<T>(BinNode<T> p)
        {
            var q = p.RightChild;

            p.RightChild = q.LeftChild;
            q.LeftChild = p;
            p.FixHeight();
            q.FixHeight();

            return q;
        }

        private static BinNode<T> Balance<T>(BinNode<T> p)
        {
            p.FixHeight();
            if(p.BalanceFactor==2)
            {
                if (p.RightChild.BalanceFactor < 0)
                    p.RightChild = RightTurn<T>(p.RightChild);
                p = LeftTurn<T>(p);
            }
            if(p.BalanceFactor==-2)
            {
                if (p.LeftChild.BalanceFactor < 0)
                    p.LeftChild = LeftTurn<T>(p.LeftChild);
                p = RightTurn<T>(p);
            }
            return p;
        }
        #endregion
    }
}
