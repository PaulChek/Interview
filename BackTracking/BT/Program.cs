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
    class N_QueenTask {
        public static bool Solve(int[,] board, int c = 0) {

            if (c >= board.GetLength(1)) return true;



            for (int r = 0; r < board.GetLength(1); r++) {
                if (IsValidPosition(board, (r, c))) {
                    board[r, c] = 1;
                    if (Solve(board, c + 1)) return true;
                    else board[r, c] = 0;
                }
            }

            return false;
        }

        private static bool IsValidPosition(int[,] board, (int r, int c) p) {
            for (int c = 0; c < p.c; c++)
                if (board[p.Item1, c] == 1) return false;

            for (int i = p.r, j = p.c; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1) return false;

            for (int i = p.r, j = p.c; i < board.GetLength(0) && j >= 0; i++, j--)
                if (board[i, j] == 1) return false;

            return true;
        }
    }
}
