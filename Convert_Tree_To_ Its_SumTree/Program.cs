using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_Tree_To__Its_SumTree
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            /* Constructing tree given in the above figure */
            root = new Node(10);
            root.left = new Node(-2);
            root.right = new Node(6);
            root.left.left = new Node(8);
            root.left.right = new Node(-4);
            root.right.left = new Node(7);
            root.right.right = new Node(5);

            toSumTree(root);

            // Print inorder traversal of the converted tree to test result of toSumTree()
            Console.Write("Inorder Traversal of the resultant tree is: \n");
            printInorder(root);
        }

        // Convert a given tree to a tree where every Node contains sum of values of
        // nodes in left and right subtrees in the original tree
        static int toSumTree(Node node)
        {
            // Base case
            if(node == null)
              return 0;
 
            // Store the old value
            int old_val = node.data;

            // Recursively call for left and right subtrees and store the sum as
            // new value of this Node
            node.data = toSumTree(node.left) + toSumTree(node.right);
 
            // Return the sum of values of nodes in left and right subtrees and
            // old_value of this Node
            return node.data + old_val;
        }

        // A utility function to print inorder traversal of a Binary Tree
        static void printInorder(Node Node)
        {
             if (Node == null)
                  return;
             printInorder(Node.left);
             Console.Write(Node.data + " ");
             printInorder(Node.right);
        }
    }

    /* A tree Node structure */
    class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.data = data;
            right = left = null;
        }
    };
}


//http://www.geeksforgeeks.org/convert-a-given-tree-to-sum-tree/