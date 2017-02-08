using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_For_Integer_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = new int();
            int x = 2147483640;
            int y = 10;

            Console.WriteLine(addOvf(res, x, y));

            Console.WriteLine("\n " + res);


            Console.WriteLine(addOvf_no_modification(res, x, y));

            Console.WriteLine("\n " + res);
        }

        /* Takes pointer to result and two numbers as
    arguments. If there is no overflow, the function
    places the resultant = sum a+b in “result” and
    returns 0, otherwise it returns -1 */
        static int addOvf(int result, int a, int b)
        {
            result = a + b;
            if (a > 0 && b > 0 && result < 0)
                return -1;
            if (a < 0 && b < 0 && result > 0)
                return -1;
            return 0;
        }



        static int addOvf_no_modification(int result, int a, int b)
        {
            if (a > int.MaxValue - b)
                return -1;
            else
            {
                result = a + b;
                return 0;
            }
        }
    }
}

//http://www.geeksforgeeks.org/check-for-integer-overflow/