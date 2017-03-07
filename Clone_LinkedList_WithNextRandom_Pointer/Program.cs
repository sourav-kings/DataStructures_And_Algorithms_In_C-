using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_LinkedList_WithNextRandom_Pointer
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(2);
            Node<int> node3 = new Node<int>(3);
            Node<int> node4 = new Node<int>(4);

            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = null;

            node1.arbitrary = node3;
            node2.arbitrary = node4;
            node3.arbitrary = node1;
            node4.arbitrary = node2;

            Node<int> head = node1;
            printList(head);
            head = cloneList(node1);
            Console.WriteLine("\n---- Cloned Linked List ----");
            printList(head);
        }
        public static Node<int> cloneList(Node<int> root)
        {
            Node<int> head = root;
            while (head != null)
            {
                head.next = new Node<int>(head.data, head.next);
                head = head.next.next;
            }
            head = root;
            while (head != null)
            {
                head.next.arbitrary = head.arbitrary.next;
                head = head.next.next;
            }

            Node<int> copy = root.next;
            Node<int> copyTemp = copy;
            head = root;
            while (head != null)
            {
                head.next = head.next.next;
                if (copyTemp.next != null)
                    copyTemp.next = copyTemp.next.next;
                head = head.next;
                copyTemp = copyTemp.next;
            }
            return copy;
        }

        public static void printList(Node<int> root)
        {
            Console.Write("\n");
            Node<int> head = root;
            while (head != null)
            {
               Console.Write(head);
                head = head.next;
                if (head != null)
                {
                    Console.Write("-->");
                }
            }
        }

    }

    class Node<T>
    {
        public T data;
        public Node<T> arbitrary, next;

        public Node(T data)
        {
            this.data = data;
            this.arbitrary = this.next = null;
        }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public override string ToString()
        {
            return "[prev=" + getNullOrValue(this.arbitrary) + "][data="
                    + getNullOrValue(this) + "][next="
                    + getNullOrValue(this.next) + "]";
        }

        private string getNullOrValue(Node<T> node)
        {
            string abc;
            if (node != null && node.data != null)
                abc = node.data.ToString();
            else
                abc = "null";

                    return abc.ToString();
        }
    }


}

//http://code.geeksforgeeks.org/j5is5q

//http://www.geeksforgeeks.org/a-linked-list-with-next-and-arbit-pointer/
//Average Difficulty : 3.7/5.0
//Based on 101 vote(s)



//http://www.geeksforgeeks.org/clone-linked-list-next-arbit-pointer-set-2/

//Average Difficulty : 3.5/5.0
//Based on 64 vote(s)


// figure out how to do in HASHMAP