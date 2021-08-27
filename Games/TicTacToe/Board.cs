using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class Board {
        private Func<string> GetInput = Console.ReadLine;

        public Board() {
            Cells = new List<Cell>();
            VisualBoard = new int[Program.size, Program.size]; // 0 empty. 1 pc, 2 u
        }

        internal List<Cell> Cells { get; set; }
        internal List<Cell> EmptyCells { get; set; }
        internal int[,] VisualBoard { get; set; }


        internal void DisplayBoard() {
            for (int i = 0; i < VisualBoard.GetLength(0); i++) {
                for (int j = 0; j < VisualBoard.GetLength(1); j++)
                    Console.Write(VisualBoard[i, j] + " ");
                Console.WriteLine();
            }
        }

        internal Cell GetBestMove() {
            int max = -100;
            int best = -1;
            for (int i = 0; i < Cells.Count; i++)
                if (Cells[i].MiniMaxVal > max) { max = Cells[i].MiniMaxVal; best = i; }
            return Cells[best];
        }

        internal (int row, int cell) GetCorrdinatesFromInput() {
            Console.WriteLine("Enter Coordinates: row,col:");
            var input = GetInput().Split(',').Select(v => int.Parse(v));
            return (input.FirstOrDefault(), input.LastOrDefault());
        }

        internal void InvokeMiniMax(int depth, int player) {
            Cells.Clear();
            MiniMax(depth, player);
        }

        private int MiniMax(int depth, int player) {
            if (IsWinning(1)) return +1;
            if (IsWinning(2)) return -1;

            List<Cell> availableCells = GetEmptyCells();

            if (availableCells.Count == 0) return 0;

            List<int> scores = new();

            availableCells.ForEach(point => {

                //Cell point = availableCells[i];

                if (player == 1) { //X's turn select the highest from below minimax() call
                    Move(point, 1);
                    int currentScore = MiniMax(depth + 1, 2);
                    scores.Add(currentScore);

                    if (depth == 0) {
                        point.MiniMaxVal = currentScore;
                        Cells.Add(point);
                    }

                }
                else if (player == 2) {//O's turn select the lowest from below minimax() call
                    Move(point, 2);
                    scores.Add(MiniMax(depth + 1, 1));
                }

                VisualBoard[point.Coordinatres.row, point.Coordinatres.col] = 0; //Reset this point
            });

            if (player == 1) {
                return scores.Max();
            }

            return scores.Min();
        }

        internal bool IsRunning() {
            if (IsWinning(1)) return false;
            if (IsWinning(2)) return false;
            if (GetEmptyCells().Count == 0) return false;
            return true;
        }

        private List<Cell> GetEmptyCells() {
            EmptyCells = new(); // evry request create new list
            for (int i = 0; i < VisualBoard.GetLength(0); i++)
                for (int j = 0; j < VisualBoard.GetLength(1); j++)
                    if (VisualBoard[i, j] == 0) EmptyCells.Add(new Cell((i, j)));
            return EmptyCells;

        }

        internal bool IsWinning(int player) {
            bool row = true, col = true, diag = true, diag2 = true;

            for (int i = 0; i < VisualBoard.GetLength(0); i++) {
                row = true; col = true;
                for (int j = 0; j < VisualBoard.GetLength(1); j++) {
                    if (VisualBoard[i, j] != player) row = false;
                    if (VisualBoard[j, i] != player) col = false;
                }
                if (row || col) break;
            }

            for (int i = 0, j = 0; i < VisualBoard.GetLength(0); i++, j++)
                if (VisualBoard[i, j] != player) diag = false;

            for (int i = VisualBoard.GetLength(0) - 1, j = 0; j < VisualBoard.GetLength(1); i--, j++)
                if (VisualBoard[i, j] != player) diag2 = false;

            return row || col || diag || diag2;
        }

        internal void Move(Cell cell, int player) {
            VisualBoard[cell.Coordinatres.row, cell.Coordinatres.col] = player;
        }
    }
}
