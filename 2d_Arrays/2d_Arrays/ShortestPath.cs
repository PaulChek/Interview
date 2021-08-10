using System;
using System.Collections.Generic;

namespace _2d_Arrays {
    public class ShortestPath {
        public static int[,] Find(int[,] arr) {
            List<(int, int)> gates = FindAllGates(arr);


            gates.ForEach(g => Solve(arr, g, new bool[arr.GetLength(0), arr.GetLength(1)]) );
            
            return arr;
        }

        private static List<(int, int)> FindAllGates(int[,] arr) {
            var res = new List<(int, int)>();
            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] == 0) res.Add((i, j));
            }
            return res;
        }

        private static void Solve(int[,] arr, (int i, int j) p, bool[,] seen, int steps = 0) {
            arr[p.i, p.j] = Math.Min(arr[p.i, p.j], steps);
            seen[p.i, p.j] = true;

            if (isValid((p.i - 1, p.j), arr, seen, steps)) { Solve(arr, (p.i - 1, p.j), seen, steps + 1); }
            if (isValid((p.i, p.j + 1), arr, seen, steps)) { Solve(arr, (p.i, p.j + 1), seen, steps + 1); }
            if (isValid((p.i + 1, p.j), arr, seen, steps)) { Solve(arr, (p.i + 1, p.j), seen, steps + 1); }
            if (isValid((p.i, p.j - 1), arr, seen, steps)) { Solve(arr, (p.i, p.j - 1), seen, steps + 1); }
        }

        private static bool isValid((int i, int j) p, int[,] arr, bool[,] seen, int steps) {
            if (p.i < 0 || p.i >= arr.GetLength(0) || p.j < 0 || p.j >= arr.GetLength(1) || arr[p.i, p.j] <= steps|| arr[p.i, p.j] == -1 || seen[p.i, p.j] || arr[p.i, p.j] == 0) return false;
            return true;
        }
    }
}
