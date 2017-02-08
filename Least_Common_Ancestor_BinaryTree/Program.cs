using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Least_Common_Ancestor_BST
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
                // Let us construct the BST shown in the above figure
        root        = new Node(20);
        root.left               = new Node(8);
        root.right              = new Node(22);
        root.left.left         = new Node(4);
        root.left.right        = new Node(12);
        root.left.right.left  = new Node(10);
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