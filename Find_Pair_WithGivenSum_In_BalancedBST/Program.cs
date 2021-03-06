﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Pair_WithGivenSum_In_BalancedBST
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
               15
            /     \
          10      20
         / \     /  \
        8  12   16  25    */
            Node root = new Node(15);
            root.left = new Node(10);
            root.right = new Node(20);
            root.left.left = new Node(8);
            root.left.right = new Node(12);
            root.right.left = new Node(16);
            root.right.right = new Node(25);

            int target = 30;
            //int target = 5;
            //int target = 200;
            if (isPairPresent(root, target) == false)
                Console.WriteLine("\n No such values are found\n");
        }


        // Returns true if a pair with target sum exists in BST, otherwise false
        static bool isPairPresent(Node root, int target)
        {
            // Create two stacks. s1 is used for normal inorder traversal
            // and s2 is used for reverse inorder traversal
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();

            // Note the sizes of stacks is MAX_SIZE, we can find the tree size and
            // fix stack size as O(Logn) for balanced trees like AVL and Red Black
            // tree. We have used MAX_SIZE to keep the code simple

            // done1, val1 and curr1 are used for normal inorder traversal using s1
            // done2, val2 and curr2 are used for reverse inorder traversal using s2
            bool done1 = false, done2 = false;
            int val1 = 0, val2 = 0;
            Node curr1 = root, curr2 = root;
 
            // The loop will break when we either find a pair or one of the two
            // traversals is complete
           while (1==1)
           {
                // Find next node in normal Inorder traversal. See following post
                // http://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
                while (done1 == false)
                {
                    if (curr1 != null)
                    {
                        s1.Push(curr1);
                        curr1 = curr1.left;
                    }
                    else
                    {                        
                        if (s1.Any())                            
                        {
                            curr1 = s1.Pop();
                            val1 = curr1.data;
                            curr1 = curr1.right;
                        }
                        done1 = true;
                    }
                }
 
                // Find next node in REVERSE Inorder traversal. The only
                // difference between above and below loop is, in below loop
                // right subtree is traversed before left subtree
                while (done2 == false)
                {
                    if (curr2 != null)
                    {
                        s2.Push(curr2);
                        curr2 = curr2.right;
                    }
                    else
                    {
                        if (s2.Any())
                        {
                            curr2 = s2.Pop();
                            val2 = curr2.data;
                            curr2 = curr2.left;
                        }
                        done2 = true;
                    }
                }
 
                // If we find a pair, then print the pair and return. The first
                // condition makes sure that two same values are not added
                if ((val1 != val2) && (val1 + val2) == target)
                {
                    Console.WriteLine("\n Pair Found: " + val1 + " + " + val2 + " = " + target);
                    return true;
                }
 
                // If sum of current values is smaller, then move to next node in
                // normal inorder traversal
                else if ((val1 + val2) < target)
                    done1 = false;
 
                // If sum of current values is greater, then move to next node in
                // reverse inorder traversal
                else if ((val1 + val2) > target)
                    done2 = false;

                // If any of the inorder traversals is over, then there is no pair
                // so return false
                if (val1 >= val2)
                    return false;
            }
        }
    }

    class Node
    {

        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}


//http://www.geeksforgeeks.org/find-a-pair-with-given-sum-in-bst/
// Average Difficulty : 4.2/5.0
//Based on 86 vote(s)

/*

Here we are not allowed to modify the BST.

The Brute Force Solution is to consider each pair in BST and check whether the sum equals to X. 
The time complexity of this solution will be O(n^2).

A Better Solution is to create an auxiliary array and store Inorder traversal of BST in the array. 
The array will be sorted as Inorder traversal of BST always produces sorted data. Once we have the Inorder traversal, we can pair in O(n) time (See this for details). This solution works in O(n) time, but requires O(n) auxiliary space.

A space optimized solution is discussed in previous post. The idea was to first in-place convert BST to Doubly Linked List (DLL), then find pair in sorted DLL in O(n) time. This solution takes O(n) time and O(Logn) extra space, but it modifies the given BST.

The solution discussed below takes O(n) time, O(Logn) space and doesn’t modify BST. The idea is same as finding the pair in sorted array (See method 1 of this for details). We traverse BST in Normal Inorder and Reverse Inorder simultaneously. In reverse inorder, we start from the rightmost node which is the maximum value node. In normal inorder, we start from the left most node which is minimum value node. We add sum of current nodes in both traversals and compare this sum with given target sum. If the sum is same as target sum, we return true. If the sum is more than target sum, we move to next node in reverse inorder traversal, otherwise we move to next node in normal inorder traversal. If any of the traversals is finished without finding a pair, we return false. Following is C++ implementation of this approach.

 */
