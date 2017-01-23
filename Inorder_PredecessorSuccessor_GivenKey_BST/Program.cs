using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inorder_PredecessorSuccessor_GivenKey_BST
{
    class Program
    {
        public static Node root;
        public static Node pre;
        public static Node suc;
        static void Main(string[] args)
        {
            int key = 20;
            insert(70);
            insert(20);
            insert(50);
            insert(10);
            insert(30);
            insert(60);
            insert(40);

            printTree(root);
            predSucc(root, key);
            Console.WriteLine("");
            Console.WriteLine("predecessor : " + pre.data);
            Console.WriteLine("sucsessor : " + suc.data);
        }

        static public void insert(int key)
        {
            root = insert(root, key);
        }

        static public Node insert(Node node, int key)
        {
            if (node == null)
            {
                node = new Node(key);
                return node;
            }

            if (key < node.data)
                node.left = insert(node.left, key);
            else if (key > node.data)
                node.right = insert(node.right, key);
            return node;
        }

        static public void printTree(Node node)
        {
            if (node != null)
            {
                printTree(node.left);
                Console.Write(node.data + " ");
                printTree(node.right);
            }
        }

        static public void predSucc(Node node, int key)
        {
            if (node == null)
                return;

            if (node.data == key)
            {
                if (node.left != null)
                {
                    Node temp = node.left;
                    while (temp.right != null)
                        temp = temp.right;
                    pre = temp;
                }

                if (node.right != null)
                {
                    Node temp = node.right;
                    while (temp.left != null)
                        temp = temp.left;
                    suc = temp;
                }
            }

            if (key < node.data)
            {
                suc = node;
                predSucc(node.left, key);
            }
            else if (key > node.data)
            {
                pre = node;
                predSucc(node.right, key);
            }
        }

    }

    // BST Node
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
}
