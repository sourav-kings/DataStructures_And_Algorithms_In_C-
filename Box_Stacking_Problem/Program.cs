using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box_Stacking_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] x = new int[4,3] { {4, 7, 9},
                       {5, 8, 9},
                       {11, 20, 40},
                       {1, 2, 3} };

            //int[] x2 = { { 4, 6, 7 }, { 1, 2, 3 }, { 4, 5, 6 }, { 10, 12, 32 } };

            Console.WriteLine("Max height which can be obtained :" + solve2(x));
        }

        static int solve(int[,] x)
        {

            Box[] boxes = new Box[x.Length];
            for (int i = 0; i < 4; i++)
            {
                int h = x[i, 0];
                int w = x[i, 1];
                int d = x[i, 2];
                boxes[i * 3] = new Box(h, w, d); //normal dimension
                boxes[i * 3 + 1] = new Box(w, h, d); //first dimension
                boxes[i * 3 + 2] = new Box(d, h, w); //second dimension
            }

            //all options are created.
            Array.Sort(boxes);
            //to display all the possible boxes.
            Console.WriteLine("All possible combination of boxes after rotation");
            for (int i = 0; i < boxes.Length; i++)
            {
                Console.WriteLine(boxes[i].height + " " + boxes[i].width + " " + boxes[i].depth);
            }

            int[] optHeight = new int[boxes.Length + 1];

            //if there are no boxes then optimal height = 0
            optHeight[0] = 0;

            for (int i = 1; i < optHeight.Length; i++)
            {
                int maxHeightIndex = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    //first check if box can be placed
                    if (boxes[j].width > boxes[i - 1].width && boxes[j].depth > boxes[i - 1].depth)
                    {
                        if (optHeight[maxHeightIndex] < optHeight[j + 1])
                        {
                            maxHeightIndex = j + 1;
                        }
                    }
                }
                optHeight[i] = optHeight[maxHeightIndex] + boxes[i - 1].height;
            }

            //        System.out.println(Arrays.toString(optHeight));
            return optHeight[optHeight.Length - 1];
        }

        static int solve2(int[,] x)
        {

            Box[] boxes = new Box[x.Length];
            for (int i = 0; i < 4; i++)
            {
                int h = x[i, 0];
                int w = x[i, 1];
                int d = x[i, 2];
                boxes[i * 3] = new Box(h, w, d); //normal dimension
                boxes[i * 3 + 1] = new Box(w, h, d); //first dimension
                boxes[i * 3 + 2] = new Box(d, h, w); //second dimension
            }

            //all options are created.
            Array.Sort(boxes);
            //to display all the possible boxes.
            Console.WriteLine("All possible combination of boxes after rotation");
            for (int i = 0; i < boxes.Length; i++)
            {
                Console.WriteLine(boxes[i].height + " " + boxes[i].width + " " + boxes[i].depth);
            }

            
            int[] T = new int[boxes.Length];
            for (int i = 0; i < T.Length; i++)
                T[i] = boxes[i].height;


            for (int i = 1; i < T.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (boxes[i].depth < boxes[j].depth && 
                        boxes[i].width < boxes[j].width)
                    {
                        if (T[j] + boxes[i].height > T[i])
                        {
                            T[i] = T[j] + boxes[i].height;
                        }
                    }
                }
            }

            //find max in T[] and that will be our max height.
            //Result can also be found using result[] array.
            int max = int.MinValue;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] > max)
                {
                    max = T[i];
                }
            }

            return max;
        }

    }

    /* Representation of a box */


    class Box : IComparable<Box>
    {

        public int height;
        public int width;
        public int depth;
        public Box(int height, int width, int depth)
        {
            this.height = height;
            this.width = width;
            this.depth = depth;
        }

        public int CompareTo(Box o)
        {
            int area = o.depth * o.width;
            int thisArea = this.depth * this.width;

            return area - thisArea;
        }
    }
}

//http://algorithms.tutorialhorizon.com/dynamic-programming-box-stacking-problem/

//http://www.geeksforgeeks.org/dynamic-programming-set-21-box-stacking-problem/
//Average Difficulty : 3.7/5.0
//Based on 62 vote(s)

//https://www.youtube.com/watch?v=9mod_xRB-O0
//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/BoxStacking.java

//http://www.geeksforgeeks.org/dynamic-programming-set-3-longest-increasing-subsequence/