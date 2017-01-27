using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced_Parentheses_In_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BalancedParenthensies("{(a,b)}"));
            Console.WriteLine(BalancedParenthensies("{(a},b)"));
            Console.WriteLine(BalancedParenthensies("{)(a,b}"));
            Console.WriteLine(BalancedParenthensies("{[(a,b)(a)]}"));
        }

        public static bool BalancedParenthensies(String s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '[' || c == '(' || c == '{')
                {

                    stack.Push(c);

                }
                else if (c == ']')
                {
                    if (stack.Count == 0) return false;
                    if (stack.Pop() != '[') return false;

                }
                else if (c == ')')
                {
                    if (stack.Count == 0) return false;
                    if (stack.Pop() != '(') return false;

                }
                else if (c == '}')
                {
                    if (stack.Count == 0) return false;
                    if (stack.Pop() != '{') return false;
                }

            }
            return stack.Count == 0;
        }
    }
}
