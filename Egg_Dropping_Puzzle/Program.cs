using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egg_Dropping_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2, k = 10;
            Console.WriteLine("\nMinimum number of trials in worst case with "+ n +" eggs and "+ k +" floors is " + eggDrop_DynamicProgramming(n, k));
        }

        // A utility function to get maximum of two integers
        static int max(int a, int b) { return (a > b) ? a : b; }

        /* Function to get minimum number of trials needed in worst
          case with n eggs and k floors */
        static int eggDrop(int n, int k)
        {
            // If there are no floors, then no trials needed. OR if there is
            // one floor, one trial needed.
            if (k == 1 || k == 0)
                return k;

            // We need k trials for one egg and k floors
            if (n == 1)
                return k;

            int min = int.MaxValue, x, res;

            // Consider all droppings from 1st floor to kth floor and
            // return the minimum of these values plus 1.
            for (x = 1; x <= k; x++)
            {
                res = max(eggDrop(n - 1, x - 1), eggDrop(n, k - x));
                if (res < min)
                    min = res;
            }

            return min + 1;
        }



        /* Function to get minimum number of trials needed in worst
            case with n eggs and k floors */
        static int eggDrop_DynamicProgramming(int n, int k)
        {
            /* A 2D table where entery eggFloor[i,j] will represent minimum
            number of trials needed for i eggs and j floors. */
            int[,] eggFloor = new int[n + 1,k + 1];
        int res;
        int i, j, x;
          
        // We need one trial for one floor and0 trials for 0 floors
        for (i = 1; i <= n; i++)
        {
            eggFloor[i,1] = 1;
            eggFloor[i,0] = 0;
        }
          
       // We always need j trials for one egg and j floors.
        for (j = 1; j <= k; j++)
            eggFloor[1,j] = j;
          
        // Fill rest of the entries in table using optimal substructure
        // property
        for (i = 2; i <= n; i++)
        {
            for (j = 2; j <= k; j++)
            {
                eggFloor[i,j] =int.MaxValue;
                for (x = 1; x <= j; x++)
                {
                     res = 1 + max(eggFloor[i - 1,x - 1], eggFloor[i,j - x]);
                     if (res<eggFloor[i,j])
                        eggFloor[i,j] = res;
                }
            }
        }
          
        // eggFloor[n,k] holds the result
        return eggFloor[n,k];
 
    }
    }
}

//http://www.geeksforgeeks.org/dynamic-programming-set-11-egg-dropping-puzzle/


//Average Difficulty : 4.3/5.0
//Based on 110 vote(s)