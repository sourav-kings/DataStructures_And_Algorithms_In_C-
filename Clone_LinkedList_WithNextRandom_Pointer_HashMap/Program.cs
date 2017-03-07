using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_LinkedList_WithNextRandom_Pointer_HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pushing data in the linked list.
            LinkedList list = new LinkedList(new Node(5));
            list.push(4);
            list.push(3);
            list.push(2);
            list.push(1);

            // Setting up random references.
            list.head.random = list.head.next.next;
            list.head.next.random =
                list.head.next.next.next;
            list.head.next.next.random =
                list.head.next.next.next.next;
            list.head.next.next.next.random =
                list.head.next.next.next.next.next;
            list.head.next.next.next.next.random =
                list.head.next;

            // Making a clone of the original linked list.
            LinkedList clone = list.clone();

            // Print the original and cloned linked list.
            Console.WriteLine("Original linked list");
            list.print();
            Console.WriteLine("\nCloned linked list");
            clone.print();
        }
    }

    // linked list class
    class LinkedList
    {
        public Node head;//Linked list head reference

        // Linked list constructor
        public LinkedList(Node head)
        {
            this.head = head;
        }

        // push method to put data always at the head
        // in the linked list.
        public void push(int data)
        {
            Node node = new Node(data);
            node.next = this.head;
            this.head = node;
        }

        // Method to print the list.
        public void print()
        {
            Node temp = head;
            while (temp != null)
            {
                Node random = temp.random;
                int randomData = (random != null) ? random.data : -1;
                Console.WriteLine("Data = " + temp.data +
                                   ", Random data = " + randomData);
                temp = temp.next;
            }
        }

        // Actual clone method which returns head
        // reference of cloned linked list.
        public LinkedList clone()
        {
            // Initialize two references, one with original
            // list's head.
            Node origCurr = this.head, cloneCurr = null;

            // Hash map which contains node to node mapping of
            // original and clone linked list.
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            // Traverse the original list and make a copy of that
            // in the clone linked list.
            while (origCurr != null)
            {
                cloneCurr = new Node(origCurr.data);
                map[origCurr] = cloneCurr;
                origCurr = origCurr.next;
            }

            // Adjusting the original list reference again.
            origCurr = this.head;

            // Traversal of original list again to adjust the next
            // and random references of clone list using hash map.
            while (origCurr != null)
            {
                cloneCurr = map[origCurr];
                cloneCurr.next = origCurr.next == null ? null : map[origCurr.next];
                cloneCurr.random = origCurr.random == null ? null :  map[origCurr.random];
                origCurr = origCurr.next;
            }

            //return the head reference of the clone list.
            return new LinkedList(map[this.head]);
        }
    }

    // Linked List Node class
    class Node
    {
        public int data;//Node data
        public Node next, random;//Next and random reference

        //Node constructor
        public Node(int data)
        {
            this.data = data;
            this.next = this.random = null;
        }
    }
}

/*
 http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/

    Time complexity : O(n)
Auxiliary space : O(n)


    Average Difficulty : 3.5/5.0
Based on 64 vote(s)
     
     */
