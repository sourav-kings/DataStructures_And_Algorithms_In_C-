using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompression_Counting_RepeatedCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            compress("aabcccccaaa");
            compress("aaaaa");
            compress("aaaabbb");
            compress("aaabbbccc");
            compress("abc");
            compress("a");
            compress("");

            Console.WriteLine("\n  \n");


            compress_simpler("aabcccccaaa");
            compress_simpler("aaaaa");
            compress_simpler("aaaabbb");
            compress_simpler("aaabbbccc");
            compress_simpler("abc");
            compress_simpler("a");
            compress_simpler("");
        }

        static string compress(string str)
        {
            int count = 1;
            StringBuilder builder = new StringBuilder();

            for (int i = 1; i < str.Length; i++)
            {

                if (str[i] == str[i - 1] && i < str.Length - 1)
                {
                    count++;
                }
                // case when the last letter is in the sequence preceding it. Add that sequence to
                // the compressed string
                else if (i == str.Length - 1 && str[i] == str[i - 1])
                {
                    count++;
                    builder.Append(str[i]);
                    builder.Append(count);
                }

                // case where the last letter is NOT in the sequence preceding it. Add it to string.
                else if (i == str.Length - 1 && str[i] != str[i - 1])
                {
                    builder.Append(str[i - 1]);
                    builder.Append(count);
                    count = 1;
                    builder.Append(str[i]);
                    builder.Append(count);
                }
                else
                {
                    // appending the character and THEN appending the count works.
                    builder.Append(str[i - 1]);
                    builder.Append(count);
                    count = 1;
                }

            }

            str = builder.ToString();
            Console.WriteLine(str);

            return str;
        }


        static String compress_simpler(String str)
        {
            if (!str.Any())
            {
                return "";
            }

            char[] chars = str.ToCharArray();
            StringBuilder builder = new StringBuilder();

            int count = 1;
            char prev = chars[0];
            for (int i = 1; i < chars.Length; i++)
            {
                char current = chars[i];
                if (current == prev)
                {
                    count++;
                }
                else
                {
                    builder.Append(prev).Append(count);
                    count = 1;
                }
                prev = current;
            }
            str = builder.Append(prev).Append(count).ToString();
            Console.WriteLine(str);

            return str;
        }
    }
}

//http://codereview.stackexchange.com/questions/65335/basic-string-compression-counting-repeated-characters

//http://www.geeksforgeeks.org/run-length-encoding/