using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIf_GivenSequenceOfMoves__ForRobot__IsCircular
{
    class Program
    {
        // Macros for East, North, South and West
        const int N = 0;
        const int E = 1;
        const int S = 2;
        const int W = 3;

        static void Main(string[] args)
        {
            string path = "GLGLGLG";
            if (isCircular(path))
                Console.WriteLine("Given sequence of moves is circular");
            else
                Console.WriteLine("Given sequence of moves is NOT circular");
        }

        // This function returns true if the given path is circular, else false
        static bool isCircular(string path)
        {
            // Initialize starting point for robot as (0, 0) and starting
            // direction as N North
            int x = 0, y = 0;
            int dir = N;

            // Travers the path given for robot
            for (int i = 0; i < path.Length; i++)
            {
                // Find current move
                char move = path[i];

                // If move is left or right, then change direction
                if (move == 'R')
                    dir = (dir + 1) % 4;
                else if (move == 'L')
                    dir = (4 + dir - 1) % 4;

                // If move is Go, then change  x or y according to
                // current direction
                else // if (move == 'G')
                {
                    if (dir == N)
                        y++;
                    else if (dir == E)
                        x++;
                    else if (dir == S)
                        y--;
                    else // dir == W
                        x--;
                }
            }

            // If robot comes back to (0, 0), then path is cyclic
            return (x == 0 && y == 0);
        }
    }
}


//http://www.geeksforgeeks.org/check-if-a-given-sequence-of-moves-for-a-robot-is-circular-or-not/