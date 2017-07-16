using System;
using _10702.Defining_Classes_Part_2.Generic;
using _10702.Defining_Classes_Part_2.Space3D;
using _10702.Defining_Classes_Part_2.Matrix;
using System.Text;

namespace _10702.Defining_Classes_Part_2
{
    public class Test
    {
        static void Main(string[] args)
        {
            #region GenericList
            //GenericList<Point3D> pointsArray = new GenericList<Point3D>(2);
            //pointsArray.AddElement(Point3D.O); // Not printed (default value)
            //pointsArray.AddElement(new Point3D(1, 1, 1));
            //pointsArray.AddElement(new Point3D(2, 2, 2));
            //pointsArray.AddElement(new Point3D(3, 3, 3));
            //pointsArray.AddElement(new Point3D(4, 4, 4));
            //pointsArray.AddElement(new Point3D(5, 5, 5));

            //Console.WriteLine(pointsArray + "\n");
            //Console.WriteLine(pointsArray.GetElement(2) + "\n");

            //pointsArray.RemoveElement(2);
            //Console.WriteLine(pointsArray + "\n");

            //pointsArray.InsertElementAt(2, new Point3D(9, 9, 9));
            //Console.WriteLine(pointsArray + "\n");

            //Console.WriteLine(pointsArray.FindElement(new Point3D(7, 7, 7)));

            //pointsArray.ClearList();
            //Console.WriteLine(pointsArray + "\n"); 
            #endregion

            Matrix<int> intMatrix = new Matrix<int>(5, 6);
            for (int row = 0; row < intMatrix.Rows; row++)
            {
                for (int col = 0; col < intMatrix.Cols; col++)
                {
                    intMatrix[row, col] = row + col;
                }
            }
            PrintMatrix(intMatrix);

            int[,] a1 =
             {
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5}
            };
            int[,] a2 =
             {
                {10, 10, 10, 10, 10},
                {10, 10, 10, 10, 10},
                {10, 10, 10, 10, 10}
            };
            Matrix<int> m1 = new Matrix<int>(a1);
            PrintMatrix(m1);
            Console.WriteLine();
            Matrix<int> m2 = new Matrix<int>(a2);
            PrintMatrix(m2);
            Console.WriteLine();
            PrintMatrix(m1 + m2);
            Console.WriteLine();
            PrintMatrix(m1 - m2);
            Console.WriteLine();

            int[,] b1 =
             {
                {10, 10, 10},
                {10, 10, 10}
            };
            int[,] b2 =
             {
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5},
                {1, 2, 3, 4, 5}
            };
            Matrix<int> n1 = new Matrix<int>(b1);
            PrintMatrix(n1);
            Console.WriteLine();
            Matrix<int> n2 = new Matrix<int>(b2);
            PrintMatrix(n2);
            Console.WriteLine();
            PrintMatrix(n1 * n2);
            Console.WriteLine();

            if (n1)
            {
                Console.WriteLine("The matrix has no zero elements.");
            }
        }

        public static void PrintMatrix<T>(Matrix<T> matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols - 1; col++)
                {
                    sb.Append(matrix[row, col] + " ");
                }
                sb.Append(matrix[row, matrix.Cols - 1] + "\n");
            }
            Console.Write(sb.ToString());
        }
    }
}
