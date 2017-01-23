using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_To_Mirror_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);

            /* print inorder traversal of the input tree */
            Console.WriteLine("Inorder traversal of input tree is :");
            inOrder();
            Console.WriteLine("");

            /* convert tree to its mirror */
            mirror();

            /* print inorder traversal of the minor tree */
            Console.WriteLine("Inorder traversal of binary tree is : ");
            inOrder();
        }

        static Node root;

        static void mirror()
        {
            root = mirror(root);
        }

        static Node mirror(Node node)
        {
            if (node == null)
                return node;

            /* do the subtrees */
            Node left = mirror(node.left);
            Node right = mirror(node.right);

            /* swap the left and right pointers */
            node.left = right;
            node.right = left;

            return node;
        }

        static void inOrder()
        {
            inOrder(root);
        }

        /* Helper function to test mirror(). Given a binary
           search tree, print out its data elements in
           increasing sorted order.*/
        static void inOrder(Node node)
        {
            if (node == null)
                return;

            inOrder(node.left);
            Console.Write(node.data + " ");

            inOrder(node.right);
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


//http://www.geeksforgeeks.org/write-an-efficient-c-function-to-convert-a-tree-into-its-mirror-tree/