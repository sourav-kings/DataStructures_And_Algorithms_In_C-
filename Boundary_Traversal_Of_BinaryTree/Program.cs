using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boundary_Traversal_Of_BinaryTree
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(20);
            root.left = new Node(8);
            root.left.left = new Node(4);
            root.left.right = new Node(12);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(14);
            root.right = new Node(22);
            root.right.right = new Node(25);
            printBoundary(root);
        }

        // A simple function to print leaf nodes of a binary tree
        static void printLeaves(Node node)
        {
            if (node != null)
            {
                printLeaves(node.left);

                // Print it if it is a leaf node
                if (node.left == null && node.right == null)
                    Console.Write(node.data + " ");
                printLeaves(node.right);
            }
        }

        // A function to print all left boundry nodes, except a leaf node.
        // Print the nodes in TOP DOWN manner
        static void printBoundaryLeft(Node node)
        {
            if (node != null)
            {
                if (node.left != null)
                {

                    // to ensure top down order, print the node
                    // before calling itself for left subtree
                    Console.Write(node.data + " ");
                    printBoundaryLeft(node.left);
                }
                else if (node.right != null)
                {
                    Console.Write(node.data + " ");
                    printBoundaryLeft(node.right);
                }

                // do nothing if it is a leaf node, this way we avoid
                // duplicates in output
            }
        }

        // A function to print all right boundry nodes, except a leaf node
        // Print the nodes in BOTTOM UP manner
        static void printBoundaryRight(Node node)
        {
            if (node != null)
            {
                if (node.right != null)
                {
                    // to ensure bottom up order, first call for right
                    //  subtree, then print this node
                    printBoundaryRight(node.right);
                    Console.Write(node.data + " ");
                }
                else if (node.left != null)
                {
                    printBoundaryRight(node.left);
                    Console.Write(node.data + " ");
                }
                // do nothing if it is a leaf node, this way we avoid
                // duplicates in output
            }
        }

        // A function to do boundary traversal of a given binary tree
        static void printBoundary(Node node)
        {
            if (node != null)
            {
                Console.Write(node.data + " ");

                // Print the left boundary in top-down manner.
                printBoundaryLeft(node.left);

                // Print all leaf nodes
                printLeaves(node.left);
                printLeaves(node.right);

                // Print the right boundary in bottom-up manner
                printBoundaryRight(node.right);
            }
        }
    }

    /* A binary tree node has data, pointer to left child
   and a pointer to right child */
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
//http://www.geeksforgeeks.org/boundary-traversal-of-binary-tree/