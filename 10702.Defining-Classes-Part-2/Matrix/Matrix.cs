using System;

namespace _10702.Defining_Classes_Part_2.Matrix
{
    public class Matrix<T>
    {
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
        }

        public Matrix(T[,] arrayT)
        {
            this.matrix = arrayT;
        }

        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.Rows)
                {
                    throw new IndexOutOfRangeException($"Row index {row} is invalid");
                }
                if (col < 0 || col >= this.Cols)
                {
                    throw new IndexOutOfRangeException($"Col index {col} is invalid");
                }

                return this.matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= this.Rows)
                {
                    throw new IndexOutOfRangeException($"Row index {row} is invalid");
                }
                if (col < 0 || col >= this.Cols)
                {
                    throw new IndexOutOfRangeException($"Col index {col} is invalid");
                }

                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArgumentOutOfRangeException("Passed nonmatching matrices!");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    result[row, col] = (dynamic)m1[row, col] + (dynamic)m2[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArgumentOutOfRangeException("Passed nonmatching matrices!");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    result[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Cols != m2.Rows)
            {
                throw new ArgumentOutOfRangeException("Passed nonmatching matrices!");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m2.Cols);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        result[row, col] += (dynamic)m1[row, k] * (dynamic)m2[k, col];
                    }
                }
            }
            return result;
        }

    }
}
