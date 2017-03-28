using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Elements
{
    class LinkedList
    {
        private int _size;
        private Node _head;
        private Node _tail;
        private List<Node> _nodeList;

        public LinkedList()
        {
            _head = null;
            _tail = null;
            _nodeList = new List<Node>();
        }

        public int Count
        {
            get { return _nodeList.Count; }
        }

        public bool isEmpty
        {
            get { return _nodeList.Count == 0; }
        }

        public Node Head
        {
            get
            {
                if(_nodeList.Count == 0) return null;
                return _nodeList[0];
            }
        }

        public Node Tail
        {
            get
            {
                if (_nodeList.Count == 0) return null;
                return _nodeList[_nodeList.Count - 1];
            }
        }

        public Node GetNode(int index)
        {
            if(index < 0 || index == _nodeList.Count) { throw new IndexOutOfRangeException(); }
            return _nodeList[index];
        }

        public void InsertFront(Node node)
        {
            _nodeList.Insert(0, node);
        }

        public void InsertBack(Node node)
        {
            _nodeList.Insert(_nodeList.Count, node);
        }

        public void InsertAt(Node node, int index)
        {
            if(index < 0 || index > _nodeList.Count) { throw new IndexOutOfRangeException(); }
            _nodeList.Insert(index, node);
        }

        public void InsertBefore(Node node)
        {
            int index = _nodeList.IndexOf(node);
            _nodeList.Insert(index, node);
        }

        public Object Remove(int index)
        {
            if(_nodeList.Count == 0)
            {
                throw new NullReferenceException();
            }

            Node removedNode = _nodeList[index];
            _nodeList.RemoveAt(index);
            return removedNode;
        }

        public Object Remove(Node node)
        {
            if (_nodeList.Count == 0)
            {
                throw new NullReferenceException();
            }

            _nodeList.Remove(node);
            return node.Value;
        }

        public void Clear()
        {
            _nodeList.Clear();
        }

        public string PrintForward()
        {
            string sep = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for(int count = 0; count < _nodeList.Count; count++)
            {
                sb.Append(string.Format("{0}{1}", sep, _nodeList[count].ToString()));
                sep = ",";
            }
            sb.Append("]");
            return sb.ToString();
        }

        public string PrintBackward()
        {
            string sep = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int count = _nodeList.Count - 1; count >= 0; count--)
            {
                sb.Append(string.Format("{0}{1}", sep, _nodeList[count]));
                sep = ",";
            }
            sb.Append("]");
            return sb.ToString();
        }

        public override string ToString()
        {
            return PrintForward();
        }
    }
}
