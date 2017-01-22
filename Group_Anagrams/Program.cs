using System;
using System.Collections.Generic;

namespace Group_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordArr = //{ "eat", "tea", "tan", "ate", "nat", "bat" };
            { "cat", "dog", "tac", "god", "act", "gdo" };

            groupAnagrams(wordArr);

            groupAnagrams2(wordArr);
        }

        public static void groupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                Console.WriteLine("No input provided.. !");
                return;
            }
            
            
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            
            foreach (string s in strs)
            {
                char[] ca = s.ToCharArray();
                Array.Sort(ca);

                string keyStr = new string(ca);

                if (!map.ContainsKey(keyStr))
                    map[keyStr] = new List<string>();

                map[keyStr].Add(s);
            }
            PrintResult(map);
        }



        public static void groupAnagrams2(string[] args)
        {
            Dictionary<string, List<string>> matchMap = new Dictionary<string, List<string>>();

            foreach (string word in args)
            {
                String key = anagramKey(word);

                if (!matchMap.ContainsKey(key))
                    matchMap[key] = new List<string>();
                
                matchMap[key].Add(word);
            }

            PrintResult(matchMap);
        }

        static string anagramKey(string word)
        {
            word = word.ToLower();

            char[] chars = word.ToCharArray();

            Array.Sort(chars);

            return new string(chars);
        }

        static void PrintResult(Dictionary<string, List<string>> result)
        {
            int i = 1;
            foreach(var item in result)
            {
                Console.WriteLine("Set " + i + ":- ");
                item.Value.ForEach(Console.WriteLine);
                Console.WriteLine();
                i++;
            }
        }

    }
}

//https://discuss.leetcode.com/topic/24494/share-my-short-java-solution/12

//http://www.programcreek.com/2014/04/leetcode-anagrams-java/