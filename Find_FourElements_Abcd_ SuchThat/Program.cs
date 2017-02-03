using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_FourElements_Abcd__SuchThat
{
    //Find four elements a, b, c and d in an array such that a+b = c+d
    /*
        Input:   {3, 4, 7, 1, 2, 9, 8}
        Output:  (3, 8) and (4, 7)
        Explanation: 3+8 = 4+7

        Input:   {3, 4, 7, 1, 12, 9};
        Output:  (4, 12) and (7, 9)
        Explanation: 4+12 = 7+9

        Input:  {65, 30, 7, 90, 1, 9, 8};
        Output:  No pairs found
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 7, 1, 2, 9, 8 };
            findPairs(arr);
        }
        static bool findPairs(int[] arr)
        {
            // Create an empty Hash to store mapping from sum to
            // pair indexes
            Dictionary<int, pair> map = new Dictionary<int, pair>();
            int n = arr.Length;

            // Traverse through all possible pairs of arr[]
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    // If sum of current pair is not in hash,
                    // then store it and continue to next pair
                    int sum = arr[i] + arr[j];
                    if (!map.ContainsKey(sum))
                        map[sum] = new pair(i, j);

                    else // Else (Sum already present in hash)
                    {
                        // Find previous pair
                        pair p = map[sum];

                        // Since array elements are distinct, we don't
                        // need to check if any element is common among pairs
                        Console.Write("(" + arr[p.first] + ", " + arr[p.second] +
                                          ") and (" + arr[i] + ", " + arr[j] + ")");
                        return true;
                    }
                }
            }
            return false;
        }
    }

    // Class to represent a pair
    class pair
    {
        public int first, second;
        public pair(int f, int s)
        {
            first = f; second = s;
        }
    };
}

//http://www.geeksforgeeks.org/find-four-elements-a-b-c-and-d-in-an-array-such-that-ab-cd/