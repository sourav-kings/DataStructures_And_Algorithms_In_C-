using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNodes_In_TopView_BinaryTree
{
    class Program
    {
        static TreeNode root;
        static void Main(string[] args)
        {
            /* Create following Binary Tree
                     1
                   /  \
                  2    3
                   \
                    4
                     \
                      5
                       \
                        6*/
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.left.right.right = new TreeNode(5);
            root.left.right.right.right = new TreeNode(6);
            Console.WriteLine("Following are nodes in top view of Binary Tree");
            printTopView();
        }

        // This method prints nodes in top view of binary tree
        static void printTopView()
        {
            // base case
            if (root == null) { return; }

            // Creates an empty hashset
            HashSet<int> set = new HashSet<int>();

            // Create a queue and add root to it
            Queue<QItem> Q = new Queue<QItem>();
            Q.Enqueue(new QItem(root, 0)); // Horizontal distance of root is 0

            // Standard BFS or level order traversal loop
            while (Q.Any())
            {
                // Remove the front item and get its details
                QItem qi = Q.Dequeue();

                int hd = qi.hd;
                TreeNode n = qi.node;

                // If this is the first node at its horizontal distance,
                // then this node is in top view
                if (!set.Contains(hd))
                {
                    set.Add(hd);
                    Console.Write(n.key + " ");
                }

                // Enqueue left and right children of current node
                if (n.left != null)
                    Q.Enqueue(new QItem(n.left, hd - 1));
                if (n.right != null)
                    Q.Enqueue(new QItem(n.right, hd + 1));
            }
        }
    }

    // Class for a tree node
    class TreeNode
    {
        // Members
        public int key;
        public TreeNode left, right;

        // Constructor
        public TreeNode(int key)
        {
            this.key = key;
            left = right = null;
        }
    }

    // A class to represent a queue item. The queue is used to do Level
    // order traversal. Every Queue item contains node and horizontal
    // distance of node from root
    class QItem
    {
        public TreeNode node;
        public int hd;
        public QItem(TreeNode n, int h)
        {
            node = n;
            hd = h;
        }
    }

}

//http://www.geeksforgeeks.org/print-nodes-top-view-binary-tree/
//Average Difficulty : 3.3/5.0
//Based on 82 vote(s)

/*
 * ALGO::
 * 
 * 0.
 * 1. Make a new class  'QItem' with fields 'horizontal distance' and 'node'.
 * 2. Call function with node and hd =0.
 * 3. Make a new HashSet to store each unqiue hd values.
 * 4. Make a new Queue of type 'QItem'.
 * 5. Add new root value to Queue with node == root and hd == 0;
 * 6. Run WHILE loop until queue has data:
 * 7.       Deque item and get its hd and Node values.
 * 8.       If this hd doesn't exists in the HashSet, then print it and this to HashSet.
 *          ( If this is the first node at its horizontal distance, then this node is in top view)
 * 9. If left child exists, enqueue Qitem with left child node and hd - 1.
 * 10.If right child exists, enqueue Qitem with right child node and hd + 1.
 */
