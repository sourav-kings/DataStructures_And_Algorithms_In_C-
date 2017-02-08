using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Nodes_At_SameLevel
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            /* Constructed binary tree is
                  10
                 /  \
               8     2
              /
             3
             */
            root = new Node(10);
            root.left = new Node(8);
            root.right = new Node(2);
            root.left.left = new Node(3);

            // Populates nextRight pointer in all nodes
            connect(root);

            // Let us check the values of nextRight pointers
            Console.WriteLine("Following are populated nextRight pointers in "
                    + "the tree" + "(-1 is printed if there is no nextRight)");
            int a = root.nextRight != null ? root.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.data + " is "
                    + a);
            int b = root.left.nextRight != null ?
                                        root.left.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.left.data + " is "
                    + b);
            int c = root.right.nextRight != null ?
                                       root.right.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.right.data + " is "
                    + c);
            int d = root.left.left.nextRight != null ?
                                  root.left.left.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.left.left.data + " is "
                    + d);
        }

        // Sets the nextRight of root and calls connectRecur() for other nodes
        static void connect(Node p)
        {

            // Set the nextRight for root
            p.nextRight = null;

            // Set the next right for rest of the nodes (other than root)
            connectRecur(p);
        }

        /* Set next right of all descendents of p.
           Assumption:  p is a compete binary tree */
        static void connectRecur(Node p)
        {
            // Base case
            if (p == null)
                return;

            // Set the nextRight pointer for p's left child
            if (p.left != null)
                p.left.nextRight = p.right;

            // Set the nextRight pointer for p's right child
            // p->nextRight will be NULL if p is the right most child 
            // at its level
            if (p.right != null)
                p.right.nextRight = (p.nextRight != null) ?
                                             p.nextRight.left : null;

            // Set nextRight for other nodes in pre order fashion
            connectRecur(p.left);
            connectRecur(p.right);
        }
    }

    // A binary tree node
    class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }
}

//http://www.geeksforgeeks.org/connect-nodes-at-same-level/