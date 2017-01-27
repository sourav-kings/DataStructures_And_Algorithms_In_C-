using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_MergePoint_Of_Two_LinkedLists
{
    class Program
    {
        static Node head1, head2;
        static void Main(string[] args)
        {
            // creating first list
            head1 = new Node(1);
            head1.next = new Node(2);
            head1.next.next = new Node(3);
            head1.next.next.next = new Node(4);
            head1.next.next.next.next = new Node(5);
            Console.Write("First List is ");
            printList(head1);

            // creating seconnd list
            head2 = new Node(1);
            head2.next = new Node(4);
            head2.next.next = new Node(5);
            Console.Write("Second List is ");
            printList(head2);

            Console.WriteLine(getNode());
        }

        /*function to get the intersection point of two linked
            lists head1 and head2 */
        static int getNode()
        {
            int c1 = getCount(head1);
            int c2 = getCount(head2);
            int d;

            if (c1 > c2)
            {
                d = c1 - c2;
                return _getIntesectionNode(d, head1, head2);
            }
            else
            {
                d = c2 - c1;
                return _getIntesectionNode(d, head2, head1);
            }
        }

        /* function to get the intersection point of two linked
         lists head1 and head2 where head1 has d more nodes than
         head2 */
        static int _getIntesectionNode(int d, Node node1, Node node2)
        {
            int i;
            Node current1 = node1;
            Node current2 = node2;
            for (i = 0; i < d; i++)
            {
                if (current1 == null)
                {
                    return -1;
                }
                current1 = current1.next;
            }
            while (current1 != null && current2 != null)
            {
                if (current1.data == current2.data)
                {
                    return current1.data;
                }
                current1 = current1.next;
                current2 = current2.next;
            }

            return -1;
        }

        /*Takes head pointer of the linked list and
        returns the count of nodes in the list */
        static int getCount(Node node)
        {
            Node current = node;
            int count = 0;

            while (current != null)
            {
                count++;
                current = current.next;
            }

            return count;
        }

        static void printList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.next;
            }
            Console.WriteLine("");
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
//http://www.geeksforgeeks.org/write-a-function-to-get-the-intersection-point-of-two-linked-lists/