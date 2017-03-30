using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Elements
{
	/// <summary>
	/// Public class implementation of the linked list data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the linked list.</typeparam>
	class LinkedList<T>
	{
		private List<Node<T>> _nodeList;

		public LinkedList()
		{
			_nodeList = new List<Node<T>>();
		}

		/// <summary>
		/// Get the number of nodes in the linked list.
		/// </summary>
		public int Count
		{
			get { return _nodeList.Count; }
		}

		/// <summary>
		/// Checks if the linked list is empty.
		/// </summary>
		public bool isEmpty
		{
			get { return _nodeList.Count == 0; }
		}

		/// <summary>
		/// Retrieves the head of the linked list.
		/// </summary>
		public Node<T> Head
		{
			get
			{
				if (_nodeList.Count == 0) return null;
				return _nodeList[0];
			}
		}

		/// <summary>
		/// Retrieves the tail of the linked list.
		/// </summary>
		public Node<T> Tail
		{
			get
			{
				if (_nodeList.Count == 0) return null;
				return _nodeList[_nodeList.Count - 1];
			}
		}

		/// <summary>
		/// Public method to check if list contains node.
		/// </summary>
		/// <param name="node">Node to check for.</param>
		/// <returns>True if node is present.</returns>
		public bool Contains(Node<T> node)
		{
			return _nodeList.Contains(node);
		}	

		/// <summary>
		/// Public method to retrieve node from linked list.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public Node<T> GetNode(int index)
		{
			if (index < 0 || index == _nodeList.Count) { throw new IndexOutOfRangeException(); }
			return _nodeList[index];
		}

		/// <summary>
		/// Public method to insert node at the front of the linked list.
		/// </summary>
		/// <param name="node">The node to be inserted.</param>
		public void InsertFront(Node<T> node)
		{
			_nodeList.Insert(0, node);
		}

		/// <summary>
		/// Public method to insert node at the back of the linked list.
		/// </summary>
		/// <param name="node">The node to be inserted.</param>
		public void InsertBack(Node<T> node)
		{
			_nodeList.Insert(_nodeList.Count, node);
		}

		/// <summary>
		/// Public method to insert node at the given index of the linked list.
		/// </summary>
		/// <param name="node">The node to be inserted.</param>
		/// <param name="index">The location the node is to be inserted.</param>
		public void InsertAt(Node<T> node, int index)
		{
			if (index < 0 || index > _nodeList.Count) { throw new IndexOutOfRangeException(); }
			_nodeList.Insert(index, node);
		}

		/// <summary>
		/// Public method to remove a node at the given index from the linked list.
		/// </summary>
		/// <param name="index">The location of the node to be remove.</param>
		/// <returns>The node that was removed from the linked list.</returns>
		public Node<T> Remove(int index)
		{
			if (_nodeList.Count == 0)
			{
				throw new NullReferenceException();
			}

			Node<T> removedNode = _nodeList[index];
			_nodeList.RemoveAt(index);
			return removedNode;
		}

		/// <summary>
		/// Public method to remove a given node from the linked list.
		/// </summary>
		/// <param name="node">The node to be removed.</param>
		/// <returns>The value of the removed node.</returns>
		public T Remove(Node<T> node)
		{
			if (_nodeList.Count == 0)
			{
				throw new NullReferenceException();
			}

			_nodeList.Remove(node);
			return node.Data;
		}

		/// <summary>
		/// Public method that removes all the nodes from the linked list.
		/// </summary>
		public void Clear()
		{
			_nodeList.Clear();
		}

		/// <summary>
		/// Public method that creates a string of values from head to tail.
		/// </summary>
		/// <returns>A string of values.</returns>
		public string ToForwardStr()
		{
			string sep = "";
			StringBuilder sb = new StringBuilder();
			sb.Append("[");
			for (int count = 0; count < _nodeList.Count; count++)
			{
				sb.Append(string.Format("{0}{1}", sep, _nodeList[count].ToString()));
				sep = ",";
			}
			sb.Append("]");
			return sb.ToString();
		}

		/// <summary>
		/// Public method that creates a string of values from tail to head.
		/// </summary>
		/// <returns>A string of values.</returns>
		public string ToBackwardStr()
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

		/// <summary>
		/// Public method that overrides the ToString implementation.
		/// </summary>
		/// <returns>A string representation of the linked list.</returns>
		public override string ToString()
		{
			return ToForwardStr();
		}
	}
}
