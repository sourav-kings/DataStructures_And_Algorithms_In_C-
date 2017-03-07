using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatten_BinaryTree_To_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Constructed binary tree is:
                  1
                /  \
               2    3
              / \    
             4   5     */
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            flattenNonRecursiveWithStack(root); //InOrder Traversal (4 --> 2 --> 5 --> 1 --> 3)
            Console.WriteLine();
            flattenRecursive(root);//InOrder Traversal (4 --> 2 --> 5 --> 1 --> 3)
        }

        static void flatten(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);
            TreeNode p = root;

            while (stk.Any())
            {
                TreeNode curr = stk.Pop();
                if (curr.right != null)
                    stk.Push(curr.right);
                if (curr.left != null)
                    stk.Push(curr.left);
                if (stk.Any())
                    curr.right = stk.Peek();
                curr.left = null;  // dont forget this!! 
            }

            foreach (TreeNode value in stk){
                Console.Write(value.data + " --> ");
            }
            
        }
        

        static void flattenRecursive(TreeNode root1)
        {
            if (root1 == null)
                return;
            flattenRecursive(root1.left);
            Console.Write(root1.data + " --> ");
            flattenRecursive(root1.right);

        }

        static void flattenNonRecursiveWithStack(TreeNode root)
        {
            if (root == null)
                return;

            //keep the nodes in the path that are waiting to be visited
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            //first node to be visited will be the left one
            while (node != null)
            {
                stack.Push(node);
                node = node.left;
            }

            // traverse the tree
            while (stack.Any())
            {

                // visit the top node
                node = stack.Pop();
                Console.Write(node.data + " --> ");
                //if (node.right != null)
                //{
                    node = node.right;

                    // the next node to be visited is the leftmost
                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.left;
                    }
               // }
            }
        }
    }

    class TreeNode
    {
        public int data;
        public TreeNode left, right;

        public TreeNode(int data)
        {
            this.data = data;
        }
    }
}

//http://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/

//https://discuss.leetcode.com/category/122/flatten-binary-tree-to-linked-list
//https://discuss.leetcode.com/topic/11444/my-short-post-order-traversal-java-solution-for-share/2

//


/*
 * Solution with recursion
 * 1. just do the inorder traversal
 * 
 * 
 * Solution with stack (No recursion)
 * 
 * 0.
 * 1. Check base case of node == null
 * 2. Create a stack.
 * 3. Loop node until null:- i. Push node in stack; ii. Set node as left node.
 * 4. Loop stack until empty:-
 *        i. Pop item and set as current node.
 *       ii. Print current node.
 *      iii. Set node.right as current node.
 *       iv. Loop node until null:- i. Push node in stack; ii. Set node as right node.

 */
