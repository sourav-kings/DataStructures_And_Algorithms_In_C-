using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_BinaryTree_From_InorderPreorderTraversals
{
    class Program
    {
        //static Node root;
        static int preIndex = 0;
        static void Main(string[] args)
        {
            char[] inOrder = new char[]{'D', 'B', 'E', 'A', 'F', 'C'};
            char[] preOrder = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
            int len = inOrder.Length;
            Node root = buildTree(inOrder, preOrder, 0, len - 1);
            Console.WriteLine("Inorder traversal of constructed tree is : ");
            printInorder(root);//O(n * n)

            Console.WriteLine();

            int[] preOrder2 = new int[] { 1, 2, 4, 5, 3, 6, 7 };
            int[] inOrder2 = new int[] { 4, 2, 5,1, 6, 3, 7 };
            TreeNode root2 = buildTreeFaster(preOrder2, inOrder2);
            Console.WriteLine("Faster Inorder traversal of constructed tree is : ");
            printInorder2(root2);//O(n)

        }





        static TreeNode buildTreeFaster(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null)
                return null;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++) //map inorder index for each node to map index faster 
            {
                map[inorder[i]] = i;
            }
            return helper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, map);
        }
        static TreeNode helper(int[] preorder, int preL, int preR, int[] inorder, int inL, int inR, Dictionary<int, int> map)
        {
            if (preL > preR || inL > inR)
                return null;
            TreeNode root = new TreeNode(preorder[preL]); //according to the preorder, the first must be the root for current sub tree
            int index = map[root.data]; //use hashmap to find index instead of linear search
            root.left  = helper(preorder, preL + 1,               index - inL + preL,      inorder, inL,       index - 1, map);
            root.right = helper(preorder, preL + index - inL + 1, preR,                    inorder, index + 1, inR,       map);
            return root;
        }
        static void printInorder2(TreeNode node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            printInorder2(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            printInorder2(node.right);
        }








        /* Recursive function to construct binary of size len from
           Inorder traversal inOrder[] and Preorder traversal pre[].
           Initial values of inStrt and inEnd should be 0 and len -1.  
           The function doesn't do any error checking for cases where 
           inorder and preorder do not form a tree */
        static Node buildTree(char[] inOrder, char[] pre, int inStrt, int inEnd)
        {
            if (inStrt > inEnd)
                return null;

            /* Pick current node from Preorder traversal using preIndex
               and increment preIndex */
            Node tNode = new Node(pre[preIndex++]);

            /* If this node has no children then return */
            if (inStrt == inEnd)
                return tNode;

            /* Else find the index of this node inOrder Inorder traversal */
            int inIndex = search(inOrder, inStrt, inEnd, tNode.data);

            /* Using index inOrder Inorder traversal, construct left and
               right subtress */
            tNode.left = buildTree(inOrder, pre, inStrt, inIndex - 1);
            tNode.right = buildTree(inOrder, pre, inIndex + 1, inEnd);

            return tNode;
        }

        /* UTILITY FUNCTIONS */

        /* Function to find index of value inOrder arr[start...end]
         The function assumes that value is present inOrder inOrder[] */
        static int search(char[] arr, int strt, int end, char value)
        {
            int i;
            for (i = strt; i <= end; i++)
            {
                if (arr[i] == value)
                    return i;
            }
            return i;
        }

        /* This funtcion is here just to test buildTree() */
        static void printInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            printInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            printInorder(node.right);
        }
    }


    /* A binary tree node has data, pointer to left child
       and a pointer to right child */
    class Node
    {
        public char data;
        public Node left, right;

        public Node(char item)
        {
            data = item;
            left = right = null;
        }
    }

    class TreeNode
    {
        public int data;
        public TreeNode left, right;

        public TreeNode(int item)
        {
            data = item;
            left = right = null;
        }
    }

}


//http://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/

//http://blog.welkinlan.com/2014/11/08/construct-binary-tree-from-preorder-and-inorder-traversal/#comment-3200

//Average Difficulty : 3.4/5.0
//Based on 131 vote(s)