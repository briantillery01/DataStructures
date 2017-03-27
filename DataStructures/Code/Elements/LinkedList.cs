using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Elements
{
    class LinkedList
    {
        //test
        private int _size;
        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        public int Length
        {
            get { return _size; }
        }

        public Node Head
        {
            get { return _head; }
        }

        public Node Tail
        {
            get { return _tail; }
        }

        public void InsertFront(Node node)
        {
            InsertAt(node, 0);
        }

        public void InsertBack(Node node)
        {
            InsertAt(node, _size);
        }

        public void InsertAt(Node node, int index)
        {
            if(index < 0)
            {
                //error state
                Console.WriteLine("Error! Index out of range.");
            }

            else if (index == 0)
            {
                if(_size == 0)
                {
                    _head = node;
                    _tail = _head;
                }

                else
                {
                    Node tmpNode = _head;
                    tmpNode.PreviousNode = node;
                    node.NextNode = tmpNode;
                    _head = node;
                    tmpNode = null;
                }                

                _size += 1;
            }

            else if (index == _size)
            {
                Node tmpNode = _tail;
                tmpNode.NextNode = node;
                node.PreviousNode = tmpNode;
                _tail = tmpNode;
                tmpNode = null;

                _size += 1;
            }

            else if(index > _size)
            {
                //error state
                Console.WriteLine("Error! Index out of range.");
            }

            else
            {
                Node tmpNode = _head;
                for(int counter = 0; counter < index; counter++)
                {
                    tmpNode = tmpNode.NextNode;
                }

                node.NextNode = tmpNode;
                node.PreviousNode = tmpNode.PreviousNode;
                tmpNode.PreviousNode.NextNode = node;
                tmpNode.PreviousNode = node;
                _size += 1;
            }
        }

        public Object Remove(Node node)
        {
            Node removedNode = null;
            Node currentNode = _head;
            while(currentNode != null)
            {
                if(currentNode == node)
                {
                    removedNode = currentNode;
                    Node prevNode = currentNode.PreviousNode;
                    Node nextNode = currentNode.NextNode;

                    prevNode.NextNode = nextNode;
                    nextNode.PreviousNode = prevNode;

                    currentNode.PreviousNode = null;
                    currentNode.NextNode = null;
                    currentNode = null;
                    break;
                }
                currentNode = currentNode.NextNode;
            }
            _size -= 1;
            return removedNode;
        }

        public Object RemoveAt(int index)
        {
            Node removedNode = null;
            Node currentNode = _head;
            for (int counter = 0; counter < index; index++)
            {
                currentNode = currentNode.NextNode;
            }

            removedNode = currentNode;
            Node prevNode = currentNode.PreviousNode;
            Node nextNode = currentNode.NextNode;

            prevNode.NextNode = nextNode;
            nextNode.PreviousNode = prevNode;

            currentNode.NextNode = null;
            currentNode.PreviousNode = null;
            currentNode = null;

            _size -= 1;
            return removedNode;
        }

        public void Clear()
        {
            Node tmpNode = null;
            Node currentNode = _tail;
            while(currentNode != null)
            {
                tmpNode = currentNode;
                currentNode = currentNode.PreviousNode;

                tmpNode.PreviousNode = null;
                tmpNode.NextNode = null;
                tmpNode = null;
            }

            _size = 0;
        }

        public string PrintForward()
        {
            return _head.ToForwardStr();
        }

        public string PrintBackward()
        {
            return _tail.ToBackwardStr();
        }

        public override string ToString()
        {
            return PrintForward();
        }
    }
}
