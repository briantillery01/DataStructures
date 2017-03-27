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
            string result = "";

            Node node1 = new Node(10);
            Node node2 = new Node(5);
            Node node3 = new Node(15);
            Node node4 = new Node(20);
            Node node5 = new Node(0);
            Node node6 = new Node(2);
            Node node7 = new Node(4);

            LinkedList linkedList = new LinkedList();

            linkedList.InsertFront(node1); //10
            result = linkedList.PrintForward();
            Console.WriteLine(result);
            result = linkedList.PrintBackward();
            Console.WriteLine(result);
            linkedList.Clear();

            linkedList.InsertBack(node1); //10
            result = linkedList.PrintForward();
            Console.WriteLine(result);
            result = linkedList.PrintBackward();
            Console.WriteLine(result);
            linkedList.Clear();

            linkedList.InsertAt(node1, 0); //10
            result = linkedList.PrintForward();
            Console.WriteLine(result);
            result = linkedList.PrintBackward();
            Console.WriteLine(result);
            linkedList.Clear();

            linkedList.InsertAt(node1, -1); //Error
            result = linkedList.PrintForward();
            Console.WriteLine(result);
            result = linkedList.PrintBackward();
            Console.WriteLine(result);
            linkedList.Clear();

            linkedList.InsertAt(node1, 1); //Error
            result = linkedList.PrintForward();
            Console.WriteLine(result);
            result = linkedList.PrintBackward();
            Console.WriteLine(result);
            linkedList.Clear();

            linkedList.InsertFront(node1);
            linkedList.InsertBack(node2);
            linkedList.InsertAt(node3, 2);
            linkedList.InsertAt(node4, 1);
            linkedList.InsertAt(node5, 0);
            linkedList.InsertAt(node6, 4);
            linkedList.InsertAt(node7, 5);
            result = linkedList.PrintForward(); //[0,10,20,5,2,4,15]
            Console.WriteLine(result);
            result = linkedList.PrintBackward(); //[15,4,2,5,20,10,0]
            Console.WriteLine(result);
            linkedList.Clear();
            int x = 0;

        }
    }
}
