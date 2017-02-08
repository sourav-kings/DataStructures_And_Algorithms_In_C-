﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_BST_From_PreorderTraversal
{
    class Program
    {
        static Index index = new Index();
        static void Main(string[] args)
        {
            int[] pre = new int[] { 10, 5, 1, 7, 40, 50 };
            int size = pre.Length;
            Node root = constructTreeFaster(pre, size);
            Console.WriteLine("Inorder traversal of the constructed tree is ");
            printInorder(root);
        }

        // A recursive function to construct Full from pre[]. preIndex is used
        // to keep track of index in pre[].
        static Node constructTreeUtil(int[] pre, Index preIndex,
                int low, int high, int size)
        {

            // Base case
            if (preIndex.index >= size || low > high)
            {
                return null;
            }

            // The first node in preorder traversal is root. So take the node at
            // preIndex from pre[] and make it root, and increment preIndex
            Node root = new Node(pre[preIndex.index]);
            preIndex.index = preIndex.index + 1;

            // If the current subarry has only one element, no need to recur
            if (low == high)
            {
                return root;
            }

            // Search for the first element greater than root
            int i;
            for (i = low; i <= high; ++i)
            {
                if (pre[i] > root.data)
                {
                    break;
                }
            }

            // Use the index of element found in preorder to divide preorder array in
            // two parts. Left subtree and right subtree
            root.left = constructTreeUtil(pre, preIndex, preIndex.index, i - 1, size);
            root.right = constructTreeUtil(pre, preIndex, i, high, size);

            return root;
        }

        // The main function to construct BST from given preorder traversal.
        // This function mainly uses constructTreeUtil()
        static Node constructTree(int[] pre, int size)
        {
            return constructTreeUtil(pre, index, 0, size - 1, size);
        }

        // A utility function to print inorder traversal of a Binary Tree
        static void printInorder(Node node)
        {
            if (node == null)
            {
                return;
            }
            printInorder(node.left);
            Console.Write(node.data + " ");
            printInorder(node.right);
        }


        // A recursive function to construct BST from pre[]. preIndex is used
        // to keep track of index in pre[].
        static Node constructTreeUtilFaster(int[] pre, Index preIndex, int key,
                int min, int max, int size)
        {

            // Base case
            if (preIndex.index >= size)
            {
                return null;
            }

            Node root = null;

            // If current element of pre[] is in range, then
            // only it is part of current subtree
            if (key > min && key < max)
            {

                // Allocate memory for root of this subtree and increment *preIndex
                root = new Node(key);
                preIndex.index = preIndex.index + 1;

                if (preIndex.index < size)
                {

                    // Contruct the subtree under root
                    // All nodes which are in range {min .. key} will go in left
                    // subtree, and first such node will be root of left subtree.
                    root.left = constructTreeUtilFaster(pre, preIndex, pre[preIndex.index],
                            min, key, size);

                    // All nodes which are in range {key..max} will go in right
                    // subtree, and first such node will be root of right subtree.
                    root.right = constructTreeUtilFaster(pre, preIndex, pre[preIndex.index],
                            key, max, size);
                }
            }

            return root;
        }

        // The main function to construct BST from given preorder traversal.
        // This function mainly uses constructTreeUtil()
        static Node constructTreeFaster(int[] pre, int size)
        {
            int preIndex = 0;
            return constructTreeUtilFaster(pre, index, pre[preIndex], int.MinValue,
                    int.MaxValue, size);
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

    class Index
    {

        public int index = 0;
    }

}

//http://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/