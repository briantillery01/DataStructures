using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Elements
{
	class Stack
	{
		private LinkedList _linkedList;

		public Stack()
		{
			_linkedList = new LinkedList();
		}

		public int Count()
		{
			return _linkedList.Count;
		}

		public bool Contains(Node node)
		{
			return _linkedList.Contains(node);
		}

		public Node Peek()
		{
			Node removedNode = null;
			if(_linkedList.Count > 0)
			{
				return _linkedList.GetNode(_linkedList.Count - 1);
			}

			return removedNode;
		}

		public Node Pop()
		{
			if(_linkedList.Count == 0)
			{
				throw new Exception("Cannot pop empty stack.");
			}

			return _linkedList.Remove(_linkedList.Count - 1);
		}

		public void Push(Node node)
		{
			_linkedList.InsertBack(node);
		}
	}
}
