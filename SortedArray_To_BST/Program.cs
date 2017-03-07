using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedArray_To_BST
{
    class Program
    {
        static Node root;

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = sortedArrayToBST(arr, 0, n - 1);
            Console.WriteLine("Preorder traversal of constructed BST");
            preOrder(root);
        }

        /* A function that constructs Balanced Binary Search Tree 
        from a sorted array */
        static Node sortedArrayToBST(int[] arr, int start, int end)
        {

            /* Base Case */
            if (start > end)
            {
                return null;
            }

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            Node node = new Node(arr[mid]);

            /* Recursively construct the left subtree and make it
             left child of root */
            node.left = sortedArrayToBST(arr, start, mid - 1);

            /* Recursively construct the right subtree and make it
             right child of root */
            node.right = sortedArrayToBST(arr, mid + 1, end);

            return node;
        }

        /* A utility function to print preorder traversal of BST */
        static void preOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.data + " ");
            preOrder(node.left);
            preOrder(node.right);
        }
    }

    // A binary tree node
    class Node
    {

        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}

//http://www.geeksforgeeks.org/sorted-array-to-balanced-bst/
//Average Difficulty : 2.6/5.0
//Based on 84 vote(s)


/*
 * 0.
 * 1. Convert given sorted array to BST array.
 *    i. Call function with root, start, end.
 *   ii. Check for base case for node and start vs end.
 *  iii. get mid index
 *   iv. Recurse function with left node and from start to mide-1.
 *    v. Recurse function with right node and from mid + 1 to end.
 * 2. Pre-Order traverse the new array and print data.
 * 

 */
