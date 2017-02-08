using System;
using System.Collections.Generic;

namespace Largest_RectangularArea_In_Histogram
{
    public class Program
    {
        public static void Main()
        {
            int[] hist = { 6, 2, 5, 4, 5, 1, 6 };
            int n = hist.Length;
            Console.WriteLine("Maximum area is " + GetMaxArea(hist, n));
        }

        static int GetMaxArea(int[] hist, int n)
        {
            // Create an empty stack. The stack holds indexes of hist[] array
            // The bars stored in stack are always in increasing order of their
            // heights.
            Stack<int> s = new Stack<int>();

            int max_area = 0; // Initalize max area
            int tp;  // To store top of stack
            int area_with_top; // To store area with top bar as the smallest bar

            // Run through all bars of given histogram
            int i = 0;
            while (i < n)
            {
                // If this bar is higher than the bar on top stack, push it to stack
                if (s.Count == 0 || hist[s.Peek()] <= hist[i])
                    s.Push(i++);

                // If this bar is lower than top of stack, then calculate area of rectangle 
                // with stack top as the smallest (or minimum height) bar. 'i' is 
                // 'right index' for the top and element before top in stack is 'left index'
                else
                {
                    tp = s.Peek();  // store the top index
                    s.Pop();  // pop the top

                    // Calculate the area with hist[tp] stack as smallest bar
                    area_with_top = hist[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);

                    // update max area, if needed
                    if (max_area < area_with_top)
                        max_area = area_with_top;
                }
            }

            // Now pop the remaining bars from stack and calculate area with every
            // popped bar as the smallest bar
            while (s.Count != 0)
            {
                tp = s.Peek();
                s.Pop();
                area_with_top = hist[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);

                if (max_area < area_with_top)
                    max_area = area_with_top;
            }

            return max_area;
        }
    }
}
//http://www.geeksforgeeks.org/largest-rectangle-under-histogram/