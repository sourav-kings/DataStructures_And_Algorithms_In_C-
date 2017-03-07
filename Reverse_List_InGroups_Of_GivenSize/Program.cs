using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_List_InGroups_Of_GivenSize
{
    class Program
    {
        static Node head;  // head of list

        static void Main(string[] args)
        {
            /* Constructed Linked List is 1->2->3->4->5->6->7->8->8->9->null */
            push(9);
            push(8);
            push(7);
            push(6);
            push(5);
            push(4);
            push(3);
            push(2);
            push(1);

            Console.WriteLine("Given Linked List");
            printList();

            head = reverse(head, 3);

            Console.WriteLine("Reversed list");
            printList();
        }

        static Node reverse(Node head, int k)
        {
            Node current = head;
            Node next = null;
            Node prev = null;

            int count = 0;

            /* Reverse first k nodes of linked list */
            while (count < k && current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                count++;
            }

            /* next is now a pointer to (k+1)th node 
               Recursively call for the list starting from current.
               And make rest of the list as next of first node */
            if (next != null)
                head.next = reverse(next, k);

            // prev is now head of input list
            return prev;
        }


        /* Utility functions */

        /* Inserts a new Node at front of the list. */
        static public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                      Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        /* Function to print linked list */
        static void printList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }

    /* Linked list Node*/
    class Node
    {
        public int data;
        public Node next;
        public Node(int d) { data = d; next = null; }
    }
}
//http://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/

//Average Difficulty : 3.2/5.0
//Based on 186 vote(s)

    /*
     
    Algorithm: reverse(head, k)
1) Reverse the first sub-list of size k. While reversing keep track of the next node and previous node. 
Let the pointer to the next node be next and pointer to the previous node be prev. 
2) head->next = reverse(next, k) // Recursively call for rest of the list and link the two sub-lists 
3) return prev /// prev becomes the new head of the list (see the diagrams of iterative method of this post) 

     */