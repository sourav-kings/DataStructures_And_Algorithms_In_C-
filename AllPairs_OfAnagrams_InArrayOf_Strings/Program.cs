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




/*
 
The time complexity of the above solution is O(n2*m) where n is number of strings and m is maximum length of a string.

    Optimizations:
    We can optimize the above solution using following approaches.

    1) Using sorting: We can sort array of strings so that all anagrams come together. 
    Then print all anagrams by linearly traversing the sorted array. 
    The time complexity of this solution is O(mnLogn) (We would be doing O(nLogn) comparisons in sorting 
    and a comparison would take O(m) time)

    2) Using Hashing: We can build a hash function like XOR or sum of ASCII values of all characters for a string. 
    Using such a hash function, we can build a hash table. While building the hash table, 
    we can check if a value is already hashed. If yes, 
    we can call areAnagrams() to check if two strings are actually anagrams 
    (Note that xor or sum of ASCII values is not sufficient, see Kaushik Lele’s comment here)

*/

//http://quiz.geeksforgeeks.org/print-pairs-anagrams-given-array-strings/
// Average Difficulty : 2.6/5.0
//Based on 6 vote(s)