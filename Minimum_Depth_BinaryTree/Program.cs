using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Depth_BinaryTree
{
    /*
     * Given a binary tree, find its minimum depth. 
     * The minimum depth is the number of nodes along the shortest path from root node down to the nearest leaf node.
     */
    class Program
    {
        //Root of the Binary Tree
        static Node root;

        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);

            Console.WriteLine("The minimum depth of " +
              "binary tree is : " + minimumDepth(root));
        }

        //static int minimumDepth()
        //{
        //    return minimumDepth(root);
        //}

        /* Function to calculate the minimum depth of the tree */
        static int minimumDepth(Node root)
        {
            // Corner case. Should never be hit unless the code is
            // called on root = NULL
            if (root == null)
                return 0;

            // Base case : Leaf Node. This accounts for height = 1.
            if (root.left == null && root.right == null)
                return 1;

            // If left subtree is NULL, recur for right subtree
            if (root.left == null)
                return minimumDepth(root.right) + 1;

            // If right subtree is NULL, recur for right subtree
            if (root.right == null)
                return minimumDepth(root.left) + 1;

            return Math.Min(minimumDepth(root.left),
                            minimumDepth(root.right)) + 1;
        }

    }

    /* Class containing left and right child of current
    node and key value*/
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


//http://www.geeksforgeeks.org/find-minimum-depth-of-a-binary-tree/

//Average Difficulty : 2.1/5.0
//Based on 60 vote(s)

    /*
     * ALGO::
     * 
     * 0.
     * 1. Call int function with node
     * 2. Check node base case and if true return 0.
     * 3. If both right and left child nodes are null, return 1.
     * 4. If only left child  node is null, return 1 + recur with child node. 
     * 5. If only right child node is null, return 1 + recur with left child node.
     * 6. Finally, return 1 + MIN of recur of left child node and recur of right child node. 
     */