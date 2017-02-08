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
            int n = 5;
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

