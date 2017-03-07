using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Of_Postfix_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            string exp = "231*+9-";
            Console.WriteLine("Value of " + exp + " is " + evaluatePostfix(exp));
        }

        // The main function that returns value of a given postfix expression
        static int evaluatePostfix(string exp)
        {
            // Create a stack of capacity equal to expression size
            Stack<int> stack = new Stack<int>(exp.Length);
            int i;

            // See if stack was created successfully
            if (stack == null) return -1;

            // Scan all characters one by one
            for (i = 0; i < exp.Length; ++i)
            {
                // If the scanned character is an operand (number here),
                // push it to the stack.
                if (char.IsDigit(exp[i]))
                    stack.Push(exp[i] - '0');
                //push(stack, exp[i] - '0');

                //  If the scanned character is an operator, pop two
                // elements from stack apply the operator
                else
                {
                    int val1 = stack.Pop();
                    int val2 = stack.Pop();
                    switch (exp[i])
                    {
                        case '+': stack.Push((val2 + val1)); break;
                        case '-': stack.Push((val2 - val1)); break;
                        case '*': stack.Push((val2 * val1)); break;
                        case '/': stack.Push((val2 / val1)); break;
                    }
                }
            }
            return stack.Pop();
        }
    }
}


//http://quiz.geeksforgeeks.org/stack-set-4-evaluation-postfix-expression/