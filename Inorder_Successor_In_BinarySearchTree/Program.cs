using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inorder_Successor_In_BinarySearchTree
{
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            Node root = null, temp = null, suc = null, min = null;
            root = insert(root, 20);
            root = insert(root, 8);
            root = insert(root, 22);
            root = insert(root, 4);
            root = insert(root, 12);
            root = insert(root, 10);
            root = insert(root, 14);
            temp = root.left.right.right;
            suc = inOrderSuccessor(root, temp);
            if (suc != null)
            {
                Console.WriteLine("Inorder successor of " + temp.data +
                                                          " is " + suc.data);
            }
            else
            {
                Console.WriteLine("Inorder successor does not exist");
            }
        }

        /* Given a binary search tree and a number, 
 inserts a new node with the given number in 
 the correct place in the tree. Returns the new 
 root pointer which the caller should then use 
 (the standard trick to avoid using reference 
 parameters). */
        static Node insert(Node node, int data)
        {

            /* 1. If the tree is empty, return a new,     
             single node */
            if (node == null)
            {
                return (new Node(data));
            }
            else
            {

                Node temp = null;

                /* 2. Otherwise, recur down the tree */
                if (data <= node.data)
                {
                    temp = insert(node.left, data);
                    node.left = temp;
                    temp.parent = node;

                }
                else
                {
                    temp = insert(node.right, data);
                    node.right = temp;
                    temp.parent = node;
                }

                /* return the (unchanged) node pointer */
                return node;
            }
        }

        static Node inOrderSuccessor(Node root, Node n)
        {

            // step 1 of the above algorithm 
            if (n.right != null)
            {
                return minValue(n.right);
            }

            // step 2 of the above algorithm
            Node p = n.parent;
            while (p != null && n == p.right)
            {
                n = p;
                p = p.parent;
            }
            return p;
        }

        /* Given a non-empty binary search tree, return the minimum data  
         value found in that tree. Note that the entire tree does not need
         to be searched. */
        static Node minValue(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }
    }

    class Node
    {
        public int data;
        public Node left, right, parent;

        public Node(int d)
        {
            data = d;
            left = right = parent = null;
        }
    }
}

//http://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/