using System;
using System.Collections.Generic;

namespace BT {
    class Program {
        static void Main(string[] args) {
            var sudoku = new int[9, 9];
            sudoku[0 + 3, 0 + 3] = 1;
            sudoku[0 + 3, 1 + 3] = 2;
            sudoku[0 + 3, 2 + 3] = 3;
            sudoku[1 + 3, 0 + 3] = 4;
            sudoku[1 + 3, 1 + 3] = 5;
            sudoku[1 + 3, 2 + 3] = 6;
            sudoku[2 + 3, 0 + 3] = 7;
            sudoku[2 + 3, 2 + 3] = 9;
            //SudokuSolver.Solve(sudoku);



            var queens = 6;
            var board = new int[queens, queens];

            N_QueenTask.Solve(board);
            ShowBoard(board);

        }

        public static void ShowBoard(int[,] board) {
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++) {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
            }
        }
    }
}
