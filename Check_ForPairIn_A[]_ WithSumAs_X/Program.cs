using System;
namespace Check_ForPairIn_A_WithSumAs_X
{
    public class Program
    {
        //Note: If there are more than one pair having the given sum then the 1st algorithm still reports only one. Can be easily extended for though by 2nd one.
        public static void Main()
        {
            int[] A = { 1, 4, 45, 6, 10, 8 };
            int n = 14;
            int arr_size = 6;

            PrintPairs(A, arr_size, n);
            PrintPairsFaster(A, arr_size, n);
        }

        static void PrintPairs(int[] A, int arr_size, int n)
        {
            if (HasArrayTwoCandidates(A, arr_size, n))
                Console.WriteLine("Array has two elements with sum " + n);
            else
                Console.WriteLine("Array doesn't have two elements with sum " + n);
        }

        static void PrintPairsFaster(int[] arr, int arr_size, int sum)
        {
            int MAX = 100000; // Max size of Hashmap

            // Declares and initializes the whole array as false
            bool[] binmap = new bool[MAX];

            for (int i = 0; i < arr_size; ++i)
            {
                int temp = sum - arr[i];

                // checking for condition
                if (temp >= 0 && binmap[temp])
                {
                    Console.WriteLine("Pair with given sum " +
                                        sum + " is (" + arr[i] +
                                        ", " + temp + ")");
                }
                binmap[arr[i]] = true;
            }
        }

        static bool HasArrayTwoCandidates(int[] A, int arr_size, int sum)
        {
            int l, r;

            /* Sort the elements */
            QuickSort(A, 0, arr_size - 1);

            /* Now look for the two candidates in the sorted 
               array*/
            l = 0;
            r = arr_size - 1;
            while (l < r)
            {
                if (A[l] + A[r] == sum)
                    return true;
                else if (A[l] + A[r] < sum)
                    l++;
                else // A[i] + A[j] > sum
                    r--;
            }
            return false;
        }

        /* FOLLOWING FUNCTIONS ARE ONLY FOR SORTING PURPOSE */

        static int Partition(int[] A, int si, int ei)
        {
            int x = A[ei];
            int i = (si - 1);
            int j;

            for (j = si; j <= ei - 1; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    // swap A[i] and A[j]
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }
            // swap arr[i+1] and arr[high] (or pivot)
            int temp2 = A[i + 1];
            A[i + 1] = A[ei];
            A[ei] = temp2;
            return (i + 1);
        }

        /* Implementation of Quick Sort
        A[] --> Array to be sorted
        si  --> Starting index
        ei  --> Ending index
        */
        static void QuickSort(int[] A, int si, int ei)
        {
            int pi;    /* Partitioning index */
            if (si < ei)
            {
                pi = Partition(A, si, ei);
                QuickSort(A, si, pi - 1);
                QuickSort(A, pi + 1, ei);
            }
        }
    }
}


//http://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/