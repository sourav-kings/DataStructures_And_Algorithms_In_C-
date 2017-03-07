using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes_Without_Sibling_BinaryTree
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.right = new Node(4);
            root.right.left = new Node(5);
            root.right.left.right = new Node(6);
            printSingles(root);
        }

        // Function to print all non-root nodes that don't have a sibling
        static void printSingles(Node node)
        {
            // Base case
            if (node == null)
                return;

            // If this is an internal node, recur for left
            // and right subtrees
            if (node.left != null && node.right != null)
            {
                printSingles(node.left);
                printSingles(node.right);
            }

            // If left child is NULL and right is not, print right child
            // and recur for right child
            else {
                if (node.right != null)
                {
                    Console.Write(node.right.data + " ");
                    printSingles(node.right);
                }

                // If right child is NULL and left is not, print left child
                // and recur for left child
                else if (node.left != null)
                {
                    Console.Write(node.left.data + " ");
                    printSingles(node.left);
                }
            }

        }

    }

    // A binary tree node
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
//http://www.geeksforgeeks.org/print-nodes-dont-sibling-binary-tree/
//Average Difficulty : 2.2/5.0
//Based on 35 vote(s)

    /*
     * ALGO::
     * 
     * 0.
     * 1. Call function with node
     * 2. Check node base case
     * 3. If both right and left are not null, recur first for left node and then recur for right node.
     * 4. Else If only right is not null, print right data and recur for right.
     * 5. Else If only left is not null, print left data and recur for left.
     */