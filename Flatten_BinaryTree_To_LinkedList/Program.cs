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
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(6);

            flattenRecursive(root);
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
            Console.Write(root1.data + " --> ");
            flattenRecursive(root1.left);
            flattenRecursive(root1.right);

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