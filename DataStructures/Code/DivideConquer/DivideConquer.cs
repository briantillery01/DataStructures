using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DivideConquerAlgorithms
{
	class DivideConquer
	{
		private static Tuple<int,int,int> FindMaximumCrossing(int[] A, int low, int mid, int high)
		{
			int leftSum = int.MinValue;
			int maxLeft = 0;
			int sum = 0;
			for(int counter = mid; counter >= low; counter--)
			{
				sum = sum + A[counter];
				if(sum > leftSum)
				{
					leftSum = sum;
					maxLeft = counter;
				}
			}

			int rightSum = int.MinValue;
			int maxRight = 0;
			sum = 0;
			for(int counter = mid+1; counter <= high; counter++)
			{
				sum = sum + A[counter];
				if(sum > rightSum)
				{
					rightSum = sum;
					maxRight = counter;
				}
			}

			return new Tuple<int, int, int>(maxLeft,maxRight, leftSum + rightSum);
		}

		public static Tuple<int,int,int> FindMaximumSubarray(int[] A, int low, int high)
		{
			if(high==low)	//base case
			{
				return new Tuple<int, int, int>(low, high, A[low]);
			}

			else
			{
				int mid = (low + high) / 2; //truncated toward 0

				Tuple<int, int, int> lowerHalfTuple = FindMaximumSubarray(A, low, mid);
				Tuple<int, int, int> crossMidTuple = FindMaximumCrossing(A, low, mid, high);
				Tuple<int, int, int> upperHalfTuple = FindMaximumSubarray(A, mid+1, high);

				int leftSum = lowerHalfTuple.Item3;
				int crossSum = crossMidTuple.Item3;
				int rightSum = upperHalfTuple.Item3;

				if (leftSum >= rightSum && leftSum >= crossSum)
					return lowerHalfTuple;
				else if (rightSum >= leftSum && rightSum >= crossSum)
					return upperHalfTuple;
				else
					return crossMidTuple;
			}
		}
	}
}
