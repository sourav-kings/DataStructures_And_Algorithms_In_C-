using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_Subtree_Of_Another_BinaryTree
{
    class Program
    {
        static Node root1, root2;
        static Passing p = new Passing();
        static void Main(string[] args)
        {
            // TREE 1
            /* Construct the following tree
                  26
                 /   \
                10     3
               /    \     \
              4      6      3
               \
                30  */

            root1 = new Node(26);
            root1.right = new Node(3);
            root1.right.right = new Node(3);
            root1.left = new Node(10);
            root1.left.left = new Node(4);
            root1.left.left.right = new Node(30);
            root1.left.right = new Node(6);

            // TREE 2
            /* Construct the following tree
               10
             /    \
             4      6
              \
              30  */

            root2 = new Node(10);
            root2.right = new Node(6);
            root2.left = new Node(4);
            root2.left.right = new Node(30);

            if (isSubtree(root1, root2))
                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1");




            Node rootA = new Node(1);
            rootA.left = new Node(2);
            rootA.right = new Node(4);
            rootA.left.left = new Node(3);
            rootA.right.right = new Node(6);
            rootA.right.left = new Node(5);

            Node rootB = new Node(4);
            rootB.left = new Node(5);
            rootB.right = new Node(6);

            if (isSubtreeFaster(rootA, rootB))
                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1");

            if (checkIfSubtree(root1, root2))
                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1"); 
        }

        /* A utility function to check whether trees with roots as root1 and
        root2 are identical or not */
        static bool areIdentical(Node root1, Node root2)
        {

            /* base cases */
            if (root1 == null && root2 == null)
                return true;

            if (root1 == null || root2 == null)
                return false;

            /* Check if the data of both roots is same and data of left and right
               subtrees are also same */
            return (root1.data == root2.data
                    && areIdentical(root1.left, root2.left)
                    && areIdentical(root1.right, root2.right));
        }

        /* This function returns true if S is a subtree of T, otherwise false */
        static bool isSubtree(Node T, Node S)
        {
            /* base cases */
            if (S == null)
                return true;

            if (T == null)
                return false;

            /* Check the tree with root as current node */
            if (areIdentical(T, S))
                return true;

            /* If the tree with root as current node doesn't match then
               try left and right subtrees one by one */
            return isSubtree(T.left, S)
                    || isSubtree(T.right, S);
        }








        static string strstr(string haystack, string needle)
        {
            if (haystack == null || needle == null)
            {
                return null;
            }
            int hLength = haystack.Length;
            int nLength = needle.Length;
            if (hLength < nLength)
            {
                return null;
            }
            if (nLength == 0)
            {
                return haystack;
            }
            for (int i = 0; i <= hLength - nLength; i++)
            {
                if (haystack[i] == needle[0])
                {
                    int j = 0;
                    for (; j < nLength; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            break;
                        }
                    }
                    if (j == nLength)
                    {
                        return haystack.Substring(i);
                    }
                }
            }
            return null;
        }

        // A utility function to store inorder traversal of tree rooted
        // with root in an array arr[]. Note that i is passed as reference
        static void storeInorder(Node node, char[] arr, Passing i)
        {
            if (node == null)
            {
                arr[i.i++] = '$';
                return;
            }
            storeInorder(node.left, arr, i);
            arr[i.i++] = Convert.ToChar(node.data);
            storeInorder(node.right, arr, i);
        }

        // A utility function to store preorder traversal of tree rooted
        // with root in an array arr[]. Note that i is passed as reference
        static void storePreOrder(Node node, char[] arr, Passing i)
        {
            if (node == null)
            {
                arr[i.i++] = '$';
                return;
            }
            arr[i.i++] = Convert.ToChar(node.data);
            storePreOrder(node.left, arr, i);
            storePreOrder(node.right, arr, i);
        }

        /* This function returns true if S is a subtree of T, otherwise false */
        static bool isSubtreeFaster(Node T, Node S)
        {
            /* base cases */
            if (S == null)
            {
                return true;
            }
            if (T == null)
            {
                return false;
            }

            // Store Inorder traversals of T and S in inT[0..m-1]
            // and inS[0..n-1] respectively
            char[] inT = new char[100];
            string op1 = new string(inT);
            char[] inS = new char[100];
            string op2 = new string(inS);
            storeInorder(T, inT, p);
            storeInorder(S, inS, p);
            inT[p.m] = '\0';
            inS[p.m] = '\0';

            // If inS[] is not a substring of preS[], return false
            if (strstr(op1, op2) != null)
            {
                return false;
            }

            // Store Preorder traversals of T and S in inT[0..m-1]
            // and inS[0..n-1] respectively
            p.m = 0;
            p.n = 0;
            char[] preT = new char[100];
            char[] preS = new char[100];
            string op3 = new string(preT);
            string op4 = new string(preS);
            storePreOrder(T, preT, p);
            storePreOrder(S, preS, p);
            preT[p.m] = '\0';
            preS[p.n] = '\0';

            // If inS[] is not a substring of preS[], return false
            // Else return true
            return (strstr(op3, op4) != null);
        }







        static private void fillUpPreorderString(String[] traversalString, Node node)
        {
            if (node == null)
            {
                return;
            }

            traversalString[0] += node.data;
            fillUpPreorderString(traversalString, node.left);
            fillUpPreorderString(traversalString, node.right);
        }


        static private void fillUpInorderString(String[] traversalString, Node node)
        {
            if (node == null)
            {
                return;
            }

            fillUpInorderString(traversalString, node.left);
            traversalString[0] += node.data;
            fillUpInorderString(traversalString, node.right);
        }


        static public bool checkIfSubtree(Node bigTree, Node smallTree)
        {
            string[] inorderForBigTree = { "" };
            string[] inorderForSmallTree = { "" };

            fillUpInorderString(inorderForBigTree, bigTree);
            fillUpInorderString(inorderForSmallTree, smallTree);

            if (inorderForBigTree[0].Contains(inorderForSmallTree[0]))
            {
                string[] preorderForBigTree = { "" };
                string[] preorderForSmallTree = { "" };

                fillUpPreorderString(preorderForBigTree, bigTree);
                fillUpPreorderString(preorderForSmallTree, smallTree);

                return preorderForBigTree[0].Contains(preorderForSmallTree[0]);
            }

            return false;
        }
    }

    // A binary tree node
    class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }

    class Passing
    {

        public int i;
        public int m = 0;
        public int n = 0;
    }
}


//http://www.geeksforgeeks.org/check-if-a-binary-tree-is-subtree-of-another-binary-tree/
//http://www.geeksforgeeks.org/check-binary-tree-subtree-another-binary-tree-set-2/
