using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diameter_Of_BinaryTree
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.left.right.left = new Node(6);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.left.right = new Node(3);
            //root.left.left = new Node(4);
            //root.left.right.right = new Node(5);
            //root.left.left.left = new Node(10);

            Console.WriteLine("The diameter of given binary tree is : "
                               + diameter(root)); // O(n*n)

            Height height = new Height();
            Console.WriteLine("The diameter of given binary tree is : "
                               + diameterFaster(root, height)); // O(n)



            //root = new Node(1);
            //root.left = new Node(2);
            //root.left.right = new Node(3);
            //root.left.left = new Node(4);
            //root.left.right.right = new Node(5);
            //root.left.left.left = new Node(10);

    }

        /* Method to calculate the diameter and return it to main */
        static int diameter(Node root)
        {
            /* base case if tree is empty */
            if (root == null)
                return 0;

            /* get the height of left and right sub trees */
            int lheight = height(root.left);
            int rheight = height(root.right);

            /* get the diameter of left and right subtrees */
            int ldiameter = diameter(root.left);
            int rdiameter = diameter(root.right);

            /* Return max of following three
              1) Diameter of left subtree
             2) Diameter of right subtree
             3) Height of left subtree + height of right subtree + 1 */
            return Math.Max(lheight + rheight + 1,
                            Math.Max(ldiameter, rdiameter));

        }

        /* A wrapper over diameter(Node root) */
        //static int diameter()
        //{
        //    return diameter(root);
        //}

        /*The function Compute the "height" of a  Height is the
          number f nodes along the longest path from the root node
          down to the farthest leaf node.*/
        static int height(Node node)
        {
            /* base case tree is empty */
            if (node == null)
                return 0;

            /* If tree is not empty then height = 1 + max of left
               height and right heights */
            return (1 + Math.Max(height(node.left), height(node.right)));
        }

        /* define height =0 globally and  call diameterOpt(root,height)
         from main */
        static int diameterFaster(Node root, Height height)
        {
            /* lh -. Height of left subtree
               rh -. Height of right subtree */
            Height lh = new Height(), rh = new Height();

            if (root == null)
            {
                //height.h = 0;
                return 0; /* diameter is also 0 */
            }

            /* ldiameter  -. diameter of left subtree
               rdiameter  -. Diameter of right subtree */
            /* Get the heights of left and right subtrees in lh and rh
             And store the returned values in ldiameter and ldiameter */
            //lh.h++; rh.h++;
            int ldiameter = diameterFaster(root.left, lh);
            int rdiameter = diameterFaster(root.right, rh);

            /* Height of current node is max of heights of left and
             right subtrees plus 1*/
            //height.h = Math.Max(lh.h, rh.h) + 1;

            return 1 + Math.Max(lh.h + rh.h + 1, Math.Max(ldiameter, rdiameter));
        }

    }

    /* Class containing left and right child of current
 node and key value*/
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

    // A utility class to pass heigh object
    class Height
    {
        public int h;
    }

}


///http://www.geeksforgeeks.org/diameter-of-a-binary-tree/
///Average Difficulty : 3.2/5.0
///Based on 213 vote(s)