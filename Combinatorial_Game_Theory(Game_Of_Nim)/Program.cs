using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorial_Game_Theory_Game_Of_Nim_
{
    class Program
    {
        const int COMPUTER = 1;
        const int HUMAN = 2;
        static void Main(string[] args)
        {
            // Test Case 1
            int[] piles = { 3, 4, 5 };
            int n = piles.Length;

            // We will predict the results before playing
            // The COMPUTER starts first
            knowWinnerBeforePlaying(piles, n, COMPUTER);

            // Let us play the game with COMPUTER starting first
            // and check whether our prediction was right or not
            playGame(piles, n, COMPUTER);

            /*
            Test Case 2
            int piles[] = {3, 4, 7};
            int n = sizeof(piles)/sizeof(piles[0]);

            // We will predict the results before playing
            // The HUMAN(You) starts first
            knowWinnerBeforePlaying (piles, n, COMPUTER);

            // Let us play the game with COMPUTER starting first
            // and check whether our prediction was right or not
            playGame (piles, n, HUMAN);    */
        }

        /*
             piles[] -> Array having the initial count of stones/coins
                        in each piles before the game has started.
             n       -> Number of piles
 
             The piles[] are having 0-based indexing*/

        // A C function to output the current game state.
        static void showPiles(int[] piles, int n)
        {
            int i;
            Console.WriteLine("Current Game Status -> ");
            for (i = 0; i < n; i++)
                Console.WriteLine(piles[i]);
            Console.WriteLine("\n");
            return;
        }

        // A C function that returns True if game has ended and
        // False if game is not yet over
        static bool gameOver(int[] piles, int n)
        {
            int i;
            for (i = 0; i < n; i++)
                if (piles[i] != 0)
                    return (false);

            return (true);
        }

        // A C function to declare the winner of the game
        static void declareWinner(int whoseTurn)
        {
            if (whoseTurn == COMPUTER)
                Console.WriteLine("\nHUMAN won\n\n");
            else
                Console.WriteLine("\nCOMPUTER won\n\n");
            return;
        }

        // A C function to calculate the Nim-Sum at any point
        // of the game.
        static int calculateNimSum(int[] piles, int n)
        {
            int i, nimsum = piles[0];
            for (i = 1; i < n; i++)
                nimsum = nimsum ^ piles[i];
            return (nimsum);
        }

        // A C function to make moves of the Nim Game
        static void makeMove(int[] piles, int n, move moves)
        {
            int i, nim_sum = calculateNimSum(piles, n);

            // The player having the current turn is on a winning
            // position. So he/she/it play optimally and tries to make
            // Nim-Sum as 0
            if (nim_sum != 0)
            {
                for (i = 0; i < n; i++)
                {
                    // If this is not an illegal move
                    // then make this move.
                    if ((piles[i] ^ nim_sum) < piles[i])
                    {
                        (moves).pile_index = i;
                        (moves).stones_removed =
                                         piles[i] - (piles[i] ^ nim_sum);
                        piles[i] = (piles[i] ^ nim_sum);
                        break;
                    }
                }
            }

            // The player having the current turn is on losing
            // position, so he/she/it can only wait for the opponent
            // to make a mistake(which doesn't happen in this program
            // as both players are playing optimally). He randomly
            // choose a non-empty pile and randomly removes few stones
            // from it. If the opponent doesn't make a mistake,then it
            // doesn't matter which pile this player chooses, as he is
            // destined to lose this game.

            // If you want to input yourself then remove the rand()
            // functions and modify the code to take inputs.
            // But remember, you still won't be able to change your
            // fate/prediction.
            else
            {
                // Create an array to hold indices of non-empty piles
                int[] non_zero_indices = new int[n]; int count;

                for (i = 0, count = 0; i < n; i++)
                    if (piles[i] > 0)
                        non_zero_indices[count++] = i;

                (moves).pile_index = (new Random().Next(int.MaxValue) % (count));
                (moves).stones_removed =
                         1 + (new Random().Next(int.MaxValue) % (piles[(moves).pile_index]));
                piles[(moves).pile_index] =
                 piles[(moves).pile_index] - (moves).stones_removed;

                if (piles[(moves).pile_index] < 0)
                    piles[(moves).pile_index] = 0;
            }
            return;
        }

        // A C function to play the Game of Nim
        static void playGame(int[] piles, int n, int whoseTurn)
        {
            Console.WriteLine("\nGAME STARTS\n\n");
            move moves = new move();

            while (gameOver(piles, n) == false)
            {
                showPiles(piles, n);


                makeMove(piles, n, moves);

                if (whoseTurn == COMPUTER)
                {
                    Console.WriteLine("COMPUTER removes %d stones from pile at index %d\n", moves.stones_removed,
                           moves.pile_index);
                    whoseTurn = HUMAN;
                }
                else
                {
                    Console.WriteLine("HUMAN removes %d stones from pile at index %d\n", moves.stones_removed,
                           moves.pile_index);
                    whoseTurn = COMPUTER;
                }
            }


            showPiles(piles, n);
            declareWinner(whoseTurn);
            return;
        }

        static void knowWinnerBeforePlaying(int[] piles, int n, int whoseTurn)
        {
            Console.WriteLine("Prediction before playing the game -> ");

            if (calculateNimSum(piles, n) != 0)
            {
                if (whoseTurn == COMPUTER)
                    Console.WriteLine("COMPUTER will win\n");
                else
                    Console.WriteLine("HUMAN will win\n");
            }
            else
            {
                if (whoseTurn == COMPUTER)
                    Console.WriteLine("HUMAN will win\n");
                else
                    Console.WriteLine("COMPUTER will win\n");
            }

            return;
        }
    }

    /* A Structure to hold the two parameters of a move

     A move has two parameters-
      1) pile_index = The index of pile from which stone is
                      going to be removed
      2) stones_removed = Number of stones removed from the
                          pile indexed = pile_index  */
    class move
    {
        public int pile_index;
        public int stones_removed;
    }
}

//http://www.geeksforgeeks.org/combinatorial-game-theory-set-2-game-nim/