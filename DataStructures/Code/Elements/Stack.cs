using System;

namespace DataStructures.Elements
{
	/// <summary>
	/// Public class implementation of the stack data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the nodes of the stack.</typeparam>
	class Stack<T>
	{
		private LinkedList<T> _linkedList;

		public Stack()
		{
			_linkedList = new LinkedList<T>();
		}

		/// <summary>
		/// Public method that returns the number of nodes in the stack.
		/// </summary>
		/// <returns>The number of nodes in the stack.</returns>
		public int Count()
		{
			return _linkedList.Count;
		}

		/// <summary>
		/// Public method that checks if the given node is in the stack.
		/// </summary>
		/// <param name="node"></param>
		/// <returns>True if the node is in the stack, false otherwise.</returns>
		public bool Contains(Node<T> node)
		{
			return _linkedList.Contains(node);
		}

		/// <summary>
		/// Public method that inserts a node into the stack.
		/// </summary>
		/// <param name="node"></param>
		public void Push(Node<T> node)
		{
			_linkedList.InsertBack(node);
		}

		/// <summary>
		/// Public method that looks at the node on top of the stack.
		/// </summary>
		/// <returns>The node at the top of the stack.</returns>
		public Node<T> Peek()
		{
			Node<T> removedNode = null;
			if(_linkedList.Count > 0)
			{
				return _linkedList.GetNode(_linkedList.Count - 1);
			}

			return removedNode;
		}

		/// <summary>
		/// Public method that removes a node from the stack.
		/// </summary>
		/// <returns>The node that was removed.</returns>
		public Node<T> Pop()
		{
			if(_linkedList.Count == 0)
			{
				throw new Exception("Cannot pop empty stack.");
			}

			return _linkedList.Remove(_linkedList.Count - 1);
		}
	}
}
