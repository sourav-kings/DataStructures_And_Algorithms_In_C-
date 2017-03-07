using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllNode_Which_DontLieIn_AnyPathWithSumGreaterThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 45;
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            root.left.left.left = new Node(8);
            root.left.left.right = new Node(9);
            root.left.right.left = new Node(12);
            root.right.right.left = new Node(10);
            root.right.right.left.right = new Node(11);
            root.left.left.right.left = new Node(13);
            root.left.left.right.right = new Node(14);
            root.left.left.right.right.left = new Node(15);


            Console.WriteLine("Tree before truncation\n");
            print(root);

            Node root2 = root;
            root = prune(root, k); // k is 45


            Console.WriteLine("\n\nTree after truncation\n");
            print(root);

        }

        /* Main function which truncates the binary tree. */
        static Node pruneUtil(Node node, int k, Sum s)
        {
            // Base Case
            if (node == null) return null;

            // Initialize left and right sums as sum from root to
            // this node (including this node)
            Sum lsum = new Sum(s.sum + (node.data));
            Sum rsum = new Sum(s.sum + (node.data));

            //System.out.println("Current Up Sum "+s.sum);
            //System.out.println("left and right sum passed  "+lsum.sum);
            // Recursively prune left and right subtrees
            node.left = pruneUtil(node.left, k, lsum);
            node.right = pruneUtil(node.right, k, rsum);

            // Get the maximum of left and right sums
            s.sum = Math.Max(lsum.sum, rsum.sum);
            //System.out.println("Current total Sum "+s.sum);
            // If maximum is smaller than k, then this node
            // must be deleted
            if (s.sum < k)
            {
                //free(root);
                node = null;
            }

            return node;
        }

        // A wrapper over pruneUtil()
        static Node prune(Node root, int k)
        {
            //int sum = 0;
            Sum sum = new Sum(0);
            return pruneUtil(root, k, sum);
        }

        // print the tree in LVR (Inorder traversal) way.
        static void print(Node root)
        {
            if (root != null)
            {
                print(root.left);
                Console.Write(root.data + " ");
                print(root.right);
            }
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

    // A utility function to create a new Binary Tree node with given data
    class Sum
    {
        public int sum = 0;
        public Sum(int s)
        {
            this.sum = s;
        }
    }
}

//http://code.geeksforgeeks.org/n7gNzM
//http://www.geeksforgeeks.org/remove-all-nodes-which-lie-on-a-path-having-sum-less-than-k/
//Average Difficulty : 3.4/5.0
//Based on 46 vote(s)