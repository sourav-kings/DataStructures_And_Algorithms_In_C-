using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Least_Common_Ancestor_BST
{
    class Program
    {
        /*
         *   Given values of two nodes in a Binary Search Tree, 
         *   Write a c program to find the Lowest Common Ancestor (LCA). 
         *   You may assume that both the values exist in the tree.
         */
        static Node root;
        static void Main(string[] args)
        {
            // Let us construct the BST shown in the above figure
            root = new Node(20);
            root.left = new Node(8);
            root.right = new Node(22);
            root.left.left = new Node(4);
            root.left.right = new Node(12);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(14);

            int n1 = 10, n2 = 14;
            Node t = lca(root, n1, n2);
            Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data + " \n");

            n1 = 14; n2 = 8;
            t = lca(root, n1, n2);
            Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data + " \n");

            n1 = 10; n2 = 22;
            t = lca(root, n1, n2);
            Console.WriteLine("LCA of " + n1 + " and " + n2 + " is " + t.data + " \n");
        }



        /* Function to find LCA of n1 and n2. The function assumes that both
   n1 and n2 are present in BST */
        static Node lca(Node node, int n1, int n2)
        {
            if (node == null)
                return null;

            // If both n1 and n2 are smaller than root, then LCA lies in left
            if (node.data > n1 && node.data > n2)
                return lca(node.left, n1, n2);

            // If both n1 and n2 are greater than root, then LCA lies in right
            if (node.data < n1 && node.data < n2)
                return lca(node.right, n1, n2);

            return node;
        }

        /* Function to find LCA of n1 and n2. The function assumes that both
            n1 and n2 are present in BST */
        Node lcaNonRecursive(Node root, int n1, int n2)
        {
            while (root != null)
            {
                // If both n1 and n2 are smaller than root, then LCA lies in left
                if (root.data > n1 && root.data > n2)
                    root = root.left;

                // If both n1 and n2 are greater than root, then LCA lies in right
                else if (root.data < n1 && root.data < n2)
                    root = root.right;

                else break;
            }
            return root;
        }
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


//http://www.geeksforgeeks.org/lowest-common-ancestor-in-a-binary-search-tree/

//Average Difficulty : 2.2/5.0
//Based on 133 vote(s)


/*Time complexity of recursive solution is O(h) where h is height of tree. 
* Also, this solution requires O(h) extra space in function call stack for recursive function calls. 
* We can avoid extra space using iterative solution*/


/*
 * LCA Recursive
 * ---------------
 * 0.
 * 1. Call function wid node and two limits 
 * 2. Check base case for node == null
 * 3. If both limits are smaller than root data, then recur with node.left and two limits  (as LCA lies on left side)
 * 4. If both limits are greater than root data, then recur with node.right and two limits (as LCA lies on right side)
 * 5. Return the root
 *     
 *      
 * LCA Iterative
 * ---------------
 * 0.
 * 1. Check for base case for node == null
 * 2. While loop until  node is not null
 * 3. If root data is greater than both limits, then set node with node.left.
 * 4. Else If root data is smaller than both limits, then set node with node.right. 
 * 5. Else, break the loop.
 * 6. Return root
 */
