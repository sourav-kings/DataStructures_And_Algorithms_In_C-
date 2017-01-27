using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Position_Of_Rightmost_SetBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 18;
            Console.WriteLine(getFirstSetBitPos(n));
        }

        static int getFirstSetBitPos(int n)
        {
            string binaryRepresentation = Convert.ToString(n, 2);

            int v2 = Convert.ToInt32(binaryRepresentation);
            v2 = ~v2;
            v2 = v2 + 1;


            ushort v = Convert.ToUInt16(binaryRepresentation);
            ushort twosComp = (ushort)(~v + 1);
            string h = string.Format("{0:X}", twosComp);

            int n2 = n + 128;
            int bitWise = n & n2;
            double bitWiseDouble = Convert.ToDouble(bitWise);


            double log2 = Math.Log(bitWiseDouble, 2);
            int log2Integer = Convert.ToInt32(log2);
            return log2Integer + 1;
        }
    }
}
