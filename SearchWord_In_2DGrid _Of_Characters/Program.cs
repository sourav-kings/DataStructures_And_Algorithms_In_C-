using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWord_In_2DGrid__Of_Characters
{
    class Program
    {
        // Rows and columns in given grid
        const int R = 3;
        const int C = 13;

        // For searching in all 8 direction
        static int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };
        static void Main(string[] args)
        {
            char[][] grid = {new char[]{'G', 'E', 'E', 'K', 'S', 'F', 'O', 'R', 'G', 'E', 'E', 'K', 'S'},
                new char[]{'G', 'E', 'E', 'K', 'S', 'Q', 'U', 'I', 'Z', 'G', 'E', 'E', 'K'},
                new char[]{'I', 'D', 'E', 'Q', 'A', 'P', 'R', 'A', 'C', 'T', 'I', 'C', 'E'}};
            patternSearch(grid, "GEEKS");
            Console.WriteLine();
            patternSearch(grid, "EEE");
        }
        // This function searches in all 8-direction from point
        // (row, col) in grid[][]
        static bool search2D(char[][] grid, int row, int col, string word)
        {
            // If first character of word doesn't match with
            // given starting point in grid.
            if (grid[row][col] != word[0])
                return false;

            int len = word.Length;

            // Search word in all 8 directions starting from (row,col)
            for (int dir = 0; dir < 8; dir++)
            {
                // Initialize starting point for current direction
                int k, rd = row + x[dir], cd = col + y[dir];

                // First character is already checked, match remaining
                // characters
                for (k = 1; k < len; k++)
                {
                    // If out of bound break
                    if (rd >= R || rd < 0 || cd >= C || cd < 0)
                        break;

                    // If not matched,  break
                    if (grid[rd][cd] != word[k])
                        break;

                    //  Moving in particular direction
                    rd += x[dir];
                    cd += y[dir];
                }

                // If all character matched, then value of must
                // be equal to length of word
                if (k == len)
                    return true;
            }
            return false;
        }

        //  Searches given word in a given matrix in all 8 directions
        static void patternSearch(char[][] grid, string word)
        {
            // Consider every point as starting point and search
            // given word
            for (int row = 0; row < R; row++)
                for (int col = 0; col < C; col++)
                    if (search2D(grid, row, col, word))
                        Console.Write("pattern found at " + row + ", " + col);
        }
    }
}

//http://www.geeksforgeeks.org/search-a-word-in-a-2d-grid-of-characters/

//http://code.geeksforgeeks.org/aw68KG
//http://www.geeksforgeeks.org/boggle-find-possible-words-board-characters/

//Average Difficulty : 3/5.0
//Based on 19 vote(s)