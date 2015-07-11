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

        private static BinNode<Q> Insert<Q>(BinNode<Q> node,ref Q data)
        {
            if (node == null)
                return new BinNode<Q>(ref data);
            Find<Q>(node, data);
            return Balance<Q>(node);
        }

        private static void Find<Q>(BinNode<Q> node, Q data)
        {
            var newNodeKey = data.GetHashCode();
            if (node.Key > newNodeKey)
                node.LeftChild = Insert<Q>(node.LeftChild,ref data);
            else if (node.Key < newNodeKey)
                node.RightChild = Insert<Q>(node.RightChild,ref data);
        }

        private static BinNode<Q> RightTurn<Q>(BinNode<Q> p)
        {
            var q = p.LeftChild;

            p.LeftChild = q.RightChild;
            q.RightChild = p;
            p.FixHeight();
            q.FixHeight();

            return q;
        }

        private static BinNode<Q> LeftTurn<Q>(BinNode<Q> p)
        {
            var q = p.RightChild;

            p.RightChild = q.LeftChild;
            q.LeftChild = p;
            p.FixHeight();
            q.FixHeight();

            return q;
        }

        private static BinNode<Q> Balance<Q>(BinNode<Q> p)
        {
            p.FixHeight();
            if(p.BalanceFactor==2)
            {
                if (p.RightChild.BalanceFactor < 0)
                    p.RightChild = RightTurn<Q>(p.RightChild);
                p = LeftTurn<Q>(p);
            }
            if(p.BalanceFactor==-2)
            {
                if (p.LeftChild.BalanceFactor < 0)
                    p.LeftChild = LeftTurn<Q>(p.LeftChild);
                p = RightTurn<Q>(p);
            }
            return p;
        }
        #endregion
    }
}
