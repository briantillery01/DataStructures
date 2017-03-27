using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Elements
{
    class Node
    {
        private Node _prev;
        private Node _next;
        private Object _cargo;

        public Node()
        {
            _prev = null;
            _next = null;
            _cargo = null;
        }

        public Node(Object cargo)
        {
            _cargo = cargo;
        }

        public Node(Node prev, Node next, Object cargo)
        {
            _prev = prev;
            _next = next;
            _cargo = cargo;
        }

        public Node PreviousNode
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public Node NextNode
        {
            get { return _next; }
            set { _next = value; }
        }

        public Object Value
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public override string ToString()
        {
            return _cargo.ToString(); 
        }

        public string ToForwardStr()
        {
            string sep = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            Node currentNode = this;
            while(currentNode != null)
            {
                sb.Append(string.Format("{0}{1}", sep, currentNode.ToString()));
                currentNode = currentNode.NextNode;
                sep = ",";
            }
            sb.Append("]");
            return sb.ToString();
        }

        public string ToBackwardStr()
        {
            string sep = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            Node currentNode = this;
            while (currentNode != null)
            {
                sb.Append(string.Format("{0}{1}", sep, currentNode.ToString()));
                currentNode = currentNode.PreviousNode;
                sep = ",";
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
