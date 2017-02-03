﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_TwoNos_LinkedLists_Recursion_NoModification
{
    class Program
    {
        static Node head1, head2, head3;
        static Node curr = null;
        static int carry = 0;
        static int sum = 0;

        static void Main(string[] args)
        {
            head1 = new Node(7);
            head1.next = new Node(8);
            head1.next.next = new Node(9);
            head1.next.next.next = new Node(9);
            head1.next.next.next.next = new Node(8);
            head1.next.next.next.next.next = new Node(7);
            head1.next.next.next.next.next.next = new Node(9);

            head2 = new Node(7);
            head2.next = new Node(4);
            head2.next.next = new Node(5);
            head2.next.next.next = new Node(8);
            head2.next.next.next.next = new Node(3);

            int size1 = getSize(head1);
            int size2 = getSize(head2);

            Console.Write("List-1 : ");
            printList(head1);
            Console.Write("\nList-2 :     ");
            printList(head2);
            Console.Write("\n-------------------------");
            Console.Write("\nSum    : ");
            addTwoLists(head1, head2, size1, size2);
            printList(head3);
        }

        static void addTwoLists(Node node1, Node node2, int size1, int size2)
        {
            if (node1.next != null && node2.next != null & (size1 == size2))
                addTwoLists(node1.next, node2.next, size1 - 1, size2 - 1);
            else if (node1.next != null && (size1 > size2))
                addTwoLists(node1.next, node2, size1 - 1, size2);
            else if (node2.next != null && (size2 > size1))
                addTwoLists(node1, node2.next, size1, size2 - 1);
            addTwoNodes(node1, node2, size1, size2);
        }

        static void addTwoNodes(Node node1, Node node2, int size1, int size2)
        {
            int temp = carry;
            sum = carry + (node1 != null ? (size1 >= size2 ? node1.data : 0) : 0) +
                            (node2 != null ? (size2 >= size1 ? node2.data : 0) : 0);

            carry = (sum >= 10) ? 1 : 0;
            sum = sum % 10;

            if (temp == 0)
            {
                Node newNode = new Node(sum);
                head3 = newNode;
                head3.next = curr;
                curr = head3;
            }
            else
            {
                head3.data = sum;
                curr = head3;
            }
            if (carry > 0)
            {
                Node newNode = new Node(carry);
                head3 = newNode;
                head3.next = curr;
                curr = head3;
            }
        }

        static int getSize(Node node)
        {
            int size = 0;
            while (node != null)
            {
                size++;
                node = node.next;
            }
            return size;
        }

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

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
}
