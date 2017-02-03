using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_NonRepeated_Character
{
    class Program
    {
        static void Main(string[] args)
        {            
            string s = "geeksforgeeks";
            char c = firstNonRepeatedCharacter(s);
            Console.WriteLine("The first non repeated character is :  " + c);
        }

        static char firstNonRepeatedCharacter(string str)
        {
            Dictionary<char, int> characterhashtable =
                         new Dictionary<char, int>();
            int i, length;
            char c = new char();
            length = str.Length;  // Scan string and build hash table
            for (i = 0; i < length; i++)
            {
                c = str[i];
                if (characterhashtable.ContainsKey(c))
                {
                    // increment count corresponding to c
                    characterhashtable[c] = characterhashtable[c] + 1;
                }
                else
                {
                    characterhashtable[c] = 1;
                }
            }
            // Search characterhashtable in in order of string str

            for (i = 0; i < length; i++)
            {
                c = str[i];
                if (characterhashtable[c] == 1)
                    break;
                    //return c;
            }
            return c;
        }
    }
}

//http://javahungry.blogspot.com/2013/12/first-non-repeated-character-in-string-java-program-code-example.html

//http://www.geeksforgeeks.org/find-first-non-repeating-character-stream-characters/
//http://www.geeksforgeeks.org/given-a-string-find-its-first-non-repeating-character/