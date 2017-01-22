using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Between_TwoNodes_BinaryTree
{
    class Program
    {
        //Root of the Binary Tree
        static Node root;

        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            root.right.left.right = new Node(8);

            findDist(4, 5);
            findDist(4, 6);
            findDist(3, 4);
            findDist(2, 4);
            findDist(8, 5);
        }

        static void findDist(int n1, int n2)
        {
            FlagVisited visit = new FlagVisited();
            int result = findDist(root, n1, n2, 0, visit);
            Console.WriteLine("Distance for " + n1 + ", " + n2 + " is : " + result);
        }


        static int findDist(Node node, int n1, int n2, int dist, FlagVisited flag)
        {
            // Base case
            if (node == null)
                return 0;

            FlagVisited leftF = new FlagVisited();
            FlagVisited rightF = new FlagVisited();

            // Look for keys in left and right subtrees
            int leftDist = findDist(node.left, n1, n2, dist, leftF);
            int rightDist = findDist(node.right, n1, n2, dist, rightF);

            if (leftDist >= 1 && rightDist >= 1)
            {
                flag.visited = true;
                return leftDist + rightDist;
            }

            if ((node.data == n1 || node.data == n2) && (leftDist >= 1 || rightDist >= 1))
            {
                flag.visited = true;
                return leftDist + rightDist;
            }
            if (node.data == n1 || node.data == n2)
            {
                dist++;
                return leftDist + rightDist + dist;
            }

            if (leftF.visited || rightF.visited)
            {
                return leftDist + rightDist;
            }

            if (leftDist >= 1 || rightDist >= 1)
            {
                dist++;
                return leftDist + rightDist + dist;
            }


            return leftDist + rightDist;

        }
    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }

    public class FlagVisited
    {
        public bool visited = false;
    }
}


//http://www.geeksforgeeks.org/find-distance-two-given-nodes/
//http://code.geeksforgeeks.org/leM4IG