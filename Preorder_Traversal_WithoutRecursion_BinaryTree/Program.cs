using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preorder_Traversal_WithoutRecursion_BinaryTree
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(10);
            root.left = new Node(8);
            root.right = new Node(2);
            root.left.left = new Node(3);
            root.left.right = new Node(5);
            root.right.left = new Node(2);
            iterativePreorder();
        }

        static void iterativePreorder()
        {
            iterativePreorder(root);
        }

        // An iterative process to print preorder traversal of Binary tree
        static void iterativePreorder(Node node)
        {

            // Base Case
            if (node == null)
            {
                return;
            }

            // Create an empty stack and push root to it
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(root);

            /* Pop all items one by one. Do following for every popped item
             a) print it
             b) push its right child
             c) push its left child
             Note that right child is pushed first so that left is processed first */
            while (nodeStack.Any())
            {

                // Pop the top item from stack and print it
                Node mynode = nodeStack.Peek();
                Console.Write(mynode.data + " ");
                nodeStack.Pop();

                // Push right and left children of the popped node to stack
                if (mynode.right != null)
                {
                    nodeStack.Push(mynode.right);
                }
                if (mynode.left != null)
                {
                    nodeStack.Push(mynode.left);
                }
            }
        }
    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }
}

//http://www.geeksforgeeks.org/iterative-preorder-traversal/