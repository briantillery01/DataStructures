using System;

namespace DataStructures.AbstractDT
{
	/// <summary>
	/// Public class implementation of the queue data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the nodes of the queue.</typeparam>
	class Queue<T>
  {
		private LinkedList<T> _linkedList;
			
		public Queue()
		{
			_linkedList = new LinkedList<T>();
		}

		/// <summary>
		/// Public method that returns the number of nodes in the queue.
		/// </summary>
		/// <returns>The number of nodes in the queue.</returns>
		public int Count()
		{
			return _linkedList.Count;
		}

		/// <summary>
		/// Public method that checks if the given node is in the queue.
		/// </summary>
		/// <param name="node"></param>
		/// <returns>True if the node is in the queue, false otherwise.</returns>
		public bool Contains(T value)
		{
			return _linkedList.Contains(value);
		}

		/// <summary>
		/// Public method that inserts a node into the queue.
		/// </summary>
		/// <param name="node"></param>
		public void Enqueue(T value)
		{
			_linkedList.InsertBack(value);
		}

		/// <summary>
		/// Public method that removes a node from the queue.
		/// </summary>
		/// <returns>The node that was removed.</returns>
		public T Dequeue()
		{
			if(_linkedList.Count == 0) //from queue specification
			{
				throw new Exception("Cannot dequeue empty queue.");
			}
			return _linkedList.Remove(0);
		}
   }
}
