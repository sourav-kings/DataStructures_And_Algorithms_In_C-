using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_TwoSortedArrays_With_O_1_ExtraSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] ar1 = { 1, 5, 9, 10, 15, 20 };
            //int[] ar2 = { 2, 3, 8, 13 };

            int[] ar1 = { 1, 5, 9, 10, 15, 20 };
            int[] ar2 = { 2, 3, 8, 13 };

            int m = ar1.Length;
            int n = ar2.Length;
            merge(ar1, ar2, m, n);

            Console.WriteLine("After Merging \nFirst Array: ");
            for (int i = 0; i < m; i++)
                Console.Write(ar1[i] + " ");
            Console.WriteLine("\nSecond Array: ");
            for (int i = 0; i < n; i++)
                Console.Write(ar2[i] + " ");
        }

        //static void merge(int[] ar1, int[] ar2, int m, int n)
        //{
        //    for (int i = n - 1; i >= 0; i--)
        //    {

        //        int j = 0;
        //        /*  Loop from last element of ar1[] while element ar1[j] is 
        //            smaller than ar2[i]. */
        //        while (ar1[j] < ar2[i] && j < m)
        //            j++;

        //        /*  If any element of ar1[] was moved or j < m */
        //        if (j < m)
        //        {
        //            int last = ar1[m - 1];
        //            int temp = j;

        //            // shift all elements of ar1 by one place
        //            for (int k = m - 1; k > j; k--)
        //            {
        //                ar1[k] = ar1[k - 1];
        //            }

        //            // insert element from ar2 to that place in ar1
        //            ar1[temp] = ar2[i];
        //            ar2[i] = last;
        //        }
        //    }
        //}

        // Merge ar1[] and ar2[] with O(1) extra space
        static void merge(int[] ar1, int[] ar2, int m, int n)
        {
            // Iterate through all elements of ar2[] starting from
            // the last element
            for (int i = n - 1; i >= 0; i--)
            {
                /* Find the smallest element greater than ar2[i]. Move all
                   elements one position ahead till the smallest greater
                   element is not found */
                int j, last = ar1[m - 1];
                for (j = m - 2; j >= 0 && ar1[j] > ar2[i]; j--)
                    ar1[j + 1] = ar1[j];

                // If there was a greater element
                if (j != m - 2 || last > ar2[i])
                {
                    ar1[j + 1] = ar2[i];
                    ar2[i] = last;
                }
            }
        }

    }
}
//http://code.geeksforgeeks.org/2bCnnP

//http://www.geeksforgeeks.org/merge-two-sorted-arrays-o1-extra-space/


//Average Difficulty : 3/5.0
//Based on 80 vote(s)