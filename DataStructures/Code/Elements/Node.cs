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
        private object _cargo;

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

        public object Value
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public override string ToString()
        {
            return _cargo.ToString(); 
        }

    }
}
