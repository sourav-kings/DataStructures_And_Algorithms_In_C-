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
                return (sum == 0);
            else
            {
                bool ans = false;

                /* otherwise check both subtrees */
                int subsum = sum - node.data;
                if (subsum == 0 && node.left == null && node.right == null)
                    return true;
                if (node.left != null)
                    ans = ans || haspathSum(node.left, subsum);
                if (node.right != null)
                    ans = ans || haspathSum(node.right, subsum);
                return ans;
            }
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
