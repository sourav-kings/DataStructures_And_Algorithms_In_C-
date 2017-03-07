using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalNumber_Of_PossibleBSTs_With_N_keys
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4; //2--> 2; 3 --> 5; 4 --> 14; 5  --> 42
            Console.WriteLine(countBsts(n));
        }

        static int countBsts(int n)
        {

            int[] count = new int[n+1];
            count[0] = 1;
            for (int i = 1; i <= n; i++)
                count[i] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    count[i] += (count[i - j] * count[j - 1]);
                }
            }
            return count[n];
        }
    }
}
//http://code.geeksforgeeks.org/0hMPHL


//http://www.geeksforgeeks.org/g-fact-18/

//Average Difficulty : 3.3/5.0
//Based on 52 vote(s)

    /*
     * ALGO::
     * 
     * 0. 
     * 1. Call function with required number N.
     * 2. Create a new Count array. Set first value as 1.
     * 3. Set all other values as 0.
     * 4. FOR loop i from 1 to N.
     * 5.       FOR loop j from 1 to i.
     * 6.           Get Count[i - j] * Count[j - 1]
     * 7.           Set Count's current index as Count's current index + previous step value.
     * 8. Return the count[n] value.
     */
