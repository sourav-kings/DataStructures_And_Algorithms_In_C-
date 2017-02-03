using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_If_BinaryTree_Is_Balanced
{
    class Program
    {
        static TreeNode root;
        static void Main(string[] args)
        {
            /*
                                    0
                              1             2
                          3      4       5  
                            6              7
                              8
            */

            createTree();

            Console.WriteLine("tree is balanced: " + checkIfBalanced());
        }

        static TreeNode createTree()
        {
            root = new TreeNode(0);
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);
            TreeNode n8 = new TreeNode(8);

            root.left = n1;
            root.right = n2;

            n1.left = n3;
            n1.right = n4;

            n2.left = n5;

            n3.right = n6;

            n5.right = n7;

            n6.right = n8;

            return root;
        }


        // this function returns height of tree rooted at currentNode if the tree is balanced
        // otherwise it returns -1
        static int checkBalance(TreeNode currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            // check if left sub-tree is balanced
            int leftSubtreeHeight = checkBalance(currentNode.left);
            if (leftSubtreeHeight == -1) return -1;

            // check if right sub-tree is balanced
            int rightSubtreeHeight = checkBalance(currentNode.right);
            if (rightSubtreeHeight == -1) return -1;

            // if both sub-trees are balanced, check the difference of heights
            // should be less than or equal to 1 
            if (Math.Abs(leftSubtreeHeight - rightSubtreeHeight) > 1)
            {
                return -1;
            }

            // if tree rooted at this node is balanced, return height if tree rooted at this this node
            return (Math.Max(leftSubtreeHeight, rightSubtreeHeight) + 1);
        }


        static bool checkIfBalanced()
        {
            if (checkBalance(root) == -1)
            {
                return false;
            }
            return true;
        }
    }

    class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

}

//check-if-a-binary-tree-is-balanced