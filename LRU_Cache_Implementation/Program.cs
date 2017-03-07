using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU_Cache_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let cache can hold 4 pages
            Queue q = createQueue(4);

            // Let 10 different pages can be requested (pages to be
            // referenced are numbered from 0 to 9
            Hash hash = createHash(10);

            // Let us refer pages 1, 2, 3, 1, 4, 5
            ReferencePage(q, hash, 1);
            ReferencePage(q, hash, 2);
            ReferencePage(q, hash, 3);
            ReferencePage(q, hash, 1);
            ReferencePage(q, hash, 4);
            ReferencePage(q, hash, 5);

            // Let us print cache frames after the above referenced pages
            Console.Write(q.front.pageNumber);
            Console.Write(q.front.next.pageNumber);
            Console.Write(q.front.next.next.pageNumber);
            Console.Write(q.front.next.next.next.pageNumber);

            Console.WriteLine();
        }


        // This function is called when a page with given 'pageNumber' is referenced
        // from cache (or memory). There are two cases:
        // 1. Frame is not there in memory, we bring it in memory and add to the front
        //    of queue
        // 2. Frame is there in memory, we move the frame to front of queue
        static void ReferencePage(Queue queue, Hash hash, uint pageNumber)
        {
            QNode reqPage = hash.array[pageNumber];

            // the page is not in cache, bring it
            if (reqPage == null)
                Enqueue(queue, hash, pageNumber);

            // page is there and not at front, change pointer
            else if (reqPage != queue.front)
            {
                // Unlink rquested page from its current location
                // in queue.
                reqPage.prev.next = reqPage.next;
                if (reqPage.next != null)
                    reqPage.next.prev = reqPage.prev;

                // If the requested page is rear, then change rear
                // as this node will be moved to front
                if (reqPage == queue.rear)
                {
                    queue.rear = reqPage.prev;
                    queue.rear.next = null;
                }

                // Put the requested page before current front
                reqPage.next = queue.front;
                reqPage.prev = null;

                // Change prev of current front
                reqPage.next.prev = reqPage;

                // Change front to the requested page
                queue.front = reqPage;
            }
        }

        // A utility function to create a new Queue Node. The queue Node
        // will store the given 'pageNumber'
        static QNode newQNode(uint pageNumber)
        {
            // Allocate memory and assign 'pageNumber'
            QNode temp = new QNode();
            temp.pageNumber = pageNumber;

            // Initialize prev and next as null
            temp.prev = temp.next = null;

            return temp;
        }

        // A utility function to create an empty Queue.
        // The queue can have at most 'numberOfFrames' nodes
        static Queue createQueue(uint numberOfFrames)
        {
            Queue queue = new Queue();

            // The queue is empty
            queue.count = 0;
            queue.front = queue.rear = null;

            // Number of frames that can be stored in memory
            queue.numberOfFrames = numberOfFrames;

            return queue;
        }

        // A utility function to create an empty Hash of given capacity
        static Hash createHash(int capacity)
        {
            // Allocate memory for hash
            Hash hash = new Hash();
            hash.capacity = capacity;

            // Create an array of pointers for refering queue nodes
            hash.array = new QNode[hash.capacity];

            // Initialize all hash entries as empty
            int i;
            for (i = 0; i < hash.capacity; ++i)
                hash.array[i] = null;

            return hash;
        }

        // A function to check if there is slot available in memory
        static bool AreAllFramesFull(Queue queue)
        {
            return queue.count == queue.numberOfFrames;
        }

        // A utility function to check if queue is empty
        static bool isQueueEmpty(Queue queue)
        {
            return queue.rear == null;
        }

        // A utility function to delete a frame from queue
        static void deQueue(Queue queue)
        {
            if (isQueueEmpty(queue))
                return;

            // If this is the only node in list, then change front
            if (queue.front == queue.rear)
                queue.front = null;

            // Change rear and remove the previous rear
            QNode temp = queue.rear;
            queue.rear = queue.rear.prev;

            if (queue.rear != null)
                queue.rear.next = null;

            //free(temp);

            // decrement the number of full frames by 1
            queue.count--;
        }

        // A function to add a page with given 'pageNumber' to both queue
        // and hash
        static void Enqueue(Queue queue, Hash hash, uint pageNumber)
        {
            // If all frames are full, remove the page at the rear
            if (AreAllFramesFull(queue))
            {
                // remove page from hash
                hash.array[queue.rear.pageNumber] = null;
                deQueue(queue);
            }

            // Create a new node with given page number,
            // And add the new node to the front of queue
            QNode temp = newQNode(pageNumber);
            temp.next = queue.front;

            // If queue is empty, change both front and rear pointers
            if (isQueueEmpty(queue))
                queue.rear = queue.front = temp;
            else  // Else change the front
            {
                queue.front.prev = temp;
                queue.front = temp;
            }

            // Add page entry to hash also
            hash.array[pageNumber] = temp;

            // increment number of full frames
            queue.count++;
        }
    }

    class QNode
    {
        public QNode prev, next;
        public uint pageNumber;  // the page number stored in this QNode
    }

    // A Queue (A FIFO collection of Queue Nodes)
    class  Queue
    {
        public uint count;  // Number of filled frames
        public uint numberOfFrames; // total number of frames
        public QNode front, rear;
    }

    // A hash (Collection of pointers to Queue Nodes)
    class Hash
    {
        public int capacity; // how many pages can be there
        public QNode[] array; // an array of queue nodes
    }
}
///http://www.geeksforgeeks.org/implement-lru-cache/
///
//Average Difficulty : 3.7/5.0
//Based on 84 vote(s)