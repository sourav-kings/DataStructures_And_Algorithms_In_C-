using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone__BinaryTree_With_RandomPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            Node tree = new Node(1);
            tree.left = new Node(2);
            tree.right = new Node(3);
            tree.left.left = new Node(4);
            tree.left.right = new Node(5);
            tree.random = tree.left.right;
            tree.left.left.random = tree;
            tree.left.right.random = tree.right;

            //  Test No 2
            //    tree = null;

            //  Test No 3
            //    tree = new Node(1);

            //  Test No 4
            //    tree = new Node(1);
             //   tree.left = new Node(2);
              //  tree.right = new Node(3);
              //  tree.random = tree.right;
                tree.left.random = tree;
            

            Console.Write( "Inorder traversal of original binary tree is: \n");
            printInorder(tree);

            Node clone = cloneTree(tree);

            Console.Write("\n\nInorder traversal of cloned binary tree is: \n");
            printInorder(clone);
        }

        //Given a binary tree, print its Nodes in inorder
        static void printInorder(Node node)
        {
            if (node == null)
                return;

            // First recur on left sutree 
            printInorder(node.left);

            // then print data of Node and its random 
            Console.Write( "[" + node.key + " ");
            if (node.random == null)
                Console.Write( "null], ");
            else
                Console.Write( node.random.key + "], ");

            // now recur on right subtree 
            printInorder(node.right);
        }

        // This function creates clone by copying key and left and right pointers
        // This function also stores mapping from given tree node to clone.
        static Node copyLeftRightNode(Node treeNode, Dictionary<Node, Node> mymap)
        {
            if (treeNode == null)
                return null;
            Node cloneNode = new Node(treeNode.key);
            (mymap)[treeNode] = cloneNode;
            cloneNode.left = copyLeftRightNode(treeNode.left, mymap);
            cloneNode.right = copyLeftRightNode(treeNode.right, mymap);
            return cloneNode;
        }

        // This function copies random node by using the hashmap built by
        // copyLeftRightNode()
        static void copyRandom(Node treeNode, Node cloneNode, Dictionary<Node, Node> mymap)
        {
            if (cloneNode == null)
                return;

            if(treeNode.random != null)
                cloneNode.random = (mymap)[treeNode.random];

            copyRandom(treeNode.left, cloneNode.left, mymap);
            copyRandom(treeNode.right, cloneNode.right, mymap);
        }

        // This function makes the clone of given tree. It mainly uses
        // copyLeftRightNode() and copyRandom()
        static Node cloneTree(Node tree)
        {
            if (tree == null)
                return null;
            Dictionary<Node, Node> mymap = new Dictionary<Node, Node>();
            Node newTree = copyLeftRightNode(tree, mymap);
            copyRandom(tree, newTree, mymap);
            return newTree;
        }

    }
    class Node
    {
        public int key;
        public  Node left, right, random;

        public Node(int key)
        {
            this.key = key;
        }
    };
}
//http://www.geeksforgeeks.org/clone-binary-tree-random-pointers/
//Average Difficulty : 4.5/5.0
//Based on 126 vote(s)