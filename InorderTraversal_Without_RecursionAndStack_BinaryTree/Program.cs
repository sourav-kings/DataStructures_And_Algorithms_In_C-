using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InorderTraversal_Without_RecursionAndStack_BinaryTree
{
    class Program
    {
        static tNode root;
        static void Main(string[] args)
        {

            /* Constructed binary tree is
                    1
                  /   \
                 2      3
               /  \
             4     5
             */

            
            root = new tNode(1);
            root.left = new tNode(2);
            root.right = new tNode(3);
            root.left.left = new tNode(4);
            root.left.right = new tNode(5);

            MorrisTraversal(root);


           
        }

        /* Function to traverse binary tree without recursion and 
        without stack */
        static void MorrisTraversal(tNode root)
        {
            tNode current, pre;

            if (root == null)
                return;

            current = root;
            while (current != null)
            {
                if (current.left == null)
                {
                    Console.Write(current.data + " ");
                    current = current.right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pre = current.left;
                    while (pre.right != null && pre.right != current)
                        pre = pre.right;

                    /* Make current as right child of its inorder predecessor */
                    if (pre.right == null)
                    {
                        pre.right = current;
                        current = current.left;
                    }

                    /* Revert the changes made in if part to restore the 
                       original tree i.e.,fix the right child of predecssor*/
                    else
                    {
                        pre.right = null;
                        Console.Write(current.data + " ");
                        current = current.right;
                    }   /* End of if condition pre->right == NULL */

                } /* End of if condition current->left == NULL*/

            } /* End of while */

        }

        /* A binary tree tNode has data, pointer to left child
         and a pointer to right child */
        class tNode
        {
            public int data;
            public tNode left, right;

            public tNode(int item)
            {
                data = item;
                left = right = null;
            }
        }
    }
}


//http://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion-and-without-stack/