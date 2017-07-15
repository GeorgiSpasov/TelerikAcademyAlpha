using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _10702.Defining_Classes_Part_2.Matrix
{
    public class Matrix<T>
    {
        private T[,] array2D;

        public Matrix(int rows, int cols)
        {
            this.array2D = new T[rows, cols];
        }

        public Matrix(T[,] arrayT)
        {
            this.array2D=arrayT;
        }

        public int Rows
        {
            get
            {
                return this.array2D.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.array2D.GetLength(1);
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

                return this.array2D[row, col];
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

                this.array2D[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);

            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArgumentOutOfRangeException("Passed nonmatching matrices!");
            }
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
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);

            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
            {
                throw new ArgumentOutOfRangeException("Passed nonmatching matrices!");
            }
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    result[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
                }
            }
            return result;
        }

        //public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        //{
        //    Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);

        //    if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
        //    {
        //        throw new ArgumentOutOfRangeException("Passed nonmatching matrices!");
        //    }
        //    for (int row = 0; row < m1.Rows; row++)
        //    {
        //        for (int col = 0; col < m1.Cols; col++)
        //        {
        //            result[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
        //        }
        //    }
        //    return result;
        //}

    }
}
