using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.AbstractDT
{
	// current only supports 2d matrix
	public class Matrix
	{
		private int _rowCnt; //row
		private int _columnCnt; //column
		private double[][] _matrix; //use 'jagged' array for best performance

		public Matrix(int n) : this(n, n) { }

		public Matrix(int n, int m)
		{
			_rowCnt = n;
			_columnCnt = m;
			_matrix = new double[n][]; //n rows

			for (int row = 0; row < n; row++) { _matrix[row] = new double[m]; }
		}

		public Matrix(int n, int m, int defaultValue)
		{
			_rowCnt = n;
			_columnCnt = m;
			_matrix = new double[n][]; //n rows

			for(int row = 0; row < n; row++)
			{
				_matrix[row] = new double[m];
				for (int col = 0; col < m; col++)
				{
					_matrix[row][col] = defaultValue;
				}
			}
		}

		public Matrix(double[][] values)
		{
			_matrix = values;
			_rowCnt = _matrix.GetLength(0);
			_columnCnt = _matrix.GetLength(1);	
		}

		#region Non-Static Methods
		public double Determinate()
		{
			double determinate = Matrix.Determinate(this);
			return determinate;
		}

		public Matrix IdentityMatrix()
		{
			Matrix IdentityMatrix = Matrix.IdentityMatrix(this.RowCnt, this.ColumnCnt);
			return IdentityMatrix;
		}

		public Matrix InverseMatrix()
		{
			Matrix InverseMatrix = Matrix.Inverse(this);
			return InverseMatrix;
		}

		public Matrix TransposeMatrix()
		{
			Matrix TransposeMatrix = Matrix.TransposeMatrix(this);
			return TransposeMatrix;
		}
		#endregion


		#region Static Methods
		public static Matrix operator +(Matrix A, Matrix B)
		{
			return MatrixAddition(A, B);
		}

		public static Matrix operator -(Matrix A)
		{
			return MatrixMultiplication(-1, A);
		}

		public static Matrix operator -(Matrix A, Matrix B)
		{
			return MatrixSubtraction(A, B);
		}

		public static Matrix operator *(double scalar, Matrix A)
		{
			return MatrixMultiplication(scalar, A);
		}

		public static Matrix operator *(Matrix A, Matrix B)
		{
			return MatrixMultiplication(A, B);
		}

		private static Matrix CreateSmallerMatrix(Matrix A, int i, int j)
		{
			int order = A.RowCnt;
			Matrix retMatrix = new Matrix(order - 1, order - 1);
			int x = 0, y = 0;
			for (int m = 0; m < order; m++, x++)
			{
				if (m != i)
				{
					y = 0;
					for (int n = 0; n < order; n++)
					{
						if (n != j)
						{
							retMatrix[x, y] = A[m, n];
							y++;
						}
					}
				}
				else
					x--;
			}

			return retMatrix;
		}

		public static double Determinate(Matrix A)
		{
			if (A == null)
				throw new MatrixOperationException("Can not calculate determinate from undefined matrix.");
			else if (!A.IsSquare)
				throw new MatrixOperationException("Can not calculate determinate from non-square matrix.");

			if (A.RowCnt > 2)
			{
				double value = 0;
				for (int i = 0; i < A.RowCnt; i++)
				{
					Matrix temp = CreateSmallerMatrix(A, 0, i);
					value = value + A[0, i] * (SignOfElement(0, i) * Determinate(temp));
				}
				return value;
			}

			else if (A.RowCnt == 2)
			{
				return ((A[0, 0] * A[1, 1]) - (A[1, 0] * A[0, 1])); //AD-BC
			}

			else
			{
				return A[0, 0];
			}
		}		

		public static Matrix GenerateRandomMatrix(int n)
		{
			return GenerateRandomMatrix(n, n, int.MinValue, int.MaxValue);
		}

		public static Matrix GenerateRandomMatrix(int n, int m)
		{
			return GenerateRandomMatrix(n, m, int.MinValue, int.MaxValue);
		}

		public static Matrix GenerateRandomMatrix(int n, int m, int upperLimit)
		{
			return GenerateRandomMatrix(n, m, int.MinValue, upperLimit);
		}

		public static Matrix GenerateRandomMatrix(int n, int m, int lowerLimit, int upperLimit)
		{
			Random rng = new Random();
			Matrix retMatrix = new Matrix(n, m);
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					retMatrix[i, j] = rng.Next(lowerLimit, upperLimit);
				}
			}

			return retMatrix;
		}

		public static Matrix IdentityMatrix(int n)
		{
			return IdentityMatrix(n, n);
		}

		public static Matrix IdentityMatrix(int n, int m)
		{
			Matrix identity = new Matrix(n);
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (i == j)
						identity[i, i] = 1;
					else
						identity[i, j] = 0;
				}
			}

			return identity;
		}

		public static Matrix Inverse(Matrix A)
		{
			if (A == null)
				throw new MatrixOperationException("Can not create inverse matrix. The supplied matrix is undefined.");
			else if (!A.IsSquare)
				throw new MatrixOperationException("Can not create inverse matrix. The supplied matrix is not square.");

			double determinate = Determinate(A);
			if(determinate == 0)
				throw new MatrixOperationException("Can not create inverse matrix. Determinate is 0.");

			Matrix retMatrix = new Matrix(A.RowCnt, A.RowCnt);
			for (int i = 0; i < A.RowCnt; i++)
			{
				for (int j = 0; j < A.RowCnt; j++)
				{
					retMatrix[i,j] = A[i, j] * determinate;
				}
			}
			return retMatrix;
		}

		public static Matrix MatrixAddition(Matrix A, Matrix B)
		{
			if (A == null || B == null)
				throw new MatrixOperationException("Can not perform matrix addition. Undefined matrix present.");
			else if (A.RowCnt != B.RowCnt)
				throw new MatrixOperationException("Can not perform matrix addition. The supplied matricies have a row count mismatch.");
			else if (A.ColumnCnt != B.ColumnCnt)
				throw new MatrixOperationException("Can not perform matrix addition. The supplied matricies have a column count mismatch.");

			Matrix retMatrix = new Matrix(A.RowCnt, A.ColumnCnt);
			for (int i = 0; i < A.RowCnt; i++)
			{
				for (int j = 0; j < A.ColumnCnt; j++)
				{
					retMatrix[i, j] = A[i, j] + B[i, j];
				}
			}
			return retMatrix;
		}

		public static Matrix MatrixMultiplication(double scalar, Matrix A)
		{
			if (A == null)
				throw new MatrixOperationException("Can not perform multiplication. The supplied matrix is undefined.");

			Matrix retMatrix = new Matrix(A.RowCnt, A.ColumnCnt);
			for (int i = 0; i < A.RowCnt; i++)
			{
				for (int j = 0; j < A.ColumnCnt; j++)
				{
					retMatrix[i, j] = scalar * A[i, j];
				}
			}

			return retMatrix;
		}

		public static Matrix MatrixMultiplication(Matrix A, Matrix B)
		{
			return null;
		}

		public static Matrix MatrixSubtraction(Matrix A, Matrix B)
		{
			if (A == null || B == null)
				throw new MatrixOperationException("Can not perform matrix subtraction. Undefined matrix present.");
			else if (A.RowCnt != B.RowCnt)
				throw new MatrixOperationException("Can not perform matrix subtraction. The supplied matricies have a row count mismatch.");
			else if (A.ColumnCnt != B.ColumnCnt)
				throw new MatrixOperationException("Can not perform matrix subtraction. The supplied matricies have a column count mismatch.");

			Matrix retMatrix = new Matrix(A.RowCnt, A.ColumnCnt);
			for (int i = 0; i < A.RowCnt; i++)
			{
				for (int j = 0; j < A.ColumnCnt; j++)
				{
					retMatrix[i, j] = A[i, j] - B[i, j];
				}
			}
			return retMatrix;
		}

		private static int SignOfElement(int i, int j)
		{
			if ((i + j) % 2 == 0)
				return 1;
			else
				return -1;
		}

		public static Matrix SquareMatrixMultiply(Matrix B)
		{
			return null;
		}

		public static Matrix SquareMatrixMultiply(Matrix A, Matrix B)
		{
			if (A == null || B == null || !A.IsSquare || !B.IsSquare || A.RowCnt != B.ColumnCnt)
				return null;

			return null;
		}

		public static Matrix TransposeMatrix(Matrix A)
		{
			Matrix retMatrix = new Matrix(A.ColumnCnt, A.RowCnt);
			for(int i = 0; i < A.RowCnt; i++)
			{
				for (int j = 0; j < A.ColumnCnt; j++)
				{
					retMatrix[j,i] = A[i,j];
				}
			}

			return retMatrix;
		}

		public static Matrix ZeroMatrix(int n)
		{
			return ZeroMatrix(n, n);
		}

		public static Matrix ZeroMatrix(int n, int m)
		{
			Matrix zero = new Matrix(n);
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (i == j)
						zero[i, i] = 1;
					else
						zero[i, j] = 0;
				}
			}

			return zero;
		}
		#endregion


		#region Properties
		public int ColumnCnt
		{
			get { return _columnCnt; }
		}

		public bool IsSquare
		{
			get { return _rowCnt == _columnCnt; }
		}

		public int Length
		{
			get { return _matrix.Length; }
		}

		public int RowCnt
		{
			get { return _rowCnt; }
		}

		public double this[int index1, int index2]
		{
			get { return _matrix[index1][index2]; }
			set { _matrix[index1][index2] = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			string sep = "";
			for (int i = 0; i < RowCnt; i++)
			{
				sep = "";
				sb.Append("[");
				for (int j = 0; j < ColumnCnt; j++)
				{
					sb.Append(string.Format("{0}{1}", sep, _matrix[i][j]));
					//sb.Append(string.Format("{0,5:E2}{1}", sep, _matrix[i][j]));
					sep = " ";
				}
				sb.Append("]");
				sb.AppendLine();
			}

			return sb.ToString();
		}
		#endregion


		private class MatrixOperationException : Exception
		{
			public MatrixOperationException() { }
			public MatrixOperationException(string message) : base(message) { }
			public MatrixOperationException(string message, Exception inner) : base(message, inner) { }
		}
	}
}
