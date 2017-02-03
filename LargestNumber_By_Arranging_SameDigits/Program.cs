using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumber_By_Arranging_SameDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 8754365;
            Console.WriteLine("Orginal number:- " + input);
            Console.WriteLine("Largest number after reaarangement of same digits:- " + largestNumber(input));
        }

        static int largestNumber(int data)
        {
            int num = data;
            int[] times = new int[10];
            while (num != 0)
            {
                int val = num % 10;
                times[val]++;
                num /= 10;
            }
            int largestNumber = 0;
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 0; j < times[i]; j++)
                {
                    largestNumber = largestNumber * 10 + i;
                }
            }
            return largestNumber;
        }
    }
}

//http://codereview.stackexchange.com/questions/92022/rearranging-numbers-to-get-the-largest-number