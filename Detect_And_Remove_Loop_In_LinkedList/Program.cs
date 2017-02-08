﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detect_And_Remove_Loop_In_LinkedList
{
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            head = new Node(50);
            head.next = new Node(20);
            head.next.next = new Node(15);
            head.next.next.next = new Node(4);
            head.next.next.next.next = new Node(10);

            // Creating a loop for testing 
            head.next.next.next.next.next = head.next.next;
            //detectAndRemoveLoop(head);
            detectAndRemoveLoopFaster2nd(head);
            Console.Write("Linked List after removing loop : ");
            printList(head);
        }

        // Function that detects loop in the list
        static int detectAndRemoveLoop(Node node)
        {
            Node slow = node, fast = node;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                // If slow and fast meet at same point then loop is present
                if (slow == fast)
                {
                    //removeLoop(slow, node);
                    removeLoopFaster(slow, node);
                    return 1;
                }
            }
            return 0;
        }

        // Function to remove loop
        static void removeLoop(Node loop, Node curr)
        {
            Node ptr1 = null, ptr2 = null;

            /* Set a pointer to the beging of the Linked List and
             move it one by one to find the first node which is
             part of the Linked List */
            ptr1 = curr;
            while (1 == 1)
            {

                /* Now start a pointer from loop_node and check if it ever
                 reaches ptr2 */
                ptr2 = loop;
                while (ptr2.next != loop && ptr2.next != ptr1)
                {
                    ptr2 = ptr2.next;
                }

                /* If ptr2 reahced ptr1 then there is a loop. So break the
                 loop */
                if (ptr2.next == ptr1)
                {
                    break;
                }

                /* If ptr2 did't reach ptr1 then try the next node after ptr1 */
                ptr1 = ptr1.next;
            }

            /* After the end of loop ptr2 is the last node of the loop. So
             make next of ptr2 as NULL */
            ptr2.next = null;
        }

        // Function to remove loop
        static void removeLoopFaster(Node loop, Node head)
        {
            Node ptr1 = loop;
            Node ptr2 = loop;

            // Count the number of nodes in loop
            int k = 1, i;
            while (ptr1.next != ptr2)
            {
                ptr1 = ptr1.next;
                k++;
            }

            // Fix one pointer to head
            ptr1 = head;

            // And the other pointer to k nodes after head
            ptr2 = head;
            for (i = 0; i < k; i++)
            {
                ptr2 = ptr2.next;
            }

            /*  Move both pointers at the same pace,
             they will meet at loop starting node */
            while (ptr2 != ptr1)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            // Get pointer to the last node
            ptr2 = ptr2.next;
            while (ptr2.next != ptr1)
            {
                ptr2 = ptr2.next;
            }

            /* Set the next node of the loop ending node
             to fix the loop */
            ptr2.next = null;
        }


        // Function that detects loop in the list
        static void detectAndRemoveLoopFaster2nd(Node node)
        {
            Node slow = node;
            Node fast = node.next;

            // Search for loop using slow and fast pointers
            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    break;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            /* If loop exists */
            if (slow == fast)
            {
                slow = node;
                while (slow != fast.next)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                /* since fast->next is the looping point */
                fast.next = null; /* remove loop */

            }
        }
        // Function to print the linked list
        static void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }
    }

    class Node
    {

        public int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

}

//http://www.geeksforgeeks.org/detect-and-remove-loop-in-a-linked-list/