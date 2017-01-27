using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestWindowInString_With_AllChars_Of_AnotherString
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = "this is a test string";
            string string2 = "tist";

            Console.WriteLine(minWindow(string1, string2));
            //Console.WriteLine(minWindow2(string1, string2)); 
        }

        static public string minWindow(string s, string t)
        {
            if (t.Length > s.Length)
                return "";
            string result = "";

            //character counter for t
            Dictionary<char, int> target = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                char c = t[i];
                if (target.ContainsKey(c))
                {
                    target[c] = target[c] + 1;
                }
                else
                {
                    target[c] = 1;
                }
            }

            // character counter for s
            Dictionary<char, int> map = new Dictionary<char, int>();
            int left = 0;
            int minLen = s.Length + 1;

            int count = 0; // the total of mapped characters

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (target.ContainsKey(c))
                {
                    if (map.ContainsKey(c))
                    {
                        if (map[c] < target[c])
                        {
                            count++;
                        }
                        map[c] = map[c] + 1;
                    }
                    else
                    {
                        map[c] = 1;
                        count++;
                    }
                }

                if (count == t.Length)
                {
                    char sc = s[left];
                    while (!map.ContainsKey(sc) || map[sc] > target[sc])
                    {
                        if (map.ContainsKey(sc) && map[sc] > target[sc])
                            map[sc] = map[sc] - 1;
                        left++;
                        sc = s[left];
                    }

                    if (i - left + 1 < minLen)
                    {
                        result = s.Substring(left, i + 1);
                        minLen = i - left + 1;
                    }
                    count--;//added by me
                }
            }

            return result;
        }

        static public string minWindow2(string s, string t)
        {
            int[] t_c = new int[128];
            int count = t.Length;
            if (s.Length < count) return "";
            for (int i = 0; i < count; i++) { t_c[t[i]]++; }
            int start = 0, end = 0;
            string res = "";
            bool isStart = false;//whether move start pointer or not
            while (end < s.Length)
            {
                if (!isStart)
                {
                    if (t_c[s[end]] > 0) count--;
                    t_c[s[end]]--;
                }
                if (count == 0)
                {
                    if (res == "" || end - start + 1 < res.Length)
                        res = s.Substring(start, end + 1);
                    if (res.Length == t.Length) return res;
                }
                if (t_c[s[start]] < 0 && count == 0)
                {
                    t_c[s[start]]++;
                    if (t_c[s[start]] > 0) count++;
                    start++;
                    isStart = true;
                }
                else
                {
                    isStart = false;
                    end++;
                }
            }
            return res;
        }
    }
}

//http://www.programcreek.com/2014/05/leetcode-minimum-window-substring-java/

//http://www.geeksforgeeks.org/find-the-smallest-window-in-a-string-containing-all-characters-of-another-string/
//http://articles.leetcode.com/finding-minimum-window-in-s-which

//https://discuss.leetcode.com/category/84/minimum-window-substring
//https://discuss.leetcode.com/topic/30941/here-is-a-10-line-template-that-can-solve-most-substring-problems
