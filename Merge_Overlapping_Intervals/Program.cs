using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Overlapping_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Interval[] arr = new Interval[] 
            { new Interval(6,8), new Interval(1, 9), new Interval(2, 4), new Interval(4, 7) };
            int n = arr.Length;
            mergeIntervalsFaster(arr, n);
        }


        // The main function that takes a set of intervals, merges
        // overlapping intervals and prints the result
        static void mergeIntervals(Interval[] arr, int n)
        {
            // Test if the given set has at least one interval
            if (n <= 0)
                return;



            // Create an empty stack of intervals
            Stack<Interval> s = new Stack<Interval>();

            // sort the intervals in increasing order of start time
            //sort(arr, arr + n, compareInterval);
            arr = arr.OrderBy(x => x.start).ToArray();

            // push the first interval to stack
            s.Push(arr[0]);

            // Start from the next interval and merge if necessary
            for (int i = 1; i < n; i++)
            {
                // get interval from stack top
                Interval top = s.First();

                // if current interval is not overlapping with stack top,
                // push it to the stack
                if (top.end < arr[i].start)
                    s.Push(arr[i]);

                // Otherwise update the ending time of top if ending of current
                // interval is more
                else if (top.end < arr[i].end)
                {
                    top.end = arr[i].end;
                    s.Pop();
                    s.Push(top);
                }
            }

            // Print contents of stack
            Console.Write("\n The Merged Intervals are: ");
            while (s.Any())
            {
                Interval t = s.First();
                Console.Write("[" + t.start + "," + t.end + "] ");
                s.Pop();
            }
            return;
        }

        static void mergeIntervalsFaster(Interval[] arr, int n)
        {
            // Sort Intervals in decreasing order of
            // start time
            arr = arr.OrderBy(x => x.start).ToArray();

            int index = 0; // Stores index of last element
                           // in output array (modified arr[])

            // Traverse all input Intervals
            for (int i = 0; i < n; i++)
            {
                // If this is not first Interval and overlaps
                // with the previous one
                if (index != 0 && arr[index - 1].start <= arr[i].end)
                {
                    while (index != 0 && arr[index - 1].start <= arr[i].end)
                    {
                        // Merge previous and current Intervals
                        arr[index - 1].end = Math.Max(arr[index - 1].end, arr[i].end);
                        arr[index - 1].start = Math.Min(arr[index - 1].start, arr[i].start);
                        index--;
                    }
                }
                else // Doesn't overlap with previous, add to
                     // solution
                    arr[index] = arr[i];

                index++;
            }

            // Now arr[0..index-1] stores the merged Intervals
            Console.WriteLine("\n The Merged Intervals are: ");
            for (int i = 0; i < index; i++)
                Console.WriteLine("[" + arr[i].start + ", " + arr[i].end + "] ");
        }


        // Compares two intervals according to their staring time.
        // This is needed for sorting the intervals using library
        // function std::sort(). See http://goo.gl/iGspV
        //static bool compareInterval(Interval i1, Interval i2)
        //{
        //    return (i1.start < i2.start);
        //}
    }

    // An interval has start time and end time
    class Interval
    {
        public int start, end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    };
}

//http://www.geeksforgeeks.org/merging-intervals/

//https://miafish.wordpress.com/2015/01/24/leetcode-oj-c-merge-intervals/

//Average Difficulty : 3.3/5.0
//Based on 74 vote(s)