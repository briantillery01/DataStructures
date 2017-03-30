namespace DataStructures.Elements
{
	/// <summary>
	/// Public class implementation of the linked list node data structure;
	/// </summary>
	/// <typeparam name="T">The data type of the value that will be kept in the node.</typeparam>
	public class Node<T>
	{
		private Node<T> _prev;
		private Node<T> _next;
		private T _data;

		public Node()
		{
			_prev = null;
			_next = null;
			_data = default(T);
		}

		public Node(T cargo) 
			: this()
		{
			_data = cargo;
		}

		public Node(Node<T> prev, Node<T> next, T cargo) 
			: this()
		{
			_prev = prev;
			_next = next;
			_data = cargo;
		}

		public Node<T> PreviousNode
		{
			get { return _prev; }
			set { _prev = value; }
		}

		public Node<T> NextNode
		{
			get { return _next; }
			set { _next = value; }
		}

		public T Data
		{
			get { return _data; }
			set { _data = value; }
		}

		public override string ToString()
		{
			return _data.ToString();
		}

	}
}
