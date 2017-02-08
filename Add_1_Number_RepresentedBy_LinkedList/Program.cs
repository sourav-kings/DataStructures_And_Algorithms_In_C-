using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_1_ToANumber_RepresentedAs_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(1);
            head.next = new Node(9);
            head.next.next = new Node(9);
            head.next.next.next = new Node(9);

            Console.WriteLine("List is ");
            printList(head);

            head = addOne(head);

            Console.WriteLine("\nResultant list is ");
            printList(head);
        }

        // Function to reverse the linked list 
        static Node reverse(Node head)
        {
            Node prev = null;
            Node current = head;
            Node next;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        /* Adds one to a linked lists and return the head
           node of resultant list */
        static Node addOneUtil(Node head)
        {
            // res is head node of the resultant list
            Node res = head;
            Node temp = null, prev = null;

            int carry = 1, sum;

            while (head != null) //while both lists exist
            {
                // Calculate value of next digit in resultant list.
                // The next digit is sum of following things
                // (i) Carry
                // (ii) Next digit of head list (if there is a
                //     next digit)
                sum = carry + head.data;

                // update carry for next calulation
                carry = (sum >= 10) ? 1 : 0;

                // update sum if it is greater than 10
                sum = sum % 10;

                // Create a new node with sum as data
                head.data = sum;

                // Move head and second pointers to next nodes
                temp = head;
                head = head.next;
            }

            // if some carry is still there, add a new node to
            // result list.
            if (carry > 0)
                temp.next = new Node(carry);

            // return head of the resultant list
            return res;
        }

        // This function mainly uses addOneUtil().
        static Node addOne(Node head)
        {
            // Reverse linked list
            head = reverse(head);

            // Add one from left to right of reversed
            // list
            head = addOneUtil(head);

            // Reverse the modified list
            return reverse(head);
        }

        // A utility function to print a linked list
        static void printList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }

        }
    }

    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
        }
    }
}

//http://www.geeksforgeeks.org/add-1-number-represented-linked-list/