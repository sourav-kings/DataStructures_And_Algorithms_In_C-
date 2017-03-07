using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Alternate_K_Nodes_LinkedList
{
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            // Creating the linkedlist
            for (int i = 20; i > 0; i--)
            {
                push(i);
            }
            Console.WriteLine("Given Linked List :");
            printList(head);
            head = kAltReverse(head, 3);
            Console.WriteLine("");
            Console.WriteLine("Modified Linked List :");
            printList(head);
        }

        /* Reverses alternate k nodes and
            returns the pointer to the new head node */
        static Node kAltReverse(Node node, int k)
        {
            Node current = node;
            Node next = null, prev = null;
            int count = 0;

            /*1) reverse first k nodes of the linked list */
            while (current != null && count < k)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                count++;
            }

            /* 2) Now head points to the kth node.  So change next 
             of head to (k+1)th node*/
            if (node != null)
            {
                node.next = current;
            }

            /* 3) We do not want to reverse next k nodes. So move the current 
             pointer to skip next k nodes */
            count = 0;
            while (count < k - 1 && current != null)
            {
                current = current.next;
                count++;
            }

            /* 4) Recursively call for the list starting from current->next.
             And make rest of the list as next of first node */
            if (current != null)
            {
                current.next = kAltReverse(current.next, k);
            }

            /* 5) prev is new head of the input list */
            return prev;
        }

        static void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }

        static void push(int newdata)
        {
            Node mynode = new Node(newdata);
            mynode.next = head;
            head = mynode;
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


//http://www.geeksforgeeks.org/reverse-alternate-k-nodes-in-a-singly-linked-list/
//Average Difficulty : 3.2/5.0
//Based on 64 vote(s)