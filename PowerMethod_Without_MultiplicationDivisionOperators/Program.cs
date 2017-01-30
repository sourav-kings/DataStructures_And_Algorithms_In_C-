using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerMethod_Without_MultiplicationDivisionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n" +  pow(5, 3));
        }

        /* A recursive function to get a^b
        Works only if a >= 0 and b >= 0  */
        static int pow(int a, int b)
        {
            if (b != 0)
                return multiply(a, pow(a, b - 1));
            else
                return 1;
        }

        /* A recursive function to get x*y */
        static int multiply(int x, int y)
        {
            if (y != 0)
                return (x + multiply(x, y - 1));
            else
                return 0;
        }
    }
}


//http://www.geeksforgeeks.org/write-you-own-power-without-using-multiplication-and-division/