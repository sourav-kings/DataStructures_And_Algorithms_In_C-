using System;
using System.Collections.Generic;

namespace LevelOrder_Traversal_In_SpiralForm
{

    public class Program
    {
        static Node root;

        public static void Main()
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(7);
            root.left.right = new Node(6);
            root.right.left = new Node(5);
            root.right.right = new Node(4);
            Console.WriteLine("Spiral order traversal of Binary Tree is ");

            PrintSpiral(root);

            Console.WriteLine("\n");

            PrintSpiralFaster(root);
        }

        static void PrintSpiral(Node node)
        {
            int h = Height(node);
            int i;

            /* ltr -> left to right. If this variable is set then the
               given label is transversed from left to right */
            bool ltr = false;
            for (i = 1; i <= h; i++)
            {
                PrintGivenLevel(node, i, ltr);

                /*Revert ltr to traverse next level in opposite order*/
                ltr = !ltr;
            }
        }

        static int Height(Node node)
        {
            if (node == null)
                return 0;
            else
            {

                /* compute the height of each subtree */
                int lheight = Height(node.left);
                int rheight = Height(node.right);

                /* use the larger one */
                if (lheight > rheight)
                    return (lheight + 1);
                else
                    return (rheight + 1);
            }
        }

        static void PrintGivenLevel(Node node, int level, bool ltr)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.Write(node.data + " ");
            else if (level > 1)
            {
                if (ltr)
                {
                    PrintGivenLevel(node.left, level - 1, ltr);
                    PrintGivenLevel(node.right, level - 1, ltr);
                }
                else
                {
                    PrintGivenLevel(node.right, level - 1, ltr);
                    PrintGivenLevel(node.left, level - 1, ltr);
                }
            }
        }

        static void PrintSpiralFaster(Node node)
        {
            if (node == null)
                return;   // NULL check

            // Create two stacks to store alternate levels
            Stack<Node> s1 = new Stack<Node>();// For levels to be printed from right to left
            Stack<Node> s2 = new Stack<Node>();// For levels to be printed from left to right

            // Push first level to first stack 's1'
            s1.Push(node);

            // Keep ptinting while any of the stacks has some nodes
            while (s1.Count != 0 || s2.Count != 0)
            {
                // Print nodes of current level from s1 and push nodes of
                // next level to s2
                while (s1.Count != 0)
                {
                    Node temp = s1.Peek();
                    s1.Pop();
                    Console.Write(temp.data + " ");

                    // Note that is right is pushed before left
                    if (temp.right != null)
                        s2.Push(temp.right);

                    if (temp.left != null)
                        s2.Push(temp.left);

                }

                // Print nodes of current level from s2 and push nodes of
                // next level to s1
                while (s2.Count != 0)
                {
                    Node temp = s2.Peek();
                    s2.Pop();
                    Console.Write(temp.data + " ");

                    // Note that is left is pushed before right
                    if (temp.left != null)
                        s1.Push(temp.left);
                    if (temp.right != null)
                        s1.Push(temp.right);
                }
            }
        }
    }

    class Node
    {
        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }

}



//http://www.geeksforgeeks.org/level-order-traversal-in-spiral-form/

//Average Difficulty : 2.7/5.0
//Based on 115 vote(s)