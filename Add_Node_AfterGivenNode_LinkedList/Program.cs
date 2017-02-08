using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Node_AfterGivenNode_LinkedList
{
    class Program
    {
        static Node head;  // head of list
        static void Main(string[] args)
        {
          // Insert 6.  So linked list becomes 6->NULL
          append(head, 6);

          // Insert 7 at the beginning. So linked list becomes 7->6->NULL
          push(7);

          // Insert 1 at the beginning. So linked list becomes 1->7->6->NULL
          push(1);

          // Insert 4 at the end. So linked list becomes 1->7->6->4->NULL
          append(head, 4);

          // Insert 8, after 7. So linked list becomes 1->7->8->6->4->NULL
          insertAfter(head.next, 8);


          Console.WriteLine("\n Created Linked list is: ");
          printList(head);
        }

        /* This function is in LinkedList class.
           Inserts a new node after the given prev_node. This method is 
           defined inside LinkedList class shown above */
        static void insertAfter(Node prev_node, int new_data)
        {
            /* 1. Check if the given Node is null */
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node cannot be null");
                return;
            }

            /* 2. Allocate the Node &
               3. Put in the data*/
            Node new_node = new Node(new_data);

            /* 4. Make next of new Node as next of prev_node */
            new_node.next = prev_node.next;

            /* 5. make next of prev_node as new_node */
            prev_node.next = new_node;
        }

        /* This function is in LinkedList class. Inserts a
           new Node at front of the list. This method is 
           defined inside LinkedList class shown above */
        static void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                      Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }


        /* Given a reference (pointer to pointer) to the head
        of a list and an int, appends a new node at the end  */
        static void append(Node head_ref, int new_data)
        {
            /* 1. allocate node and 2. put in the data */
            Node new_node = new Node(new_data);

            Node last = head_ref;  /* used in step 5*/

            /* 3. This new node is going to be the last node, so make next of
                  it as NULL*/
            new_node.next = null;
 
            /* 4. If the Linked List is empty, then make the new node as head */
            if (head_ref == null)
            {
               head_ref = new_node;
               return;
            }
 
            /* 5. Else traverse till the last node */
            while (last.next != null)
                last = last.next;
 
            /* 6. Change the next of last node */
            last.next = new_node;
            return;
        }
        // This function prints contents of linked list starting from head
        static void printList(Node node)
        {
          while (node != null)
          {
             Console.Write(node.data + " -- ");
                node = node.next;
          }
        }
    }

    // A linked list node
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
