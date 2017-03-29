using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Elements;

namespace DataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			BinaryNode<int> bn1 = new BinaryNode<int>(1, null, null);
			BinaryNode<int> bn2 = new BinaryNode<int>(2, null, null);
			BinaryNode<string> bn3 = new BinaryNode<string>("a", null, null);
			BinaryNode<string> bn4 = new BinaryNode<string>("b", null, null);
			BinaryNode<int> bn5 = new BinaryNode<int>(1, null, null);
			BinaryNode<int> bn6 = new BinaryNode<int>(2, null, null);
			BinaryNode<string> bn7 = new BinaryNode<string>("a", null, null);
			BinaryNode<string> bn8 = new BinaryNode<string>("b", null, null);

			bn1.Compare(bn2);
			bn3.Compare(bn4);
			bn5.Compare(bn6);
			bn7.Compare(bn8);
		}
	}
}
