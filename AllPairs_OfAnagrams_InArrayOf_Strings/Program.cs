using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPairs_OfAnagrams_InArrayOf_Strings
{
    class Program
    {
        const int NO_OF_CHARS = 256;
        static void Main(string[] args)
        {
            //Dictionary<int, List<string>> hm = new Dictionary<int, List<string>>();

            //groupAnagrams(args, hm);
            //Console.WriteLine(hm);

            string[] arr =  {"geeksquiz", "geeksforgeeks", "abcd",
                 "forgeeksgeeks", "zuiqkeegs"};

            Dictionary<string, List<string>> matchMap = new Dictionary<string, List<string>>();
            foreach (string word in arr)
            {
                String key = anagramKey(word);
                if (!matchMap.ContainsKey(key))
                {
                    matchMap[key] = new List<string>();
                }
                matchMap[key].Add(word);
            }

            display(matchMap);
            //Console.WriteLine(matchMap.GetEnumerator().Current.Value.GetEnumerator().Current.ToString());
        }

        private static string anagramKey(string word)
        {
            word = word.ToLower();
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            return new String(chars);
        }

        static void display(Dictionary<string, List<string>> matchMap)
        {
            foreach(var dictionaryItem in matchMap)
            {
                if(dictionaryItem.Value.Count > 1)
                {
                    foreach (var listItem in dictionaryItem.Value)
                    {
                        Console.Write(listItem + "   ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}


//http://quiz.geeksforgeeks.org/print-pairs-anagrams-given-array-strings/