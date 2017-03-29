using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Elements;

namespace DataStructures.Searches
{
	class BinarySearchTree<T>
	{
		private BinaryNode<T> _root;

		public BinarySearchTree()
		{
			_root = null;
		}

		private Boolean Contains<T> (T value, BinaryNode<T> subTree)
		{
			if (subTree == null)
			{
				return false; //no subtree
			}

			//int compareResult = 
			return false;
		}


	}
}
