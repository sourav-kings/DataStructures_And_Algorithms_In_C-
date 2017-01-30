using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Boolean_Matrix_Question
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixMethod2 = new int[,] {
                                    {1,0,0,1},
                                    {0,0,1,0},
                                    {0,0,0,0}
                                };


            var setOneToOne = true;
            Console.WriteLine("Original Boolean Matrix: ");
            PrintMatrix(matrixMethod2);
            Console.WriteLine();

            Console.WriteLine("Boolean Matrix after conversion: Method-2");
            ConvertRowsnColsMethod2(matrixMethod2, setOneToOne);
            PrintMatrix(matrixMethod2);
        }

        private static void ConvertRowsnColsMethod2(int[,] matrix, bool IsSetOneToOneTrue)
        {
            var rows = matrix.GetUpperBound(0);
            var cols = matrix.GetUpperBound(1);
            bool rowStatus = false;
            bool colStatus = false;

            //To Support  Zero to Zero Conversion OR 1 to 1 Conversion
            int valueToCheck = 0;
            if (IsSetOneToOneTrue)
                valueToCheck = 1;

            for (int row = 0; row <= rows; row++)
            {
                if (matrix[row, 0] == valueToCheck)
                    colStatus = true;
            }

            for (int col = 0; col <= cols; col++)
            {
                if (matrix[0, col] == valueToCheck)
                    rowStatus = true;
            }

            for (int row = 1; row <= rows; row++)
            {
                for (int col = 1; col <= cols; col++)
                {
                    if (matrix[row, col] == valueToCheck)
                    {
                        matrix[0, col] = valueToCheck;
                        matrix[row, 0] = valueToCheck;
                    }
                }
            }

            //PrintMatrix(matrix);
            for (int row = 1; row <= rows; row++)
            {
                for (int col = 1; col <= cols; col++)
                {
                    if (matrix[row, 0] == valueToCheck || matrix[0, col] == valueToCheck)
                    {
                        matrix[row, col] = valueToCheck;
                    }
                }
            }

            if (rowStatus)
            {
                for (int row = 0; row <= rows; row++)
                    matrix[row, 0] = valueToCheck;
            }

            if (colStatus)
            {
                for (int col = 0; col <= cols; col++)
                    matrix[0, col] = valueToCheck;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row <= matrix.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= matrix.GetUpperBound(1); col++)
                {
                    Console.Write(" {0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}


//http://www.geeksforgeeks.org/a-boolean-matrix-question/
//http://ideone.com/8SbDqn