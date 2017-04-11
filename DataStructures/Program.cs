using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.AbstractDT;
using DataStructures.Trees;
using DataStructures.DivideConquerAlgorithms;

namespace DataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start test.");


			//int[] testArray = { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

			//Tuple<int,int,int> answer = DivideConquer.FindMaximumSubarray(testArray, 0, testArray.Count() - 1);
			//Console.WriteLine("Subarray: A[{0}..{1}]\nSum: {2}", answer.Item1,answer.Item2,answer.Item3);

			//double[,] test = new double[2, 2] { { 1, 2 }, { 3, 4 } };

			//Matrix M = new Matrix(test);

			//double value = Matrix.Determinate(M);
			//Console.WriteLine("Value of determinate: {0}", value);

			Matrix M = Matrix.GenerateRandomMatrix(5);
			Console.WriteLine(M.ToString());

			Matrix W = Matrix.Inverse(M);
			Console.WriteLine(W.ToString());
			Console.WriteLine("End test.");
		}
	}
}
