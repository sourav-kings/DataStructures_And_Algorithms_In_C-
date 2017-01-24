using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_LinkedList
{
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            head = new Node(85);
            head.next = new Node(15);
            head.next.next = new Node(4);
            head.next.next.next = new Node(20);

            Console.WriteLine("Given Linked list");
            printList(head);
            head = reverse(head);
            Console.WriteLine("");
            Console.WriteLine("Reversed linked list ");
            printList(head);
        }

        /* Function to reverse the linked list */
        static public Node reverse(Node node)
        {
            Node prev = null;
            Node current = node;
            Node next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            node = prev;
            return node;
        }

        // prints content of double linked list
        static public void printList(Node node)
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


//http://www.geeksforgeeks.org/write-a-function-to-reverse-the-nodes-of-a-linked-list/