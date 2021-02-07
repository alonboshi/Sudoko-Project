using System;
using System.IO;

namespace Soduku
{
    class Board
    {
        private int[,] mat;  // game board
        private int N;  // size of the board NXN

        // -------------c'stor---------
        public Board(string input_start)
        {
            bool good_input = this.Input_Board(input_start);
            // the program won't continue till the input is valid
            while (!good_input)
            {
                Console.WriteLine("Wrong input! enter a new one\n");
                input_start = Console.ReadLine();
                good_input = this.Input_Board(input_start);
            }

            //--------------------------------------------------------------------------------------------------------

            /*this.mat = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    this.mat[i, j] = 0;*/
        }

        // ----------------print the current look of the board--------
        public void PrintSudoku()
        {
            Console.WriteLine("+-----+-----+-----+");
            for (int i = 1; i < N + 1; ++i)
            {
                for (int j = 1; j < N + 1; ++j)
                    Console.Write("|  {0}", this.mat[i - 1, j - 1]);
                Console.WriteLine("|  ");
                if (i % (N / 3) == 0)
                    Console.WriteLine("+-----+-----+-----+");
            }
        }

        // enter to the board the input from the user.
        // also the function returns true if the input is valid,else false
        private bool Input_Board(string input_start)
        {
            int z = 0;  // counter of numbers array
            int[] numbers = new int[input_start.Length];
            this.N = Convert.ToInt32(Math.Sqrt(numbers.Length)); // calculate the size of rows/cols in the matrix by the input
            if (this.N % 3 != 0 || N * N != numbers.Length)      // checks if the N is a valid size of board
                return false;
             
            for (int i = 0; i < input_start.Length; i++)    // puts the string input in an array of ints
            {
                numbers[i] = input_start[i] - '0';
                if (numbers[i] > N || numbers[i] < 0)    // checks if the specific char is an int and not bigger than N 
                    return false;
            }
            this.mat = new int[ N, N]; // creats the matrix after all the input checks are true
            for ( int i = 0; i < N; i++)
                for (int j=0; j < N; j++,z++)
                    this.mat[i,j] = numbers[z];
            return true;
        }

        public int GetN()
        { return this.N; }
        public int[,] GetMat()
        { return this.mat; }
    }
}
//306508400520000000087000031003010080900863005050090600130000250000000074005206300

//000