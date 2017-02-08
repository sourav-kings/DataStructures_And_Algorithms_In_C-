using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_Queue_Using_Stacks
{
    class Program
    {
        static private int front;
        static Stack<int> s1 = new Stack<int>();
        static Stack<int> s2 = new Stack<int>();
        static void Main(string[] args)
        {
            empty();
            enQueue(1);
            empty();
            enQueue(2);
            enQueue(3);
            peek();
            /* Dequeue items */
            deQueue();
            deQueue();
            peek();
            deQueue();
            empty();
        }

        static void enQueue(int x)
        {
            if (!s1.Any())
                front = x;

            Console.WriteLine("Enqued item: " + x);
            s1.Push(x);

        }

        static void deQueue()
        {
            if (!s2.Any())
            {
                while (s1.Any())
                    s2.Push(s1.Pop());
            }
            //s2.Pop();

            Console.WriteLine("Dequed item: " + s2.Pop());
            //s1.Pop();
            //if (s1.Any())
            //    front = s1.Peek();
        }

        // Return whether the queue is empty.
        static void empty()
        {
            Console.WriteLine("Queue empty status: " + !s1.Any());
            //return !s1.Any();
        }

        // Get the front element.
        static void peek()
        {
            if (!s2.Any())
            {
                while (s1.Any())
                    s2.Push(s1.Pop());
            }

            Console.WriteLine("Peeked item: " + s2.Peek());
            //return front;
        }
    }
}


//https://leetcode.com/problems/implement-queue-using-stacks/?tab=Solutions

//http://www.geeksforgeeks.org/queue-using-stacks/

//https://leetcode.com/articles/implement-queue-using-stacks/