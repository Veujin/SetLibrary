using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolshakov_1
{
    public class Tree<T>
    {
        #region Properties

        public int Count { get; private set; }
        #endregion

        #region Public Methods
        
        public Tree()
        {
            _root = null;
            Count = 0;
        }

        public void Add(T data)
        {
            if(_root != null)
            {
                Count++;
                try
                {
                    Insert<T>(_root, ref data);
                }
                catch(NodeExistException excep)
                {
                    Count--;
                }
            }
            else
            {
                _root = new BinNode<T>(ref data);
                Count++;
            }
        }

        public BinNode<T> Search(T data)
        {
            return Find<T>(_root,ref data);
        }
        #endregion

        #region Private methods

        private static BinNode<Q> Insert<Q>(BinNode<Q> node,ref Q data)
        {
            if (node == null)
            {
                return new BinNode<Q>(ref data);
            }
            var newNodeKey = data.GetHashCode();
            if (node.Key > newNodeKey)
                node.LeftChild = Insert<Q>(node.LeftChild, ref data);
            else if (node.Key < newNodeKey)
                node.RightChild = Insert<Q>(node.RightChild, ref data);
            else
                throw new NodeExistException();
            return Balance<Q>(node);
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

        private static BinNode<Q> Find<Q>(BinNode<Q> p, ref Q data)
        {
            if (p == null)
                return null;
            var dataKey = data.GetHashCode();
            if (dataKey < p.Key)
                return Find<Q>(p.LeftChild, ref data);
            else if (dataKey > p.Key)
                return Find<Q>(p.RightChild, ref data);
            return p;
        }
        #endregion

        #region Private members

        private BinNode<T> _root;
	    #endregion
    }
}
