using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Buy_Sell_To_MaximizeProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            // stock prices on consecutive days
            int[] price = { 100, 180, 260, 310, 40, 535, 695 };
            int n = price.Length;

            // fucntion call
            stockBuySell(price, n);
        }

        // This function finds the buy sell schedule for maximum profit
        static void stockBuySell(int[] price, int n)
        {
            // Prices must be given for at least two days
            if (n == 1)
                return;

            int count = 0;

            // solution array
            List<Interval> sol = new List<Interval>();

            // Traverse through given price array
            int i = 0;
            while (i < n - 1)
            {
                // Find Local Minima. Note that the limit is (n-2) as we are
                // comparing present element to the next element. 
                while ((i < n - 1) && (price[i + 1] <= price[i]))
                    i++;

                // If we reached the end, break as no further solution possible
                if (i == n - 1)
                    break;

                Interval e = new Interval();
                e.buy = i++;
                // Store the index of minima


                // Find Local Maxima.  Note that the limit is (n-1) as we are
                // comparing to previous element
                while ((i < n) && (price[i] >= price[i - 1]))
                    i++;

                // Store the index of maxima
                e.sell = i - 1;
                sol.Add(e);

                // Increment number of buy/sell
                count++;
            }

            // print solution
            if (count == 0)
                Console.WriteLine("There is no day when buying the stock "
                                                      + "will make profit");
        else
            for (int j = 0; j < count; j++)
                    Console.WriteLine("Buy on day: " + sol[j].buy
                        + "        " + "Sell on day : " + sol[j].sell);

            return;
        }
    }

    // Solution structure
    class Interval
    {
        public int buy, sell;
    }
}


//http://www.geeksforgeeks.org/stock-buy-sell/

//Average Difficulty : 3.1/5.0
//Based on 81 vote(s)