using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_BST_Keys_InGivenRange
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            int k1 = 10, k2 = 25;
            root = new Node(20);
            root.left = new Node(8);
            root.right = new Node(22);
            root.left.left = new Node(4);
            root.left.right = new Node(12);

            Print(root, k1, k2);
        }

        /* The functions prints all the keys which in the given range [k1..k2].
        The function assumes than k1 < k2 */
        static void Print(Node node, int k1, int k2)
        {

            /* base case */
            if (node == null)
                return;

            /* Since the desired o/p is sorted, recurse for left subtree first
             If root->data is greater than k1, then only we can get o/p keys
             in left subtree */
            if (k1 < node.data)
                Print(node.left, k1, k2);

            /* if root's data lies in range, then prints root's data */
            if (k1 <= node.data && k2 >= node.data)
                Console.Write(node.data + " ");

            /* If root->data is smaller than k2, then only we can get o/p keys
             in right subtree */
            if (k2 > node.data)
                Print(node.right, k1, k2);
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

//http://www.geeksforgeeks.org/print-bst-keys-in-the-given-range/
//Average Difficulty : 2.4/5.0
//Based on 66 vote(s)

/*
 * ALGO::
 * 
 * 0.
 * 1. Cal function with node, start, end
 * 2. If node data is greater than start, recurse with left-node, start, end.
 * 3. If node data is greater/equal than start and smaller/equal than end, then print the node.
 * 4. If node is smaller than end, recurse with right-node, start, end.


 */
