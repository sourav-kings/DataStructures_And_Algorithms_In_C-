using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAllSortedElements_From_RowColumn_Sorted_Matrix
{
    class Program
    {
        const int INF = int.MaxValue;
        const int N = 4;
        static void Main(string[] args)
        {
            int[,] mat = new int[N,N] { {10, 20, 30, 40},
                    {15, 25, 35, 45},
                    {27, 29, 37, 48},
                    {32, 33, 39, 50},
                  };
            printSorted(mat);



            int[][] mat2 = new int[N][] { new int[4]{10, 20, 30, 40},
                    new int[4]{15, 25, 35, 45},
                    new int[4]{27, 29, 37, 48},
                    new int[4]{32, 33, 39, 50},
                    };

            Console.WriteLine("Matrix:");
            printMatrix(mat2);

            Console.WriteLine();
            printAllElementsInSortedOrderFromRowAndColumnWiseSortedMatrix(mat2);
            Console.WriteLine();
        }

        // A utility function to youngify a Young Tableau.  This is different
        // from standard youngify.  It assumes that the value at mat[0,0] is 
        // infinite.
        static void youngify(int[,] mat, int i, int j)
        {
            // Find the values at down and right sides of mat[i,j]
            int downVal = (i + 1 < N) ? mat[i + 1,j] : INF;
            int rightVal = (j + 1 < N) ? mat[i,j + 1] : INF;

            // If mat[i,j] is the down right corner element, return
            if (downVal == INF && rightVal == INF)
                return;

            // Move the smaller of two values (downVal and rightVal) to 
            // mat[i,j] and recur for smaller value
            if (downVal < rightVal)
            {
                mat[i,j] = downVal;
                mat[i + 1,j] = INF;
                youngify(mat, i + 1, j);
            }
            else
            {
                mat[i,j] = rightVal;
                mat[i,j + 1] = INF;
                youngify(mat, i, j + 1);
            }
        }

        // A utility function to extract minimum element from Young tableau
        static int extractMin(int[,] mat)
        {
            int ret = mat[0,0];
            mat[0,0] = INF;
            youngify(mat, 0, 0);
            return ret;
        }

        // This function uses extractMin() to print elements in sorted order
        static void printSorted(int[,] mat)
        {
            Console.WriteLine("Elements of matrix in sorted order \n");
            for (int i = 0; i < N * N; i++)
                Console.Write(extractMin(mat)+ " ");
        }










        static void printAllElementsInSortedOrderFromRowAndColumnWiseSortedMatrix(int[][] arr)
        {
            int k = arr.Length;
            Node[] hArr = new Node[k];
            int resultSize = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                Node node = new Node(arr[i][0], i, 1);
                hArr[i] = node;
                resultSize += arr[i].Length;
            }

            MinHeap mh = new MinHeap(hArr);

            for (int c = 0; c < resultSize; c++)
            {
                Node root = mh.getMin();

                Console.Write(root.element + " ");

                if (root.j < arr[root.i].Length)
                {
                    root.element = arr[root.i][root.j];
                    root.j++;
                }
                else
                    root.element = int.MaxValue;

                mh.replaceMin(root);
            }
        }

        static void printMatrix(int[][] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    Console.Write(arr[i][j] + " ");
                Console.WriteLine();
            }
        }
    }

    class Node
    {
        public int element;
        public int i;
        public int j;

        public Node(int element, int i, int j)
        {
            this.element = element;
            this.i = i;
            this.j = j;
        }
    }

    class MinHeap
    {
        public int capacity;
        public Node[] arr;
        public int size;

        public MinHeap(Node[] arr)
        {
            this.capacity = arr.Length;
            this.size = this.capacity;
            this.arr = arr;
            buildMinHeap();
        }

        public void swap(Node[] arr, int i, int j)
        {
            Node temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public int parent(int i)
        {
            return (i - 1) / 2;
        }

        public int left(int i)
        {
            return 2 * i + 1;
        }

        public int right(int i)
        {
            return 2 * i + 2;
        }

        public Node getMin()
        {
            if (size <= 0)
            {
                Console.WriteLine("Heap underflow");
                return null;
            }
            return arr[0];
        }

        public Node extractMin()
        {
            if (size <= 0)
            {
                Console.WriteLine("Heap underflow");
                return null;
            }
            if (size == 1)
            {
                size--;
                return arr[0];
            }

            Node root = arr[0];
            arr[0] = arr[size - 1];
            size--;
            minHeapify(0);

            return root;
        }

        public void minHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;

            if (l < size && arr[l].element < arr[smallest].element)
                smallest = l;
            if (r < size && arr[r].element < arr[smallest].element)
                smallest = r;
            if (smallest != i)
            {
                swap(arr, i, smallest);
                minHeapify(smallest);
            }
        }

        public void buildMinHeap()
        {
            int n = arr.Length;
            for (int i = (n / 2) - 1; i >= 0; i--)
                minHeapify(i);
        }

        public void replaceMin(Node root)
        {
            arr[0] = root;
            minHeapify(0);
        }

        public void printMinHeap()
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i].element + " ");
            Console.WriteLine();
        }
    }
}

//http://www.geeksforgeeks.org/print-elements-sorted-order-row-column-wise-sorted-matrix/
//http://ideone.com/UQ4VSb
//http://stackoverflow.com/questions/2893297/iterate-multi-dimensional-array-with-nested-foreach-statement

//Average Difficulty : 2.9/5.0
//Based on 92 vote(s)