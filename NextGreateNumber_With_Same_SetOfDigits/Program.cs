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
            String x = "218765";//4321
            char[] num = x.ToCharArray();
            //int i;
            //for (i = num.Length - 1; i > 0; i--)
            //{
            //    if (num[i] > num[i - 1])
            //    {
            //        break;
            //    }
            //}
            //if (i == 0)
            //{
            //    Console.WriteLine("Next number not possible!!!");
            //    return;
            //}

            //int[] sorter = new int[10];
            //for (int j = i; j < num.Length; j++)
            //{
            //    sorter[(num[j] - 48)]++;
            //}
            //int k = num[i - 1] - 48 + 1;
            //for (; k <= 9; k++)
            //{
            //    if (sorter[k] > 0)
            //    {
            //        break;
            //    }
            //}
            //int lowerNum = num[i - 1] - 48;
            //sorter[lowerNum]++;
            //num[i - 1] = (char)(k + 48);
            ////sorter[k]=0;
            //sorter[k]--;
            //for (int j = 0; j <= 9 && i < num.Length; j++)
            //{
            //    if (sorter[j] > 0)
            //    {
            //        num[i++] = (char)(j + 48);
            //    }
            //}
            Console.WriteLine(x);
            //Console.WriteLine(num);
            findNext(num, num.Length);
        }


        // Given a number as a char array number[], this function finds the
        // next greater number.  It modifies the same array to store the result
        static void findNext(char[] number, int n)
        {
            int i, j;

            // I) Start from the right most digit and find the first digit that is
            // smaller than the digit next to it.
            for (i = n - 1; i > 0; i--)
                if (number[i] > number[i - 1])
                    break;

            // If no such digit is found, then all digits are in descending order
            // means there cannot be a greater number with same set of digits
            if (i == 0)
            {
                Console.WriteLine("Next number is not possible");
                return;
            }

            // II) Find the smallest digit on right side of (i-1)'th digit that is
            // greater than number[i-1]
            int x = number[i - 1], smallest = i;
            for (j = i + 1; j < n; j++)
                if (number[j] > x && number[j] < number[smallest])
                    smallest = j;

            // III) Swap the above found smallest digit with number[i-1]
            swap(number, smallest, i - 1);

            // IV) Sort the digits after (i-1) in ascending order
            Array.Sort(number, i, n - i);// number + i, number + n);

            Console.WriteLine("Next number with same set of digits is " + new string(number));
            return;
        }

        static void swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

//http://www.geeksforgeeks.org/find-next-greater-number-set-digits/
//http://pastebin.com/A7WPheVj

//Average Difficulty : 3.3/5.0
//Based on 80 vote(s)
