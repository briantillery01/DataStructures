using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Elements
{
	class Queue
  {
		private LinkedList _linkedList;
			
		public Queue()
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

		public void Enqueue(Node node)
		{
			_linkedList.InsertBack(node);
		}

		public Node Dequeue()
		{
			if(_linkedList.Count == 0)
			{
				throw new Exception("Cannot dequeue empty queue.");
			}
			return _linkedList.Remove(0);
		}
   }
}
