using System;

namespace DataStructures.Trees
{
	/// <summary>
	/// Public class implementation of the AVL tree data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the tree.</typeparam>
	class AvlTree<T>
	{
		private const int ALLOWED_IMBALANCE = 1;
		private AvlNode _root;

		public AvlTree()
		{
			_root = null;
		}

		#region ------------------------------- PUBLIC METHODS -------------------------------
		
		/// <summary>
		/// Public method that gets the height of the AVL tree.
		/// </summary>
		/// <returns>The height of the tree or -1 if null.</returns>
		public int Height()
		{
			return Height(_root);
		}

		/// <summary>
		/// Public method that finds the minimum value of the tree.
		/// </summary>
		/// <returns>The minimum value of the tree.</returns>
		public T FindMin()
		{
			return FindMin(_root).Element;
		}

		/// <summary>
		/// Public method that finds the maximum value of the tree.
		/// </summary>
		/// <returns>The maximum value of the tree.</returns>
		public T FindMax()
		{
			return FindMax(_root).Element;
		}

		/// <summary>
		/// Public method that inserts an item into the tree.
		/// </summary>
		/// <param name="item">The item to be inserted</param>
		/// <returns>The value of the item that was inserted.</returns>
		public T Insert(T item)
		{
			return Insert(item, _root).Element;
		}

		/// <summary>
		/// Public method that removes an item from the tree.
		/// </summary>
		/// <param name="item">The item to be removed</param>
		/// <returns>The value of the item that was removed.</returns>
		public T Remove(T item)
		{
			return Remove(item, _root).Element;
		}
		#endregion

		#region ------------------------------ PRIVATE METHODS ------------------------------
		/// <summary>
		/// Return the height of the node, or -1 if null.
		/// </summary>
		/// <param name="node">The node that we are checking. </param>
		/// <returns>The height of the node.</returns>
		private int Height(AvlNode node)
		{
			return (node == null) ? -1 : node.Height;
		}

		/// <summary>
		/// Internal method to find the smallest item in a subtree.
		/// </summary>
		/// <param name="t">The node that roots the subtree.</param>
		/// <returns>The node containing the smallest item.</returns>
		private AvlNode FindMin(AvlNode t)
		{
			if (t == null)
			{
				throw new Exception("Cannot find the minimum value of an empty AVL tree.");
			}
			else if (t.Left == null)
			{
				return t;
			}
			return FindMin(t.Left);
		}

		/// <summary>
		/// Internal method to find the largest item in a subtree.
		/// </summary>
		/// <param name="t">The node that roots the subtree.</param>
		/// <returns>The node containing the largest item.</returns>
		private AvlNode FindMax(AvlNode t)
		{
			if (t == null)
			{
				throw new Exception("Cannot find the maximum value of an empty AVL tree.");
			}
			else if (t.Right == null)
			{
				return t;
			}
			return FindMax(t.Right);
		}

		/// <summary>
		/// Internal method to compare two nodes of the same type.
		/// </summary>
		/// <param name="lhs">The 1st node to compare.</param>
		/// <param name="rhs">The 2nd node to compare.</param>
		/// <returns>A negative int if lhs is larger; a positive int if rhs is larger; 0 if they are equal.</returns>
		private int Compare(T lhs, T rhs)
		{
			int retVal = 0;
			if (typeof(T) == typeof(int))
			{
				retVal = Convert.ToInt32(lhs) - Convert.ToInt32(rhs);
			}
			else if (typeof(T) == typeof(string))
			{
				retVal = string.Compare(Convert.ToString(lhs), Convert.ToString(rhs));
			}
			else
			{
				throw new NotImplementedException(String.Format("Compare for type <{0}> is not defined", typeof(T).ToString()));
			}

			return retVal;
		}

		/// <summary>
		/// Internal helper method used to balance subtree.
		/// </summary>
		/// <param name="subTree">The subtree to balance.</param>
		/// <returns>The root of the balanced subtree.</returns>
		private AvlNode Balance(AvlNode subTree)
		{
			if (subTree == null)
				return null;

			if((Height(subTree.Left) - Height(subTree.Right)) > ALLOWED_IMBALANCE)
			{
				if (Height(subTree.Left.Left) >= Height(subTree.Left.Right))
				{
					subTree = RotateWithLeftChild(subTree);
				}
				else
				{
					subTree = DoubleWithLeftChild(subTree);
				}
			}
			else if ((Height(subTree.Right) - Height(subTree.Left)) > ALLOWED_IMBALANCE)
			{
				if (Height(subTree.Right.Right) >= Height(subTree.Right.Left))
				{
					subTree = RotateWithRightChild(subTree);
				}
				else
				{
					subTree = DoubleWithRightChild(subTree);
				}
			}
			subTree.Height = Math.Max(Height(subTree.Left), Height(subTree.Right)) + 1;
			return subTree;
		}

		/// <summary>
		/// Rotate tree node with left child. For AVL trees, this is a single rotation for case 1. Update heights, then return new root.
		/// </summary>
		/// <param name="k2">The root of the subtree that will be rotated.</param>
		/// <returns>The root of the rotated subtree.</returns>
		private AvlNode RotateWithLeftChild(AvlNode k2)
		{
			AvlNode k1 = k2.Left;
			k2.Left = k1.Right;
			k1.Right = k2;
			k2.Height = Math.Max(Height(k2.Left), Height(k2.Right)) + 1;
			k1.Height = Math.Max(Height(k1.Left), k2.Height) + 1;
			return k1;
		}

		/// <summary>
		/// Rotate tree node with left child. For AVL trees, this is a single rotation for case 3. Update heights, then return new root.
		/// </summary>
		/// <param name="k2">The root of the subtree that will be rotated.</param>
		/// <returns>The root of the rotated subtree.</returns>
		private AvlNode RotateWithRightChild(AvlNode k2)
		{
			AvlNode k1 = k2.Right;
			k2.Right = k1.Left;
			k1.Left = k2;
			k2.Height = Math.Max(Height(k2.Right), Height(k2.Left)) + 1;
			k1.Height = Math.Max(Height(k1.Right), k2.Height) + 1;
			return k1;
		}

		/// <summary>
		/// Double rotate tree node. First left child with its right child; then node k3 with new left child.
		/// For AVL trees, this is a double rotation for case 2. Update heights, the return new root.
		/// </summary>
		/// <param name="k2">The node that roots subtree that will be rotated.</param>
		/// <returns>The node that roots the new subtree.</returns>
		private AvlNode DoubleWithLeftChild(AvlNode k3)
		{
			k3.Left = RotateWithRightChild(k3.Left);
			return RotateWithLeftChild(k3);
		}

		/// <summary>
		/// Double rotate tree node. First right child with its left child; then node k3 with new right child.
		/// For AVL trees, this is a double rotation for case 4. Update heights, the return new root.
		/// </summary>
		/// <param name="k2">The node that roots subtree that will be rotated.</param>
		/// <returns>The node that roots the new subtree.</returns>
		private AvlNode DoubleWithRightChild(AvlNode k3)
		{
			k3.Right = RotateWithLeftChild(k3.Right);
			return RotateWithRightChild(k3);
		}

		/// <summary>
		/// Internal method to remove item from subtree.
		/// </summary>
		/// <param name="x">The value to remove.</param>
		/// <param name="subTree">The node that roots the subtree.</param>
		/// <returns></returns>
		private AvlNode Remove(T x, AvlNode subTree)
		{
			if (subTree == null)
				return null;

			int compareResult = Compare(x, subTree.Element);
			if(compareResult < 0)
			{
				subTree.Left = Remove(x, subTree.Left);
			}
			else if(compareResult > 0)
			{
				subTree.Right = Remove(x, subTree.Right);
			}
			else if(subTree.Left != null && subTree.Right != null) //Two children
			{
				subTree.Element = FindMin(subTree.Right).Element;
				subTree.Right = Remove(subTree.Element, subTree.Right);
			}
			else
			{
				subTree = (subTree.Left != null) ? subTree.Left : subTree.Right;
			}

			return Balance(subTree);
		}

		/// <summary>
		/// Internal method to insert into a subtree.
		/// </summary>
		/// <param name="x">The item to insert.</param>
		/// <param name="subTree">The node that roots the subtree. </param>
		/// <returns></returns>
		private AvlNode Insert(T x, AvlNode subTree)
		{
			if (subTree == null)
				return new AvlNode(x, null, null);

			int compareResult = Compare(x, subTree.Element);
			if (compareResult < 0) {
				subTree.Left = Insert(x, subTree.Left);
			}
			else if (compareResult > 0) {
				subTree.Right = Insert(x, subTree.Right);
			}
			else {
				/* Duplicate; Do nothing. */
			}
			return Balance(subTree);
		}
		#endregion


		/// <summary>
		/// Public class implementation of the AVL tree node data structure;
		/// </summary>
		private class AvlNode
		{
			private T _element;
			private AvlNode _left;
			private AvlNode _right;
			private int _height;

			public AvlNode()
			{
				_element = default(T);
				_left = null;
				_right = null;
				_height = 0;
			}

			public AvlNode(T element)
			{
				_element = element;
			}

			public AvlNode(T element, AvlNode left, AvlNode right)
			{
				_element = element;
				_left = left;
				_right = right;
			}

			#region ------------------------------ PROPERTIES ------------------------------
			public T Element
			{
				get { return _element; }
				set { _element = value; }
			}

			public AvlNode Left
			{
				get { return _left; }
				set { _left = value; }
			}

			public AvlNode Right
			{
				get { return _right; }
				set { _right = value; }
			}

			public int Height
			{
				get { return _height; }
				set { _height = value; }
			}
			#endregion
		}
	}
}
