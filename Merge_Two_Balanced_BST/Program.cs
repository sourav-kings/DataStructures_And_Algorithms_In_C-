using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Two_Balanced_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 3, 5, 7, 9 };
            Node node1 = arrayToBST(arr1, 0, arr1.Length - 1);
            printBST(node1);
            Console.WriteLine();

            int[] arr2 = { 2, 4, 6, 8, 15 };
            Node node2 = arrayToBST(arr2, 0, arr2.Length - 1);

            printBST(node2);
            Console.WriteLine();


            Node node = merge(node1, node2);

            printBST(node);
            Console.WriteLine();
        }

        static Node merge(Node node1, Node node2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            createList(node1, list1);
            createList(node2, list2);
            int[] arr = new int[list1.Count() + list2.Count()];
            merge(list1, list2, arr);
            return arrayToBST(arr, 0, arr.Length - 1);
        }

        static void createList(Node root, List<int> list)
        {
            if (root == null)
                return;

            createList(root.left, list);
            list.Add(root.data);
            createList(root.right, list);
        }

        static void merge(List<int> list1, List<int> list2, int[] arr)
        {
            int i = 0;
            while (list1.Count() > 0 && list2.Count() > 0)
            {
                if (list1.ElementAt(0) < list2.ElementAt(0))
                {
                    arr[i++] = list1.ElementAt(0);
                    list1.RemoveAt(0);
                }
                else
                {
                    arr[i++] = list2.ElementAt(0);
                    list2.RemoveAt(0);
                }
            }

            while (list1.Count() != 0)
            {
                arr[i++] = list1.ElementAt(0);
                list1.RemoveAt(0);
            }

            while (list2.Count() != 0)
            {
                arr[i++] = list2.ElementAt(0);
                list2.RemoveAt(0);
            }
        }

        static Node arrayToBST(int[] arr, int low, int high)
        {
            if (high < low)
                return null;

            if (arr == null || arr.Length == 0)
                return null;

            int mid = low + (high - low) / 2;
            Node node = new Node(arr[mid]);
            node.left = arrayToBST(arr, low, mid - 1);
            node.right = arrayToBST(arr, mid + 1, high);

            return node;
        }


        static void printBST(Node node)
        {
            if (node == null)
                return;

            // pre-order

            Console.Write(node.data + " ");

            printBST(node.left);
            printBST(node.right);
        }
    }

    class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node(int d)
        {
            data = d;
        }
    }
}
/*can also be solved by:-
 * conversion of binary tree to Doubly linklist and then merge two DLLs and the convert DLL to Binary tree*/
//http://code.geeksforgeeks.org/hoZVLv

//http://www.geeksforgeeks.org/merge-two-balanced-binary-search-trees/
