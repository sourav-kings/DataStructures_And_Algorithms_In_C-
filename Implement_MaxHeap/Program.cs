using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_MaxHeap
{
    class Program
    {
        static int[] Heap;
        static int size;
        static int maxsize;

        const int FRONT = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("The Max Heap is ");
            MaxHeap(15);
            insert(5);
            insert(3);
            insert(17);
            insert(10);
            insert(84);
            insert(19);
            insert(6);
            insert(22);
            insert(9);
            maxHeap();

            print();
            Console.WriteLine("The max val is " + remove());
        }

        static void MaxHeap(int size)
        {
            maxsize = size;
            size = 0;
            Heap = new int[maxsize + 1];
            Heap[0] = int.MaxValue;
        }

        static int parent(int pos)
        {
            return pos / 2;
        }

        static int leftChild(int pos)
        {
            return (2 * pos);
        }

        static int rightChild(int pos)
        {
            return (2 * pos) + 1;
        }

        static bool isLeaf(int pos)
        {
            if (pos >= (size / 2) && pos <= size)
            {
                return true;
            }
            return false;
        }

        static void swap(int fpos, int spos)
        {
            int tmp;
            tmp = Heap[fpos];
            Heap[fpos] = Heap[spos];
            Heap[spos] = tmp;
        }

        static void maxHeapify(int pos)
        {
            if (!isLeaf(pos))
            {
                if (Heap[pos] < Heap[leftChild(pos)] || Heap[pos] < Heap[rightChild(pos)])
                {
                    if (Heap[leftChild(pos)] > Heap[rightChild(pos)])
                    {
                        swap(pos, leftChild(pos));
                        maxHeapify(leftChild(pos));
                    }
                    else
                    {
                        swap(pos, rightChild(pos));
                        maxHeapify(rightChild(pos));
                    }
                }
            }
        }

        static void insert(int element)
        {
            Heap[++size] = element;
            int current = size;

            while (Heap[current] > Heap[parent(current)])
            {
                swap(current, parent(current));
                current = parent(current);
            }
        }

        static void print()
        {
            for (int i = 1; i <= size / 2; i++)
            {
                Console.WriteLine(" PARENT : " + Heap[i] + " LEFT CHILD : " + Heap[2 * i]
                      + " RIGHT CHILD :" + Heap[2 * i + 1]);
                Console.WriteLine();
            }
        }

        static void maxHeap()
        {
            for (int pos = (size / 2); pos >= 1; pos--)
            {
                maxHeapify(pos);
            }
        }

        static int remove()
        {
            int popped = Heap[FRONT];
            Heap[FRONT] = Heap[size--];
            maxHeapify(FRONT);
            return popped;
        }
    }
}


//http://www.sanfoundry.com/java-program-implement-max-heap/

//http://quiz.geeksforgeeks.org/binary-heap/