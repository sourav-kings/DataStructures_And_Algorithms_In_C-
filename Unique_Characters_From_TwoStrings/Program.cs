using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unique_Characters_From_TwoStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            String firstString = "I am living in india";
            String secondString = "india is a beautiful country";

            HashSet<char> h1 = new HashSet<char>(), h2 = new HashSet<char>();
            for (int i = 0; i < firstString.Length; i++)
            {
                h1.Add(firstString[i]);
            }
            for (int i = 0; i < secondString.Length; i++)
            {
                h2.Add(secondString[i]);
            }

            StringBuilder commonSB = new StringBuilder();
            StringBuilder uniqueSB = new StringBuilder();

            foreach (char i in h1)
            {
                if (!h2.Contains(i))
                {
                    uniqueSB.Append(i);
                }
                else
                {
                    commonSB.Append(i);
                };
            }

            foreach (char i in h2)
            {
                if (!h1.Contains(i))
                {
                    uniqueSB.Append(i);
                };
            }

            Console.WriteLine("Common:" + commonSB.ToString().Replace(" ", ""));
            Console.WriteLine("Unique:" + uniqueSB.ToString().Replace(" ", ""));
        }
    }
}
