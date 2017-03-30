using System;
using DataStructures.Elements;

namespace DataStructures.Searches
{
	/// <summary>
	/// Public class implementation of the binary search tree data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the tree.</typeparam>
	class BinarySearchTree<T>
	{
		private BinaryNode<T> _root;

		public BinarySearchTree()
		{
			_root = null;
		}

		#region ------------------------------ PUBLIC METHODS ------------------------------
		/// <summary>
		/// Public method to empty tree.
		/// </summary>
		public void MakeEmpty()
		{
			_root = null; //what about memory leak?
		}

		/// <summary>
		/// Public method to check if tree is empty.
		/// </summary>
		/// <returns>True if tree is empty; false otherwise.</returns>
		public bool IsEmpty()
		{
			return _root == null;
		}

		/// <summary>
		/// Public method to check if value is found in tree.
		/// </summary>
		/// <param name="value">The value being searched for.</param>
		/// <returns>True if the value was found; false otherwise.</returns>
		public bool Contains(T value)
		{
			return Contains(value, _root);
		}

		/// <summary>
		/// Public method to find minimum value in tree.
		/// </summary>
		/// <returns>The minimum value found in the tree.</returns>
		public T FindMin()
		{
			if (IsEmpty())
				throw new Exception("Cannot find minimum value of empty tree.");

			return FindMin(_root).Element;
		}

		/// <summary>
		/// Public method to find maximum value in tree.
		/// </summary>
		/// <returns>The maximum value found in the tree.</returns>
		public T FindMax()
		{
			if (IsEmpty())
				throw new Exception("Cannot find maximum value of empty tree.");

			return FindMax(_root).Element;
		}

		/// <summary>
		/// Public method to insert new node with given value.
		/// </summary>
		/// <param name="value">The value to be inserted.</param>
		public void Insert(T value)
		{
			_root = Insert(value, _root);
		}

		/// <summary>
		/// Public method to remove new node with given value;
		/// </summary>
		/// <param name="value">The value to be removed.</param>
		public void Remove(T value)
		{
			_root = Remove(value, _root);
		}

		/// <summary>
		/// Public method to print out the tree.
		/// </summary>
		public void PrintTree()
		{
			PrintTree(_root);
		}

		/// <summary>
		/// Public method to calculate the height of the tree.
		/// </summary>
		/// <returns>The height of the tree; -1 if tree is empty.</returns>
		public int Height()
		{
			return Height(_root);
		}
		#endregion

		#region ------------------------------ PRIVATE METHODS ------------------------------
		/// <summary>
		/// Internal method to compare two nodes of the same type.
		/// </summary>
		/// <param name="lhs">The 1st node to compare.</param>
		/// <param name="rhs">The 2nd node to compare.</param>
		/// <returns>A negative int if lhs is larger; a positive int if rhs is larger; 0 if they are equal.</returns>
		private int Compare(T lhs, T rhs)
		{
			int retVal = 0;
			if (typeof(T) == typeof(int)) {
				retVal = Convert.ToInt32(lhs) - Convert.ToInt32(rhs);
			}
			else if (typeof(T) == typeof(string)) {
				retVal = string.Compare(Convert.ToString(lhs), Convert.ToString(rhs));
			}
			else {
				throw new NotImplementedException(String.Format("Compare for type <{0}> is not defined", typeof(T).ToString()));
			}

			return retVal;
		}

		/// <summary>
		/// Internal method to find an item in a subtree.
		/// </summary>
		/// <param name="value">The item to search for.</param>
		/// <param name="subTree">The node that roots the subtree.</param>
		/// <returns>True if the item is found; false otherwise.</returns>
		private Boolean Contains(T value, BinaryNode<T> subTree)
		{
			if (subTree == null)
				return false; //no subtree

			int compareResult = Compare(value, subTree.Element);
			if (compareResult < 0){
				return Contains(value, subTree.Left);
			}
			else if (compareResult > 0) {
				return Contains(value, subTree.Right);
			}
			else {
				return true;
			}
		}

		/// <summary>
		/// Internal method to find the smallest item in a subtree.
		/// </summary>
		/// <param name="t">The node that roots the subtree.</param>
		/// <returns>The node containing the smallest item.</returns>
		private BinaryNode<T> FindMin(BinaryNode<T> t)
		{
			if (t == null) {
				return null;
			}
			else if (t.Left == null) {
				return t;
			}
			return FindMin(t.Left);
		}

		/// <summary>
		/// Internal method to find the largest item in a subtree.
		/// </summary>
		/// <param name="t">The node that roots the subtree.</param>
		/// <returns>The node containing the largest item.</returns>
		private BinaryNode<T> FindMax(BinaryNode<T> t)
		{
			if (t == null) {
				return null;
			}
			else if (t.Right == null) {
				return t;
			}
			return FindMax(t.Right);
		}

		/// <summary>
		/// Internal method to insert into a subtree.
		/// </summary>
		/// <param name="n">The node to insert.</param>
		/// <param name="subTree">The node that roots the subtree.</param>
		/// <returns>The new root of the subtree.</returns>
		private BinaryNode<T> Insert(T newValue, BinaryNode<T> subTree)
		{
			if (subTree == null)
				return new BinaryNode<T>(newValue, null, null); ;

			int compareResult = Compare(newValue, subTree.Element);
			if (compareResult < 0) {
				subTree.Left = Insert(newValue, subTree.Left);
			}
			else if (compareResult > 0) {
				subTree.Right = Insert(newValue, subTree.Right);
			}
			else {
				/*Duplicate. Do nothing. */
			}
			return subTree;
		}

		/// <summary>
		/// Internal method to remove from a subtree.
		/// </summary>
		/// <param name="removedValue">The item to remove.</param>
		/// <param name="subTree">The node that roots the subtree.</param>
		/// <returns>The new root of the subtree.</returns>
		private BinaryNode<T> Remove(T removedValue, BinaryNode<T> subTree)
		{
			if (subTree == null) //item not found, do nothing
				return null;

			int compareResult = Compare(removedValue, subTree.Element);
			if (compareResult < 0) {
				subTree.Left = Remove(removedValue, subTree.Left);
			}
			else if (compareResult > 0) {
				subTree.Right = Remove(removedValue, subTree.Right);
			}
			else if (subTree.Left != null && subTree.Right != null)		// found match with two children
			{
				subTree.Element = FindMin(subTree.Right).Element;				//replace root value with value of min of right subtree.
				subTree.Right = Remove(subTree.Element, subTree.Right); //remove min of right subtree so there are not duplicates
			}
			else {
				subTree = (subTree.Left != null) ? subTree.Left : subTree.Right;
			}

			return subTree;
		}

		/// <summary>
		/// Internal method that prints subtree in sorted order.
		/// </summary>
		/// <param name="subTree">The node that roots the subtree.</param>
		private void PrintTree(BinaryNode<T> subTree)
		{
			if(subTree != null) {
				PrintTree(subTree.Left);
				Console.Write(String.Format("{0} "), subTree.Element);
				PrintTree(subTree.Right);
			}
		}

		/// <summary>
		/// Internal method that computes the height of a subtree.
		/// </summary>
		/// <param name="subTree">The node that roots the subtree.</param>
		/// <returns>The height of the subtree.</returns>
		private int Height(BinaryNode<T> subTree)
		{
			if (subTree == null){
				return -1;
			}
			else {
				return 1 + Math.Max(Height(subTree.Left), Height(subTree.Right));
			}
		}
		#endregion
	}
}
