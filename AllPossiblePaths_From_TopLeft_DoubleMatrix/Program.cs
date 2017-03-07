using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPossiblePaths_From_TopLeft_DoubleMatrix
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] mat = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[] result = new int[mat.GetLength(0) + mat.GetLength(1) - 1];
            print(mat, 0, 0, result, 0);
        }



        static public void print(int[,] arr, int row, int col, int[] result, int pos)
        {
            if (row == arr.GetLength(0) - 1 && col == arr.GetLength(1) - 1)
            {
                result[pos] = arr[row,col];
                result.ToList().ForEach(i => Console.Write(i.ToString()));
                Console.WriteLine();
                return;
            }
            if (row >= arr.GetLength(0) || col >= arr.GetLength(1))
            {
                return;
            }

            result[pos] = arr[row,col];
            print(arr, row, col + 1, result, pos + 1);
            print(arr, row + 1, col, result, pos + 1);            
        }
    }
    
}

//https://github.com/mission-peace/interview/blob/master/src/com/interview/recursion/PrintAllPathFromTopLeftToBottomRight.java
//http://www.geeksforgeeks.org/print-all-possible-paths-from-top-left-to-bottom-right-of-a-mxn-matrix/


//http://algorithms.tutorialhorizon.com/print-all-paths-from-top-left-to-bottom-right-in-two-dimensional-array/

//Average Difficulty : 3.5/5.0
//Based on 21 vote(s)