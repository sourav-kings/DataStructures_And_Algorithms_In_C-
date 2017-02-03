using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abcabcbb";
            Console.WriteLine(lengthOfLongestSubstring(input));
        }

        static int lengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            HashSet<char> set = new HashSet<char>();

            int max = 0;

            int i = 0;
            int start = 0;
            while (i < s.Length)
            {
                char c = s[i];
                if (!set.Contains(c))
                {
                    set.Add(c);
                }
                else
                {
                    max = Math.Max(max, set.Count());

                    while (start < i && s[start] != c)
                    {
                        set.Remove(s[start]);
                        start++;
                    }
                    start++;
                }

                i++;
            }

            max = Math.Max(max, set.Count());

            return max;
        }
    }
}

//http://www.programcreek.com/2013/02/leetcode-longest-substring-without-repeating-characters-java/