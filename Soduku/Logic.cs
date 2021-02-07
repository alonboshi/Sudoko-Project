using System;
using System.Collections.Generic;
using System.Text;

namespace Soduku
{
    public class Logic
    {
        private int N;  // size NxN
        private int partic;  // particular particXpartic matrix
        public Logic(int N) {// -------c'stor
            this.N = N;
            this.Particular();
        } 
        public bool IsSafe(int [,]grid, int row,int col, int num)
        {

            // Check if we find the same num 
            // in the similar row , we
            // return false
            for (int x = 0; x <= N-1; x++)
                if (grid[row,x] == num)
                    return false;

            // Check if we find the same num in 
            // the similar column , we
            // return false
            for (int x = 0; x <= N-1; x++)
                if (grid[x,col] == num)
                    return false;

            try
            {
                // Check if we find the same num in 
                // the particular 3*3 matrix,
                // we return false
                int startRow = row - row % this.partic, startCol = col - col % this.partic;

                for (int i = 0; i < this.partic; i++)
                    for (int j = 0; j < this.partic; j++)
                        if (grid[i + startRow, j + startCol] == num)
                            return false;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return true;
        }

        public bool IsSolved(int[,] grid)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (grid[i, j] == 0)
                        return false;
            return true;
        }

        /* Takes a partially filled-in grid and attempts
        to assign values to all unassigned locations in
        such a way to meet the requirements for
        Sudoku solution (non-duplication across rows,
        columns, and boxes) */
        public bool SolveSuduko(int[,] grid, int row, int col)
        {
            // Check if we have reached the 8th 
            // row and 9th column (0
            // indexed matrix) , we are 
            // returning true to avoid
            // further backtracking
            if (row == N - 1 && col == N)
                return true;

            // Check if column value  becomes 9 , 
            // we move to next row and
            //  column start from 0
            if (col == N)
            {
                row++;
                col = 0;
            }

            // Check if the current position of 
            // the grid already contains
            // value >0, we iterate for next column
            if (grid[row,col] > 0)
                return SolveSuduko(grid, row, col + 1);

            for (int num = 1; num <= N; num++)
            {

                // Check if it is safe to place 
                // the num (1-9)  in the
                // given row ,col  ->we 
                // move to next column
                if (IsSafe(grid, row, col, num))
                {

                    /* Assigning the num in 
                       the current (row,col)
                       position of the grid
                       and assuming our assined 
                       num in the position
                       is correct     */
                    grid[row,col] = num;

                    //  Checking for next possibility with next
                    //  column
                    if (SolveSuduko(grid, row, col + 1))
                        return true;
                }

                // Removing the assigned num , 
                // since our assumption
                // was wrong , and we go for 
                // next assumption with
                // diff num value
                grid[row,col] = 0;
            }
            return false;
        }

        public void Particular()
        {
            if((N/2-1)<2)
            { if (N == 4)
                {
                    this.partic = 2;
                    return;
                }
                this.partic = 1;
                return;
            }
            for (int i = N/2-1; i >=2; i++)
            {
                if (this.N % i == 0)
                {
                    this.partic = i;
                    return;
                }
            }
            this.partic = 1;
        }
    }
}

//////// כשהלוח מלא או לא צריך לבדוק תקינות של ההכנסה בלוח