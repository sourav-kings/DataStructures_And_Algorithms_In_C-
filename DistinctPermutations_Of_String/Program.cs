using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctPermutations_Of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "AAC";
            String s1 = "ABC";
            String s2 = "ABCD";
            Console.WriteLine("\nPermutations for " + s + " are:");
            displayValues(permutationFinder(s));

            Console.WriteLine("\nPermutations for " + s1 + " are:");
            displayValues(permutationFinder(s1));

            Console.WriteLine("\nPermutations for " + s2 + " are:");
            displayValues(permutationFinder(s2));
        }


        public static HashSet<string> permutationFinder(string str)
        {
            HashSet<string> perm = new HashSet<string>();
            //Handling error scenarios
            if (str == null)
            {
                return null;
            }
            else if (str.Length == 0)
            {
                perm.Add("");
                return perm;
            }
            char initial = str[0]; // first character
            string rem = str.Substring(1); // Full string without first character
            HashSet<string> words = permutationFinder(rem);
            foreach (string strNew in words)
            {
                for (int i = 0; i <= strNew.Length; i++)
                {
                    perm.Add(charInsert(strNew, initial, i));
                }
            }
            return perm;
        }

        public static string charInsert(string str, char c, int j)
        {
            string begin = str.Substring(0, j);
            string end = str.Substring(j);
            return begin + c + end;
        }


        public static void displayValues(HashSet<string> hash)
        {
            foreach (var val in hash)
                Console.Write(val + " ");

            Console.WriteLine();
        }
        
    }
}

//http://www.journaldev.com/526/java-program-to-find-all-permutations-of-a-string

//http://www.geeksforgeeks.org/print-all-permutations-of-a-string-with-duplicates-allowed-in-input-string/

//