using System;

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
            // sudoku[2 + 3, 1 + 3] = 8;
            sudoku[2 + 3, 2 + 3] = 9;



            SudokuSolver.Solve(sudoku);

            ShowSudoku(sudoku);

        }
        public static void ShowSudoku(int[,] sudocku) {
            for (int r = 0; r < sudocku.GetLength(0); r++) {
                for (int c = 0; c < sudocku.GetLength(1); c++)
                    Console.Write(sudocku[r, c] + " " + (c == 2 || c == 5 || c == 8 ? " " : ""));
                Console.WriteLine((r == 2 || r == 5 || r == 8 ? "\n" : ""));
            }
        }
    }
    static class SudokuSolver {
        public static bool Solve(int[,] sudoku) {
            
            
            
            (int r, int c) = FindEmptyCell( sudoku);
           
            
            if (r == -1) return true;

         


            for (int n = 1; n < 10; n++) {
                if (IsValid((r, c), sudoku, n)) {
                    sudoku[r, c] = n;
                   
                    if (Solve(sudoku)) return true;
                    else sudoku[r, c] = 0;
                }
            }

            return false;

        }

        private static (int r, int c) FindEmptyCell(int[,] sudoku) {

            for (int i = 0; i < sudoku.GetLength(0); i++)
                for (int j = 0; j < sudoku.GetLength(1); j++)
                    if (sudoku[i, j] == 0) return (i, j);

            return (-1, -1);
        }

        static bool IsValid((int row, int col) place, int[,] sudoku, int val) {

            //row 
            for (int c = 0; c < sudoku.GetLength(0); c++)
                if (sudoku[place.row, c] == val) return false;
            //col
            for (int r = 0; r < sudoku.GetLength(0); r++)
                if (sudoku[r, place.col] == val) return false;



            //find Start of cube 3x3;
            (int sR, int sC) = (place.row / 3 * 3, place.col / 3 * 3); // Math.flor cuz int

            for (int i = sR; i < sR + 3; i++)
                for (int j = sC; j < sC + 3; j++)
                    if (sudoku[i, j] == val) return false;


            return true;
        }
    }
}
