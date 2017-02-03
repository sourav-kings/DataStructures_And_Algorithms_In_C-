using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_All_Half_Nodes_BinaryTree
{
    class Program
    {
        static Node root;

        static void Main(string[] args)
        {
            Node NewRoot = null;
            root = new Node(2);
            root.left = new Node(7);
            root.right = new Node(5);
            root.left.right = new Node(6);
            root.left.right.left = new Node(1);
            root.left.right.right = new Node(11);
            root.right.right = new Node(9);
            root.right.right.left = new Node(4);

            Console.WriteLine("the inorder traversal of tree is ");
            printInorder(root);

            NewRoot = RemoveHalfNodes(root);

            Console.WriteLine("\nInorder traversal of the modified tree \n");
            printInorder(NewRoot);
        }

        static void printInorder(Node node)
        {
            if (node != null)
            {
                printInorder(node.left);
                Console.Write(node.data + " ");
                printInorder(node.right);
            }
        }

        // Removes all nodes with only one child and returns
        // new root (note that root may change)
        static Node RemoveHalfNodes(Node node)
        {
            if (node == null)
                return null;

            node.left = RemoveHalfNodes(node.left);
            node.right = RemoveHalfNodes(node.right);

            if (node.left == null && node.right == null)
                return node;

            /* if current nodes is a half node with left
             child NULL left, then it's right child is
             returned and replaces it in the given tree */
            if (node.left == null)
            {
                Node new_root = node.right;
                return new_root;
            }

            /* if current nodes is a half node with right
               child NULL right, then it's right child is
               returned and replaces it in the given tree  */
            if (node.right == null)
            {
                Node new_root = node.left;
                return new_root;
            }

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
//http://www.geeksforgeeks.org/given-a-binary-tree-how-do-you-remove-all-the-half-nodes/