using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correct_BST_By_Swapping_TwoNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n1 = new TreeNode { Data = 10 };
            n1.Right = new TreeNode { Data = 8 };
            TreeNode n2 = new TreeNode { Data = 5 };
            TreeNode n3 = new TreeNode { Data = 2 };
            TreeNode n4 = new TreeNode { Data = 20 };
            n1.Left = n2;
            n2.Left = n3;
            n2.Right = n4;
            Console.WriteLine("InCorrect Bst Inorder traversal :");
            InOrder(n1);
            CorrectBst(n1);
            Console.WriteLine();
            Console.WriteLine("Corrected Bst Inorder traversal");
            InOrder(n1);
        }

        static void CorrectBst(TreeNode node)
        {
            TreeNode[] nodesToSwap = new TreeNode[2];
            CorrectBstUtil(node, nodesToSwap, int.MaxValue, int.MinValue);
            if (nodesToSwap[0] != null && nodesToSwap[1] != null)
            {
                var temp = nodesToSwap[0].Data;
                nodesToSwap[0].Data = nodesToSwap[1].Data;
                nodesToSwap[1].Data = temp;
            }
        }

        static void CorrectBstUtil(TreeNode node, TreeNode[] nodesToSwap, int max, int min)
        {
            if (node.Data > max || node.Data < min)
            {
                if (nodesToSwap[0] == null)
                    nodesToSwap[0] = node;
                else
                    nodesToSwap[1] = node;
            }

            if (node.Left != null)
                CorrectBstUtil(node.Left, nodesToSwap, node.Data, min);
            if (node.Right != null)
                CorrectBstUtil(node.Right, nodesToSwap, max, node.Data + 1);
        }

        static void InOrder(TreeNode node)
        {
            if (node == null)
                return;

            InOrder(node.Left);
            Console.Write(node.Data + "  ");
            InOrder(node.Right);
        }


        /* A binary tree node has data, pointer to left child
           and a pointer to right child */
    }

    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}

//http://code.geeksforgeeks.org/msQ6MS

//http://www.geeksforgeeks.org/fix-two-swapped-nodes-of-bst/