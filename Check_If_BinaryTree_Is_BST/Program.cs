﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_If_BinaryTree_Is_BST
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(4);
            root.left = new Node(2);
            root.right = new Node(5);
            root.left.left = new Node(1);
            root.left.right = new Node(3);

            if (isBST())
                Console.Write("IS BST");
            else
                Console.Write("Not a BST");
        }

        /* can give min and max value according to your code or
        can write a function to find min and max value of tree. */

        /* returns true if given search tree is binary
         search tree (efficient version) */
        static bool isBST()
        {
            return isBSTUtil(root, int.MinValue,
                                   int.MaxValue);
        }

        /* Returns true if the given tree is a BST and its
          values are >= min and <= max. */
        static bool isBSTUtil(Node node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
                return true;

            /* false if this node violates the min/max constraints */
            if (node.data < min || node.data > max)
                return false;

            /* otherwise check the subtrees recursively
            tightening the min/max constraints */
            // Allow only distinct values
            return (isBSTUtil(node.left, min, node.data - 1) &&
                 isBSTUtil(node.right, node.data + 1, max));


        }

        class Node
        {
            public int data;
            public Node left, right;

            public Node(int item)
            {
                data = item;
                left = right = null;
            }
        }

    }
}