using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construct_AllPossible_BSTs_ForKeys_1ToN
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construct all possible BSTs
            List<Node> totalTreesFrom1toN = constructTrees(1, 3);


            /*  Printing preorder traversal of all constructed BSTs   */
            Console.Write("Preorder traversals of all constructed BSTs are \n");
            for (int i = 0; i < totalTreesFrom1toN.Count(); i++)
            {
                preorder(totalTreesFrom1toN[i]);
                Console.WriteLine();
            }
        }

        // A utility function to do preorder traversal of BST
        static void preorder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.data + " ");
                preorder(root.left);
                preorder(root.right);
            }
        }

        //  function for constructing trees
        static List<Node> constructTrees(int start, int end)
        {
            List<Node> list = new List<Node>();

            /*  if start > end   then subtree will be empty so returning NULL
                in the list */
            if (start > end)
            {
                list.Add(null);
                return list;
            }

            /*  iterating through all values from start to end  for constructing
                left and right subtree recursively  */
            for (int i = start; i <= end; i++)
            {
                /*  constructing left subtree   */
                List<Node> leftSubtree = constructTrees(start, i - 1);

                /*  constructing right subtree  */
                List<Node> rightSubtree = constructTrees(i + 1, end);

                /*  now looping through all left and right subtrees and connecting
                    them to ith root  below  */
                for (int j = 0; j < leftSubtree.Count(); j++)
                {
                    Node left = leftSubtree[j];
                    for (int k = 0; k < rightSubtree.Count(); k++)
                    {
                        Node right = rightSubtree[k];
                        Node node = new Node(i);// making value i as root
                        node.left = left;              // connect left subtree
                        node.right = right;            // connect right subtree
                        list.Add(node);           // add this tree to list
                    }
                }
            }
            return list;
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

//http://www.geeksforgeeks.org/construct-all-possible-bsts-for-keys-1-to-n/

// Average Difficulty : 4.6/5.0
//Based on 76 vote(s)


/*
 * ALGO::
 * 
 * 0. 
 * 1. Call List<Node> function with start and end keys.
 * 2. Create a new list.
 * 3. Check for start-end null case and add null to this list and return.
 * 4. For loop from start to end (i)
 *      Set a new left subtree List<node> by Recur with start to i-1.
 *      Set a new right subtree List<node> by Recur with i+1 to end.
 *      For Loop the leftsubtree (j)
 *          Set a new left children as the kth item.
 *          For Loop the leftsubtree (k)
 *              Set a new right children as the kth item.
 *              Create a new node with ith data.
 *              Set left children and right children created previously.
 *              Add this node to List
 *14. In the last, return the final List<node>.
 */
