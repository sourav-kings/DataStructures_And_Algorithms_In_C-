using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Tour_That_Visits_AllStations
{
    class Program
    {
        static void Main(string[] args)
        {
            PetrolPump[] arr = new PetrolPump[] {new PetrolPump(6,4), new PetrolPump(3,6), new PetrolPump(7,3)};

            int n = arr.Length;
            int start = printTour(arr, n);

            if (start == -1)
                Console.WriteLine("No solution");
            else
                Console.WriteLine("Start = " + start);

        }

    // The function returns starting point if there is a possible solution,
    // otherwise returns -1
        static int printTour(PetrolPump[] arr, int n)
        {
            // Consider first petrol pump as a starting point
            int start = 0;
                int end = 1;

                int curr_petrol = arr[start].petrol - arr[start].distance;
 
            /* Run a loop while all petrol pumps are not visited.
              And we have reached first petrol pump again with 0 or more petrol */
            while (end != start || curr_petrol< 0)
            {
                // If curremt amount of petrol in truck becomes less than 0, then
                // remove the starting petrol pump from tour
                while (curr_petrol< 0 && start != end)
                {
                    // Remove starting petrol pump. Change start
                    curr_petrol -= arr[start].petrol - arr[start].distance;
                    start = (start + 1)%n;
 
                    // If 0 is being considered as start again, then there is no
                    // possible solution
                    if (start == 0)
                       return -1;
                }

            // Add a petrol pump to current tour
            curr_petrol += arr[end].petrol - arr[end].distance;
 
                end = (end + 1)%n;
            }
 
            // Return starting point
            return start;
        }
    }
    // A petrol pump has petrol and distance to next petrol pump
    class PetrolPump
    {
        public int petrol;
        public int distance;

        public PetrolPump(int petrol, int distance)
        {
            this.petrol = petrol;
            this.distance = distance;
        }
    };
}

//http://www.geeksforgeeks.org/find-a-tour-that-visits-all-stations/