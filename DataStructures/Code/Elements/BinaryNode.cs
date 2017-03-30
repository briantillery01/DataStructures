using System;

namespace DataStructures.Elements
{
	/// <summary>
	/// Public class implementation of the binary search tree node data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the node.</typeparam>
	class BinaryNode<T>
	{
		private T _element;
		private BinaryNode<T> _left;
		private BinaryNode<T> _right;

		public BinaryNode()
		{
			_element = default(T);
			_left = null;
			_right = null;
		}

		public BinaryNode(T element, BinaryNode<T> left, BinaryNode<T> right) 
			: this()
		{
			_element = element;
			_left = left;
			_right = right;
		}

		public Type ElementType
		{
			get { return typeof(T); }
		}

		public T Element
		{
			get { return _element; }
			set { _element = value; }
		}

		public BinaryNode<T> Left
		{
			get { return _left; }
			set { _left = value; }
		}

		public BinaryNode<T> Right
		{
			get { return _right; }
			set { _right = value; }
		}
	}
}
