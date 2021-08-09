using System;

namespace _2d_Arrays {
    static class HowManyIslands {
        public static int Solve(int[,] arr) {
            var seen = new bool[arr.GetLength(0), arr.GetLength(1)];
            int res = 0;
            (int row, int col) coordinates = Find1(arr, seen);

            while (coordinates.row != -1) {
                res++;
                IterateViaIsland(arr, seen, coordinates);
                coordinates = Find1(arr, seen);
            }






            for (int r = 0; r < seen.GetLength(0); r++) {
                for (int c = 0; c < seen.GetLength(0); c++) {
                    if (seen[r, c]) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(seen[r, c] ? 1 + " " : 0 + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            return res;
        }

        private static void IterateViaIsland(int[,] arr, bool[,] seen, (int row, int col) coordinates) {

            seen[coordinates.row, coordinates.col] = true;
            //arr[coordinates.row, coordinates.col] = 0; //if you allow mutate input

            if (isValid((coordinates.row - 1, coordinates.col), seen, arr)) IterateViaIsland(arr, seen, (coordinates.row - 1, coordinates.col));
            if (isValid((coordinates.row, coordinates.col + 1), seen, arr)) IterateViaIsland(arr, seen, (coordinates.row, coordinates.col + 1));
            if (isValid((coordinates.row + 1, coordinates.col), seen, arr)) IterateViaIsland(arr, seen, (coordinates.row + 1, coordinates.col));
            if (isValid((coordinates.row, coordinates.col - 1), seen, arr)) IterateViaIsland(arr, seen, (coordinates.row, coordinates.col - 1));
        }

        private static bool isValid((int row, int col) coordinates, bool[,] seen, int[,] arr) {
            if (coordinates.row < 0 || coordinates.col < 0 || coordinates.row >= arr.GetLength(0) || coordinates.col >= arr.GetLength(1)
                || seen[coordinates.row, coordinates.col] || arr[coordinates.row, coordinates.col] == 0) return false;
            return true;
        }

        private static (int row, int col) Find1(int[,] arr, bool[,] seen) {

            for (int r = 0; r < arr.GetLength(0); r++)
                for (int c = 0; c < arr.GetLength(1); c++)
                    if (!seen[r, c] && arr[r, c] == 1) return (r, c);

            return (-1, -1);
        }
    }
}
