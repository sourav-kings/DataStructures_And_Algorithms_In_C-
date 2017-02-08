using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implement_CircularQueue_Using_Arrays
{
    class Program
    {
        const int SIZE = 5;
        static int[] cQueue = new int[SIZE]; static int front = -1, rear = -1;
        static void Main(string[] args)
        {
            enQueue(7);
            enQueue(11);
            enQueue(8);
            enQueue(2);
            enQueue(6); // queue becomes full
            display();
            enQueue(9); // Show throw overflow error
            deQueue(); // 7 is dequeued from index 0
            deQueue(); // 11 is dequeued from index 1
            display();
            enQueue(5); // 5 is inserted at index 0
            enQueue(3); // 3 is inserted at index 1
            display();
        }

        static void enQueue(int value)
        {
            if ((front == 0 && rear == SIZE - 1) || (front == rear + 1))
                Console.Write("\nCircular Queue is Full! Insertion not possible!!!\n");
            else
            {
                if (rear == SIZE - 1 && front != 0)
                    rear = -1;
                cQueue[++rear] = value;
                Console.Write("\nInsertion Success!!!\n");
                if (front == -1)
                    front = 0;
            }
        }
        static void deQueue()
        {
            if (front == -1 && rear == -1)
                Console.Write("\nCircular Queue is Empty! Deletion is not possible!!!\n");
            else
            {
                Console.WriteLine("\nDeleted element : " + cQueue[front++]);
                if (front == SIZE)
                    front = 0;
                if (front - 1 == rear)
                    front = rear = -1;
            }
        }
        static void display()
        {
            if (front == -1)
                Console.Write("\nCircular Queue is Empty!!!\n");
            else
            {
                int i = front;
                Console.Write("\nCircular Queue Elements are : \n");
                if (front <= rear)
                {
                    while (i <= rear)
                        Console.Write(cQueue[i++] + " \n");
                }
                else
                {
                    while (i <= SIZE - 1)
                        Console.Write(cQueue[i++] + " \n");
                    i = 0;
                    while (i <= rear)
                        Console.Write(cQueue[i++] + " \n");
                }
            }
        }
    }
}

//http://btechsmartclass.com/DS/U2_T10.html

//http://www.csegeek.com/csegeek/view/tutorials/algorithms/stacks_queues/circular_queue.php