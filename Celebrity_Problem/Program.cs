using System;
using System.Collections.Generic;

namespace Celebrity_Problem
{
    public class Program
    {
        public static void Main()
        {
            int n = 4;
            //int id = FindCelebrity(n);
            //int id = FindCelebrity2(n);
            int id = FindCelebrity3(n);
            //int id = FindCelebrityUsingStack(n);


            if (id == -1)
                Console.WriteLine("No celebrity");
            else
                Console.WriteLine("Celebrity ID {0}", id);
        }

        static int FindCelebrity(int n)
        {
            int x = 0;
            for (int i = 1; i < n; ++i) if (Knows(x, i)) x = i;
            for (int i = 0; i < x; ++i) if (Knows(x, i)) return -1;
            for (int i = 0; i < n; ++i) if (!Knows(i, x)) return -1;
            return x;
        }


        static int FindCelebrity2(int n)
        {
            int cand = 0;  // set 0 as current candidate
            int prevOneKnowsCand = -1;
            for (int i = 1; i < n; ++i)
            { // if cand knows i, celebrity must not be this cand, set cand to i. otherwise, i must not be the celebrity, skip it.
                if (Knows(cand, i))
                {
                    prevOneKnowsCand = cand;  // at least we've already known that "cand" knows the future candidate i
                    cand = i;
                }
            }  // at this point, cand does not know anyone coming after him
            for (int i = 0; i < cand; ++i) { if (Knows(cand, i)) { return -1; } }  // at this point, cand does not know anyone else
            for (int i = 0; i < n; ++i)
            {
                if (i != cand)
                {  // these 2 ppl know candidate for sure 
                    if (!Knows(i, cand)) { return -1; }
                }
            }
            return cand;
        }

        static int FindCelebrity3(int n)
        {
            int candidate = 0;
            for (int i = 1; i < n; i++)
            {
                if (Knows(candidate, i))
                    candidate = i;
            }
            for (int i = 0; i < n; i++)
            {
                if (i != candidate && (Knows(candidate, i) || !Knows(i, candidate))) return -1;
            }
            return candidate;
        }

        static int FindCelebrityUsingStack(int n)
        {
            // Handle trivial case of size = 2

            Stack<int> s = new Stack<int>();

            int C; // Celebrity

            // Push everybody to stack
            for (int i = 0; i < n; i++)
                s.Push(i);

            // Extract top 2
            int A = s.Peek();
            s.Pop();
            int B = s.Peek();
            s.Pop();

            // Find a potential celevrity
            while (s.Count > 1)
            {
                if (Knows(A, B))
                {
                    A = s.Peek();
                    s.Pop();
                }
                else
                {
                    B = s.Peek();
                    s.Pop();
                }
            }

            // Potential candidate?
            C = s.Peek();
            s.Pop();

            // Last candidate was not examined, it leads
            // one excess comparison (optimize)
            if (Knows(C, B))
                C = B;

            if (Knows(C, A))
                C = A;

            // Check if C is actually a celebrity or not
            for (int i = 0; i < n; i++)
            {
                // If any person doesn't know 'a' or 'a'
                // doesn't know any person, return -1
                if ((i != C) &&
                        (Knows(C, i) || !Knows(i, C)))
                    return -1;
            }

            return C;
        }

        // Person with 2 is celebrity
        static int[,] Matrix = new int[,] {
        {0, 0, 1, 0},
        {0, 0, 1, 0},
        {0, 0, 0, 0},
        {0, 0, 1, 0}
    };

        static bool Knows(int a, int b)
        {
            return (Matrix[a, b] == 1);
        }
    }


}

/*
https://discuss.leetcode.com/topic/23534/java-solution-two-pass
https://discuss.leetcode.com/topic/25720/java-python-o-n-calls-o-1-space-easy-to-understand-solution
http://www.geeksforgeeks.org/the-celebrity-problem/
*/
