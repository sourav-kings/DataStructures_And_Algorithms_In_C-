using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Boolean_Matrix_Question
{
    class Program
    {
        const int R = 3;
        const int C = 4;
        static void Main(string[] args)
        {
            var matrixMethod2 = new int[,] {
                                    {1,0,0,1},
                                    {0,0,1,0},
                                    {0,0,0,0}
                                };

            //Method 2 (A Space Optimized Version of Method 1)
            //var setOneToOne = true;
            //Console.WriteLine("Original Boolean Matrix: ");
            //PrintMatrix(matrixMethod2);
            //Console.WriteLine();

            //Console.WriteLine("Boolean Matrix after conversion: Method-2");
            //ConvertRowsnColsMethod2(matrixMethod2, setOneToOne);
            //PrintMatrix(matrixMethod2);


            Console.WriteLine("Input Matrix \n");
            printMatrix(matrixMethod2);

            modifyMatrix(matrixMethod2);

            Console.WriteLine("Matrix after modification \n");
            printMatrix(matrixMethod2);

        }

        //Method 2 (A Space Optimized Version of Method 1)
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


        static void modifyMatrix(int[,] mat)
        {
            int[] row = new int[R];
            int[] col = new int[C]; ;

            int i, j;


            /* Initialize all values of row[] as 0 */
            for (i = 0; i < R; i++)
                row[i] = 0;


            /* Initialize all values of col[] as 0 */
            for (i = 0; i < C; i++)
                col[i] = 0;


            /* Store the rows and columns to be marked as 1 in row[] and col[]
               arrays respectively */
            for (i = 0; i < R; i++)
                for (j = 0; j < C; j++)
                    if (mat[i,j] == 1)
                        row[i] = col[j] = 1;
                    

            /* Modify the input matrix mat[] using the above constructed row[] and
               col[] arrays */
            for (i = 0; i < R; i++)
                for (j = 0; j < C; j++)
                    if (row[i] == 1 || col[j] == 1)
                        mat[i,j] = 1;
        }

        /* A utility function to print a 2D matrix */
        static void printMatrix(int[,] mat)
        {
            int i, j;
            for (i = 0; i < R; i++)
            {
                for (j = 0; j < C; j++)
                {
                    Console.Write(mat[i,j] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}


//http://www.geeksforgeeks.org/a-boolean-matrix-question/
//http://ideone.com/8SbDqn

//Average Difficulty : 2.7/5.0
//Based on 62 vote(s)