using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Elements;

namespace DataStructures.Searches
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
	}
}
