using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Steps_To_Reach_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            int dest = 11;
            Console.Write("No. of steps required to reach " + dest + " is " + steps(0, 0, dest));
        }

        // Function to count number of steps required to reach a
        // destination.
        // source -> source vertex
        // step -> value of last step taken
        // dest -> destination vertex
        static int steps(int source, int step, int dest)
        {
            // base cases
            if (Math.Abs(source) > (dest)) return int.MaxValue;
            if (source == dest) return step;

            // at each point we can go either way

            // if we go on positive side
            int pos = steps(source + step + 1, step + 1, dest);

            // if we go on negative side
            int neg = steps(source - step - 1, step + 1, dest);

            // minimum of both cases
            return Math.Min(pos, neg);
        }
    }
}
//http://www.geeksforgeeks.org/minimum-steps-to-reach-a-destination/