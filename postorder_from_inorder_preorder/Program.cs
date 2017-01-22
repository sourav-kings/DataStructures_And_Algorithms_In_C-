using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postorder_from_inorder_preorder
{
    class Program
    {
        static int preIndex = 0;

        static void Main(string[] args)
        {
            int[] inOrder = {4, 2, 5, 1, 3, 6};
            int[] preOrder = { 1, 2, 4, 5, 3, 6 };
            int n = inOrder.Length;
            Console.WriteLine("Postorder traversal ");
            printPostOrder(0, n-1, inOrder, preOrder);
            Console.WriteLine();
        }

        private static void printPostOrder(int inStart, int inEnd, int[] inOrder, int[] preOrder)
        {
            if (inStart > inEnd)
                return;

            if (inStart == inEnd)
            {
                Console.Write(preOrder[preIndex++] + " ");
                return;
            }

            int index = search(inStart, inEnd, inOrder, preOrder[preIndex++]);
            printPostOrder(inStart, index - 1, inOrder, preOrder);
            printPostOrder(index + 1, inEnd, inOrder, preOrder);
            Console.Write(inOrder[index] + " ");
        }

        // A utility function to search x inOrder arr[] of size n
        private static int search(int start, int end, int[] arr, int x)
        {
            for (int i = 0; i < end; i++)
                if (arr[i] == x)
                    return i;
            return -1;
        }
    }
}


//http://www.geeksforgeeks.org/print-postorder-from-given-inorder-and-preorder-traversals/
//http://code.geeksforgeeks.org/ymiC4E