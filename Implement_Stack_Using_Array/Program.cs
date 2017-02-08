using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_Stack_Using_Array
{
    class Program
    {
        const int SIZE = 10;
        static int[] stack = new int[SIZE]; static int top = -1;
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
            if (top == SIZE - 1)
               Console.WriteLine("\nStack is Full!!! Insertion is not possible!!!");
            else
            {
                top++;
                stack[top] = value;
               Console.WriteLine("\nInsertion success!!!");
            }
        }
        static void pop()
        {
            if (top == -1)
               Console.WriteLine("\nStack is Empty!!! Deletion is not possible!!!");
            else
            {
               Console.WriteLine("\nDeleted : " + stack[top]);
                top--;
            }
        }
        static void peek()
        {
            if (top == -1)
                Console.WriteLine("\nStack is Empty!!! Deletion is not possible!!!");
            else
            {
                Console.WriteLine("\n Peek :" + stack[top]);
            }
        }
        static void display()
        {
            if (top == -1)
               Console.WriteLine("\nStack is Empty!!!");
            else
            {
                int i;
               Console.WriteLine("\nStack elements are:\n");
                for (i = top; i >= 0; i--)
                   Console.WriteLine(stack[i] + "\n");
            }
        }
    }
}


//http://btechsmartclass.com/DS/U2_T2.html

//http://quiz.geeksforgeeks.org/stack-set-1/