using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Elements
{
	class BinaryNode<T>
	{
		private T _element;
		private BinaryNode<T> _firstChild;
		private BinaryNode<T> _nextSibling;

		public BinaryNode()
		{
			_element = default(T);
			_firstChild = null;
			_nextSibling = null;
		}

		public BinaryNode(T element, BinaryNode<T> firstChild, BinaryNode<T> nextSibling) 
			: this()
		{
			_element = element;
			_firstChild = firstChild;
			_nextSibling = nextSibling;
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

		public BinaryNode<T> FirstChild
		{
			get { return _firstChild; }
			set { _firstChild = value; }
		}

		public BinaryNode<T> NextSibling
		{
			get { return _nextSibling; }
			set { _nextSibling = value; }
		}

		public int Compare(BinaryNode<T> node)
		{
			int retVal = 0;

			//if(_elementType != node.ElementType)
			//{
			//	throw new Exception(String.Format("Cannot compare types: {0} and {1}.", _elementType.ToString(), node.ElementType.ToString()));
			//}

			if(typeof(T) == typeof(int))
			{
				retVal = Convert.ToInt32(_element) - Convert.ToInt32(node.Element);
			} else if (typeof(T) == typeof(string))
			{
				retVal = string.Compare(Convert.ToString(_element), Convert.ToString(node.Element));
			}

			return retVal;
		}
	}
}
