using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
	/// <summary>
	/// Public class implementation of the AVL tree data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the tree.</typeparam>
	class AvlTree<T>
	{
		private AvlNode<T> _root;

		public AvlTree()
		{
			_root = null;
		}

		private int height(AvlNode<T> node)
		{
			return (node == null) ? -1 : node.Height;
		}



		/// <summary>
		/// Public class implementation of the AVL tree node data structure;
		/// </summary>
		/// <typeparam name="T">The data type of the value that will be kept in the node.</typeparam>
		private class AvlNode<T>
		{
			private T _element;
			private AvlNode<T> _left;
			private AvlNode<T> _right;
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

			public AvlNode(T element, AvlNode<T> left, AvlNode<T> right)
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

			public AvlNode<T> Left
			{
				get { return _left; }
				set { _left = value; }
			}

			public AvlNode<T> Right
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
