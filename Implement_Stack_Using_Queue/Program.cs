using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_Stack_Using_SingleQueue
{
    class Program
    {
        static Queue<int> q = new Queue<int>();
        static void Main(string[] args)
        {
            push(10);
            push(20);
            Console.WriteLine(top());
            pop();
            push(30);
            pop();
            Console.WriteLine(top());

        }

        // Push operation
        static void push(int val)
        {
            int s=0;
            //  Get previous size of queue
            s = q.Count();
            //if (!q.Any())
            //     s = q.Count();

            // Push current element
            q.Enqueue(val);

            // Pop (or Dequeue) all previous
            // elements and put them after current
            // element
            for (int i = 0; i < s; i++)
            {
                // this will add front element into
                // rear of queue
                q.Enqueue(q.First());

                // this will delete front element
                q.Dequeue();
            }
        }

        // Removes the top element
        static void pop()
        {
            if (!q.Any())
                Console.WriteLine("No elements");
            else
                q.Dequeue();
        }

        // Returns top of stack
        static int top()
        {
            return (!q.Any()) ? -1 : q.First();
        }

        // Returns true if Stack is empty else false
        static bool empty()
        {
            return (!q.Any());
        }

    }
}
