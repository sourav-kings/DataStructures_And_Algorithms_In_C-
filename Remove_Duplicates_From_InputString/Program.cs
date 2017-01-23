using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Duplicates_From_InputString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "geeksforgeeks";
            removeDuplicates(str); //O(n)
        }


        /* Function removes duplicate characters from the string
        This function work in-place */
        static void removeDuplicates(string str)
        {
            HashSet<char> lhs = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
                lhs.Add(str[i]);

            // print string after deleting duplicate elements
            foreach (var ch in lhs)
                Console.Write(ch + " ");
        }
        
    }
}
//http://www.geeksforgeeks.org/remove-all-duplicates-from-the-input-string/