using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumber_With_Unique_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            Console.WriteLine(countNumbersWithUniqueDigits(2));
        }

        static int countNumbersWithUniqueDigits(int n)
        {
            if (n == 0) return 1;

            int res = 10;
            int uniqueDigits = 9;
            int availableNumber = 9;
            while (n-- > 1 && availableNumber > 0)
            {
                uniqueDigits = uniqueDigits * availableNumber;
                res += uniqueDigits;
                availableNumber--;
            }
            return res;
        }
    }
}
