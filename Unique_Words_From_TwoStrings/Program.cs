using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unique_Words_From_TwoStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = "I am living in beautiful india";
            string secondString = "india is a beautiful country";

            HashSet<string> h1 = new HashSet<string>(), h2 = new HashSet<string>();
            h1 = GetAllWords(firstString);
            h2 = GetAllWords(secondString);


            StringBuilder commonSB = new StringBuilder();
            StringBuilder uniqueSB = new StringBuilder();

            foreach (string i in h1)
            {
                if (!h2.Contains(i))
                {
                    uniqueSB.Append(i + " ");
                }
                else
                {
                    commonSB.Append(i + " ");
                };
            }

            foreach (string i in h2)
            {
                if (!h1.Contains(i))
                {
                    uniqueSB.Append(i + " ");
                };
            }

            Console.WriteLine("String 1:" + firstString);
            Console.WriteLine("String 2:" + secondString);
            Console.WriteLine("Common:" + commonSB);
            Console.WriteLine("Unique:" + uniqueSB);
        }

        static HashSet<string> GetAllWords(string firstString)
        {
            HashSet<string> h1 = new HashSet<string>();
            int currentIndex = 0, previousIndex = 0, wordLength = 0;

            for (int i = 0; i < firstString.Length; i++)
            {
                if (firstString[i] == ' ' || i == firstString.Length - 1)//if a space comes or end of the string comes
                {
                    if (h1.Count == 0)
                    {
                        h1.Add(firstString.Substring(0, i));
                        currentIndex = i;
                    }
                    else
                    {
                        previousIndex = currentIndex;
                        currentIndex = i;
                        wordLength = (i != firstString.Length - 1) ? (currentIndex - previousIndex - 1) : (currentIndex - previousIndex);
                        h1.Add(firstString.Substring(previousIndex + 1, wordLength));
                    }
                }
            }

            return h1;
        }
    }
}
