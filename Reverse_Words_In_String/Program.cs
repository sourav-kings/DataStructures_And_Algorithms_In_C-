using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reverse_Words_In_String
{
    class Program
    {
        static void Main(string[] args)
        {
            String a = "i love mom and dad";
            String[] s = Regex.Split(a, "\\s+");
            Stack<String> stc = new Stack<String>();
            for (int i = 0; i < s.Length; i++)
            {
                stc.Push(s[i]);
            }
            String ans = "";

            while (stc.Any())
            {
                ans = ans + stc.Pop();
                ans = ans + ' ';
            }
            Console.WriteLine(ans);
        }
    }
}