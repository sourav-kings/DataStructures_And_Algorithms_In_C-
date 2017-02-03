using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGreateNumber_With_Same_SetOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            String x = "347359";
            char[] num = x.ToCharArray();
            int i;
            for (i = num.Length - 1; i > 0; i--)
            {
                if (num[i] > num[i - 1])
                {
                    break;
                }
            }
            if (i == 0)
            {
                Console.WriteLine("Next number not possible!!!");
                return;
            }

            int[] sorter = new int[10];
            for (int j = i; j < num.Length; j++)
            {
                sorter[(num[j] - 48)]++;
            }
            int k = num[i - 1] - 48 + 1;
            for (; k <= 9; k++)
            {
                if (sorter[k] > 0)
                {
                    break;
                }
            }
            int lowerNum = num[i - 1] - 48;
            sorter[lowerNum]++;
            num[i - 1] = (char)(k + 48);
            //sorter[k]=0;
            sorter[k]--;
            for (int j = 0; j <= 9 && i < num.Length; j++)
            {
                if (sorter[j] > 0)
                {
                    num[i++] = (char)(j + 48);
                }
            }
            Console.WriteLine(x);
            Console.WriteLine(num);
        }
    }
}

//http://www.geeksforgeeks.org/find-next-greater-number-set-digits/
//http://pastebin.com/A7WPheVj