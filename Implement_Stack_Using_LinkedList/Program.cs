using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_Stack_Using_LinkedList
{
    class Program
    {
        static Node top = null;
        static void Main(string[] args)
        {
            push(10);
            push(20);
            peek();
            push(30);
            display();
            pop();
            display();

        }

        static void push(int value)
        {
            Node newNode = new Node(); newNode.data = value;
            if (top == null)
                newNode.next = null;
            else
                newNode.next = top;
            top = newNode;
            Console.Write("\nInsertion is Success!!!\n");
        }
        static void pop()
        {
            if (top == null)
                Console.Write("\nStack is Empty!!!\n");
            else
            {
                Node temp = top;
                Console.WriteLine("\nDeleted element: " + temp.data);
                top = temp.next;
            }
        }
        static void peek()
        {
            if (top == null)
                Console.Write("\nStack is Empty!!!\n");
            else
            {
                Node temp = top;
                Console.Write("\n Peeked element: " + temp.data);
            }
        }
        static void display()
        {
            if (top == null)
                Console.Write("\nStack is Empty!!!\n");
            else
            {
                Node temp = top;
                while (temp.next != null)
                {

                    Console.Write(temp.data + "--.");
                    temp = temp.next;
                }
                Console.Write(temp.data + " --.NULL");
            }
        }
    }

    class Node
    {
        public int data;
        public Node next;
    }
}

//http://btechsmartclass.com/DS/U2_T3.html

//http://quiz.geeksforgeeks.org/stack-set-1/