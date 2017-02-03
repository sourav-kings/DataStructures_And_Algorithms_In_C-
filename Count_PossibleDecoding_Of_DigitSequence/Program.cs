

using System;

namespace Count_PossibleDecoding_Of_DigitSequence
{
    public class Program
    {
        public static void Main()
        {
            //char[] digits = {"1", "2", "3", "4"};
            char[] digits = "1234".ToCharArray();
            int n = digits.Length;
            //Console.WriteLine("Count is " + CountDecoding(digits, n));
            Console.WriteLine("Count is " + CountDecodingFaster(digits, n));
        }

        public static int CountDecoding(char[] digits, int n)
        {
            // base cases
            if (n == 0 || n == 1)
                return 1;

            int count = 0;  // Initialize count

            // If the last digit is not 0, then last digit must add to
            // the number of words
            if (digits[n - 1] > '0')
                count = CountDecoding(digits, n - 1);

            // If the last two digits form a number smaller than or equal to 26,
            // then consider last two digits and recur
            if (digits[n - 2] < '2' || (digits[n - 2] == '2' && digits[n - 1] < '7'))
                count += CountDecoding(digits, n - 2);

            return count;
        }


        // A Dynamic Programming based function to count decodings
        public static int CountDecodingFaster(char[] digits, int n)
        {
            int[] count = new int[n + 1]; // A table to store results of subproblems
            count[0] = 1;
            count[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                count[i] = 0;

                // If the last digit is not 0, then last digit must add to
                // the number of words
                if (digits[i - 1] > '0')
                    count[i] = count[i - 1];

                // If second last digit is smaller than 2 and last digit is
                // smaller than 7, then last two digits form a valid character
                if (digits[i - 2] < '2' || (digits[i - 2] == '2' && digits[i - 1] < '7'))
                    count[i] += count[i - 2];
            }
            return count[n];
        }
    }
}
