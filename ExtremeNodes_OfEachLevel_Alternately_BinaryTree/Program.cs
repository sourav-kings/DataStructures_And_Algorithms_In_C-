using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtremeNodes_OfEachLevel_Alternately_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Binary Tree of Height 4
            Node root = new Node(1);

            root.left = new Node(2);
            root.right = new Node(3);

            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.right = new Node(7);

            root.left.left.left = new Node(8);
            root.left.left.right = new Node(9);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(11);
            root.right.right.left = new Node(14);
            root.right.right.right = new Node(15);

            root.left.left.left.left = new Node(16);
            root.left.left.left.right = new Node(17);
            root.right.right.right.right = new Node(31);

            printExtremeNodes_Recursive(root);
        }

        /* Function to print nodes of extreme corners
        of each level in alternate order */
        static void printExtremeNodes(Node root)
        {
            if (root == null)
                return;

            // Create a queue and enqueue left and right
            // children of root
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            // flag to indicate whether leftmost node or
            // the rightmost node has to be printed
            bool flag = false;
            while (q.Any())
            {
                // nodeCount indicates number of nodes
                // at current level.
                int nodeCount = q.Count();
                int n = nodeCount;

                // Dequeue all nodes of current level
                // and Enqueue all nodes of next level
                while (n != -1)//for (int i = n; i>0; i--) //
                {
                    Node curr = q.First();

                    // Enqueue left child
                    if (curr.left != null)
                        q.Enqueue(curr.left);

                    // Enqueue right child
                    if (curr.right != null)
                        q.Enqueue(curr.right);

                    // Dequeue node
                    q.Dequeue();

                    // if flag is true, print leftmost node
                    if (flag && n == nodeCount - 1)
                        Console.Write(curr.data + " ");

                    // if flag is false, print rightmost node
                    if (!flag && n == 0)
                        Console.Write(curr.data + " ");

                    n--;
                }
                // invert flag for next level
                flag = !flag;
            }
        }

        static void printExtremeNodes_Recursive(Node root)
        {
            if (root == null)
            {
                return;
            }

            Console.Write(root.data + " ");
            printExtremeNodes(root.left, root.right, 2);
        }
        static void printExtremeNodes(Node left, Node right, int level)
        {
            if (left == null && right == null)
            {
                return;
            }

            if (level % 2 == 0)
            {
                if (left != null)
                {
                    Console.Write(left.data + " ");
                }
            }
            else if (right != null)
            {
                Console.Write(right.data + " ");
            }
            printExtremeNodes(left.left, right.right, level + 1);
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


//http://www.geeksforgeeks.org/print-extreme-nodes-of-each-level-of-binary-tree-in-alternate-order/