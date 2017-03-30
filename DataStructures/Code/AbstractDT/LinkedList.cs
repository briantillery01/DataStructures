using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.AbstractDT
{
	/// <summary>
	/// Public class implementation of the linked list data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the linked list.</typeparam>
	class LinkedList<T>
	{
		private List<T> _valueList;

		public LinkedList()
		{
			_valueList = new List<T>();
		}

		/// <summary>
		/// Get the number of nodes in the linked list.
		/// </summary>
		public int Count
		{
			get { return _valueList.Count; }
		}

		/// <summary>
		/// Checks if the linked list is empty.
		/// </summary>
		public bool isEmpty
		{
			get { return _valueList.Count == 0; }
		}

		/// <summary>
		/// Public method to check if list contains node.
		/// </summary>
		/// <param name="node">Node to check for.</param>
		/// <returns>True if node is present.</returns>
		public bool Contains(T value)
		{
			return _valueList.Contains(value);
		}	

		/// <summary>
		/// Public method to retrieve node from linked list.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T GetValue(int index)
		{
			if (index < 0 || index == _valueList.Count) { throw new IndexOutOfRangeException(); }
			return _valueList[index];
		}

		/// <summary>
		/// Public method to insert node at the front of the linked list.
		/// </summary>
		/// <param name="node">The node to be inserted.</param>
		public void InsertFront(T value)
		{
			_valueList.Insert(0, value);
		}

		/// <summary>
		/// Public method to insert node at the back of the linked list.
		/// </summary>
		/// <param name="node">The node to be inserted.</param>
		public void InsertBack(T value)
		{
			_valueList.Insert(_valueList.Count, value);
		}

		/// <summary>
		/// Public method to insert node at the given index of the linked list.
		/// </summary>
		/// <param name="node">The node to be inserted.</param>
		/// <param name="index">The location the node is to be inserted.</param>
		public void InsertAt(T value, int index)
		{
			if (index < 0 || index > _valueList.Count) { throw new IndexOutOfRangeException(); }
			_valueList.Insert(index, value);
		}

		/// <summary>
		/// Public method to remove a node at the given index from the linked list.
		/// </summary>
		/// <param name="index">The location of the node to be remove.</param>
		/// <returns>The node that was removed from the linked list.</returns>
		public T Remove(int index)
		{
			if (_valueList.Count == 0)
			{
				throw new NullReferenceException();
			}

			T removedValue = _valueList[index];
			_valueList.RemoveAt(index);
			return removedValue;
		}

		/// <summary>
		/// Public method to remove a given node from the linked list.
		/// </summary>
		/// <param name="node">The node to be removed.</param>
		/// <returns>The value of the removed node.</returns>
		public T Remove(T value)
		{
			if (_valueList.Count == 0)
			{
				throw new NullReferenceException();
			}

			_valueList.Remove(value);
			return value;
		}

		/// <summary>
		/// Public method that removes all the nodes from the linked list.
		/// </summary>
		public void Clear()
		{
			_valueList.Clear();
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
			for (int count = 0; count < _valueList.Count; count++)
			{
				sb.Append(string.Format("{0}{1}", sep, _valueList[count].ToString()));
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
			for (int count = _valueList.Count - 1; count >= 0; count--)
			{
				sb.Append(string.Format("{0}{1}", sep, _valueList[count]));
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
