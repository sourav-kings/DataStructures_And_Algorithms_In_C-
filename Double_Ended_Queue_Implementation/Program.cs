using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Ended_Queue_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var deque = new DeQueue();
            deque.Inject(0);

            deque.Push(10);
            deque.Push(20);
            deque.Push(30);

            deque.PrintQueue(false);//Deque (Using NEXT): 30->20->10->0->NULL
            deque.Pop();

            deque.PrintQueue(false);

            deque.Inject(40);
            deque.Inject(50);

            deque.PrintQueue(false);

            deque.Eject();

            deque.PrintQueue(false);
        }
    }

    public class QNode
    {
        public int Data { get; set; }
        public QNode Next { get; set; }
        public QNode Prev { get; set; }

        public QNode(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
    }

    public class DeQueue
    {
        private QNode Head = null;
        private QNode Tail = null;

        public void Push(int data)
        {
            Console.WriteLine("Pushing - {0} to front.", data);
            var newNode = new QNode(data);

            if (null == Head)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public QNode Pop()
        {
            if (null == Head)
            {
                Console.WriteLine("Queue is Empty!");
                return null;
            }
            Console.WriteLine("Popping - {0} from Front.", Head.Data);

            var tempHead = Head;
            Head = Head.Next;
            Head.Prev = null;

            if (null == Head)
            {
                Tail = null;
            }
            return tempHead;
        }

        public void Inject(int data)
        {
            Console.WriteLine("Injecting - {0} in the end.", data);
            var newNode = new QNode(data);
            if (null == Head)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Prev = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public QNode Eject()
        {
            var tempTail = Tail;
            if (null == tempTail)
            {
                Console.WriteLine("Queue Empty!");
                return null;
            }
            Console.WriteLine("Ejecting - {0} in the end.", this.Tail.Data);
            Tail = Tail.Prev;
            if (null == Tail)
            {
                Head = null;
            }
            else
            {
                Tail.Next = null;
            }
            return tempTail;
        }

        public QNode Front()
        {
            return Head;
        }

        public QNode Last()
        {
            return Tail;
        }

        public void PrintQueue(bool printUsingPrev)
        {
            QNode tempNode = null;
            if (!printUsingPrev)
                tempNode = Head;
            else
                tempNode = Tail;

            var sb = new StringBuilder();
            while (null != tempNode)
            {
                //Console.WriteLine(tempHead.Data);
                sb.Append(tempNode.Data);
                sb.Append("->");
                if (!printUsingPrev)
                    tempNode = tempNode.Next;
                else
                    tempNode = tempNode.Prev;
            }
            sb.Append("NULL");
            if (!printUsingPrev)
                Console.WriteLine("Deque (Using NEXT): {0}", sb.ToString());
            else
                Console.WriteLine("Deque (Using PREV): {0}", sb.ToString());

            if (null != Head)
                Console.WriteLine("Front is @ {0}", null != Head ? Head.Data.ToString() : "NULL");
            if (null != Tail)
                Console.WriteLine("Tail is @ {0}", null != Tail ? Tail.Data.ToString() : "NULL");
        }
    }
}
