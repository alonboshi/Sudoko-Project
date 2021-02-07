using System;
using System.IO;

namespace Soduku
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string input_start = "";
            do
            {
                Console.WriteLine("Enter 1 if you want to give the input in a txt file /nor enter 2 " +
               "if you want to give the input in here as a string");
                choice = int.Parse(Console.ReadLine());
            }
            while (!(choice >= 1 && choice <= 2));
            if (choice == 2)
            {
                Console.WriteLine("\nenter the soduku numbers to fill the board please :\t\t");
                input_start = Console.ReadLine();
            }
            else
            {
                try
                {
                    string path = @"C:\Users\Alon\Documents\YudGimel\Omega\Soduku_Project\Soduku\Input.txt";
                    input_start = File.ReadAllText(path);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            Board board = new Board(input_start);
            board.PrintSudoku();
            for (int i = 0; i < 15; i++)
                Console.WriteLine("");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tAlon");
            Logic logic = new Logic(board.GetN());
            logic.SolveSuduko(board.GetMat(),0,0);
            

            if (!logic.IsSolved(board.GetMat()))
            {
                Console.WriteLine("There Is No Solution For this Soduko!!\ntry to put another input");
                board = new Board(input_start);
                board.PrintSudoku();
                logic = new Logic(board.GetN());
                logic.SolveSuduko(board.GetMat(), 0, 0);
            }
            board.PrintSudoku();
        }
    }
}
