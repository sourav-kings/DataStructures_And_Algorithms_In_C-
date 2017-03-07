using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Break_Problem
{
    class Program
    {

        static string[] dictionary = {"mobile","samsung","sam","sung","man","mango",
                           "icecream","and","go","i","like","ice","cream", "leet", "code"};

        static List<string> dictionaryList = new List<string> {"mobile","samsung","sam","sung","man","mango",
                           "icecream","and","go","i","like","ice","cream", "leet", "code"};

        static void Main(string[] args)
        {
            if (WordBreak3("samsungandmango"))
                Console.Write("Yes\n");
            else
                Console.Write("No\n");

            if (WordBreak3("samsungandmangok"))
                Console.Write("Yes\n");
            else
                Console.Write("No\n");


            if (WordBreak3("leetcode2"))
                Console.Write("Yes\n");
            else
                Console.Write("No\n");

            if (WordBreak3("leetcodeleetleet"))
                Console.Write("Yes\n");
            else
                Console.Write("No\n");
        }

        static bool WordBreak3(String s)
        {
            if (dictionary == null || s == null)
            {
                return false;
            }

            var count = s.Length;
            var dp = new bool[count + 1];

            dp[0] = true;

            for (var i = 1; i < dp.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    var word = s.Substring(j, i - j);
                    if (dictionary.Contains(word) && dp[j])
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[count];
        }

        static List<string> WordBreak4(string s)
        {
            var res = new List<string>();
            var solution = string.Empty;

            var dp = new List<string>[s.Length + 1];
            for (int i = 0; i < s.Length + 1; i++)
            {
                dp[i] = new List<string>();
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j != 0 && dp[j].Count == 0) continue;

                    var substr = s.Substring(j, i - j + 1);
                    if (dictionary.Contains(substr))
                    {
                        dp[i + 1].Add(substr);
                    }
                }
            }

            Helper(dp, s.Length, res, solution);

            return res;
        }

        static void Helper(List<string>[] dp, int index, List<string> res, string solution)
        {
            if (index == 0)
            {
                solution = solution.Remove(solution.Length - 1);
                res.Add(solution);
                return;
            }

            foreach (var list in dp[index])
            {
                solution = list + " " + solution;
                Helper(dp, index - list.Length, res, solution);
                solution = solution.Substring(list.Length + 1);
            }
        }

    }
}
//Average Difficulty : 3.6/5.0
//Based on 47 vote(s)
//https://miafish.wordpress.com/2015/01/20/leetcode-oj-c-word-break/

//http://www.geeksforgeeks.org/dynamic-programming-set-32-word-break-problem/
//http://www.geeksforgeeks.org/word-break-problem-using-backtracking/
//https://discuss.leetcode.com/category/147/word-break
//http://www.programcreek.com/2014/03/leetcode-word-break-ii-java/
//http://www.ideserve.co.in/learn/word-break-problem

//https://www.youtube.com/watch?v=WepWFGxiwRs&list=PLrmLmBdmIlpsHaNTPP_jHHDx_os9ItYXr&index=20
//https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/BreakMultipleWordsWithNoSpaceIntoSpace.java
