using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootToLeaf_PathSum_Equal_To_GivenNumber
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            int sum = 21;

            /* Constructed binary tree is
                  10
                 /  \
               8     2
              / \   /
             3   5 2
            */
            root = new Node(10);
            root.left = new Node(8);
            root.right = new Node(2);
            root.left.left = new Node(3);
            root.left.right = new Node(5);
            root.right.left = new Node(2);

            //root = null;

            if (haspathSum(root, sum))
                Console.WriteLine("There is a root to leaf path with sum " + sum);
            else
                Console.WriteLine("There is no root to leaf path with sum " + sum);
        }

        /*
     Given a tree and a sum, return true if there is a path from the root
     down to a leaf, such that adding up all the values along the path
     equals the given sum.
   
     Strategy: subtract the node value from the sum when recurring down,
     and check to see if the sum is 0 when you run out of
     */

        static bool haspathSum(Node node, int sum)
        {
            if (node == null)
                return false;

            /* otherwise check both subtrees */
            int subsum = sum - node.data;

            if (subsum == 0 && node.left == null && node.right == null)
                return true;
            if (node.left != null)
                return haspathSum(node.left, subsum);
            if (node.right != null)
                return haspathSum(node.right, subsum);

            return false;

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

//http://www.geeksforgeeks.org/root-to-leaf-path-sum-equal-to-a-given-number/

//Average Difficulty : 2.4/5.0
//Based on 100 vote(s)

/*
 * 0. Declare "ans" variable.
 * 1. call bool function with node & sum
 * 2. Get subsum by subtrating node data from sum.
 * 3. If subsum is zero and node's right and left is null, return true.
 * 4. If left child has value.
 *      Set ans as OR combination of ans and recur of function with left node and subsum.
 * 5. Repeat step 4 for right node
 * 6. Return ans variable.      
 */
