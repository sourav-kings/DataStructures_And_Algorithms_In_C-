using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median_In_Stream_Of_Integers
{
    class Program
    {
        static List<double> m_listNum = new List<double>();

        static void Main(string[] args)
        {
            double[] A = { 5, 15, 1, 3, 2, 8, 7, 9, 10, 6, 11, 4 };
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < A.Length; i++)
            {
                s.Append(A[i] + ", ");
                Console.WriteLine("After reading element no. " + (i+1) + " of stream: - " + s);
                AddNum(A[i]);
                Console.WriteLine("Median:-  " + FindMedian());
                Console.WriteLine();
            }
                

            
        }

        static void AddNum(double num)
        {

            int lintPos = m_listNum.BinarySearch(num);
            if (lintPos >= 0)
            {
                m_listNum.Insert(lintPos, num);
            }
            else
            {
                lintPos = ~lintPos;
                if (lintPos == m_listNum.Count)
                {
                    m_listNum.Add(num);
                }
                else
                {
                    m_listNum.Insert(lintPos, num);
                }
            }
        }

        // return the median of current data stream

        static double FindMedian()
        {

            int lintCount = m_listNum.Count;

            if (lintCount == 0) throw new Exception("array is empty");

            if (lintCount % 2 == 0)
                return (m_listNum[lintCount / 2 - 1] + m_listNum[lintCount / 2]) / 2;
            else
                return m_listNum[lintCount / 2];
        }

    }


}
//currently Binary Search is used. Try to implement HEAPS to further optimise.

//https://discuss.leetcode.com/topic/39588/c-solution-with-binarysearch

//https://gist.github.com/Vedrana/3675434

//http://www.geeksforgeeks.org/median-of-stream-of-integers-running-integers/

//http://www.ardendertat.com/2011/11/03/programming-interview-questions-13-median-of-integer-stream/

//http://stackoverflow.com/questions/10657503/find-running-median-from-a-stream-of-integers