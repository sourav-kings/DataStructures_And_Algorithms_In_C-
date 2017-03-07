using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllNodes_AtDistance_K_From_GivenNode
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            /* Let us construct the tree shown in above diagram */
            root = new Node(20);
            root.left = new Node(8);
            root.right = new Node(22);
            root.left.left = new Node(4);
            root.left.right = new Node(12);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(14);
            Node target = root.left.right;
            printkdistanceNode(root, target, 2);
        }

        /* Recursive function to print all the nodes at distance k in tree (or subtree) rooted with given root. */

        static void printkdistanceNodeDown(Node node, int k)
        {
            // Base Case
            if (node == null || k < 0)
                return;

            // If we reach a k distant node, print it
            if (k == 0)
            {
                Console.Write(node.data);
                Console.WriteLine("");
                return;
            }

            // Recur for left and right subtrees
            printkdistanceNodeDown(node.left, k - 1);
            printkdistanceNodeDown(node.right, k - 1);
        }

        // Prints all nodes at distance k from a given target node.
        // The k distant nodes may be upward or downward.This function
        // Returns distance of root from target node, it returns -1
        // if target node is not present in tree rooted with root.
        static int printkdistanceNode(Node node, Node target, int k)
        {
            // Base Case 1: If tree is empty, return -1
            if (node == null)
                return -1;

            // If target is same as root.  Use the downward function
            // to print all nodes at distance k in subtree rooted with
            // target or root
            if (node == target)
            {
                printkdistanceNodeDown(node, k);
                return 0;
            }

            // Recur for left subtree
            int dl = printkdistanceNode(node.left, target, k);

            // Check if target node was found in left subtree
            if (dl != -1)
            {

                // If root is at distance k from target, print root
                // Note that dl is Distance of root's left child from 
                // target
                if (dl + 1 == k)
                {
                    Console.Write(node.data);
                    Console.WriteLine("");
                }

                // Else go to right subtree and print all k-dl-2 distant nodes
                // Note that the right child is 2 edges away from left child
                else
                    printkdistanceNodeDown(node.right, k - dl - 2);

                // Add 1 to the distance and return value for parent calls
                return 1 + dl;
            }

            // MIRROR OF ABOVE CODE FOR RIGHT SUBTREE
            // Note that we reach here only when node was not found in left 
            // subtree
            int dr = printkdistanceNode(node.right, target, k);
            if (dr != -1)
            {
                if (dr + 1 == k)
                {
                    Console.Write(node.data);
                    Console.WriteLine("");
                }
                else
                    printkdistanceNodeDown(node.left, k - dr - 2);
                return 1 + dr;
            }

            // If target was neither present in left nor in right subtree
            return -1;
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


//http://www.geeksforgeeks.org/print-nodes-distance-k-given-node-binary-tree/
//Average Difficulty : 4.4/5.0
//Based on 106 vote(s)