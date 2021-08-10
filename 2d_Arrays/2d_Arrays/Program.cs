using System;
using System.Collections.Generic;

namespace _2d_Arrays {
    class Program {
        static void Main(string[] args) {

            // 3 - wall, 2 - start, 1 - finish, return steps
            var arr2d = new int[,] {
                { 0, 0, 0, 0, 0 },
                { 2, 3, 0, 0, 3 },
                { 0, 2, 3, 1, 3 },
                { 0, 0, 0, 0, 0 }
            };
            var islands = new int[,] {
                { 1, 1, 0, 1, 0 },
                { 1, 1, 0, 1, 0 },
                { 1, 0, 1, 1, 0 },
                { 1, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 1 }
            }; //3

            var Oranges = new int[,] {
                { 2, 1, 0, 1, 0 },
                { 1, 1, 0, 1, 0 },
                { 1, 1, 1, 1, 0 },
                { 1, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 2 }
            }; //2-rotten, 1 -empty cell

            List<int> flat = FlatArray(arr2d);

            List<int> flat2 = FlatArray2(arr2d);



            //solving task about steps
            var steps = SolveTaskWithShortestPathIn2dArray.AmountOfSteps(arr2d);

            Console.WriteLine(string.Join(" ", steps));

            //task about islands

            int iss = HowManyIslands.Solve(islands);

            Console.WriteLine("Amount of Islands: " + iss);


            //rotten orangrs
            int min = RottingOranges.Solve(Oranges);

            Console.WriteLine("Take minutes: " + min);
        }

        private static List<int> FlatArray2(int[,] arr2d) {
            var q = new Queue<(int r, int c)>(); var dir = new (int r, int c)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };
            var seen = new HashSet<(int r, int c)>();
            var res = new List<int>();
            q.Enqueue((2, 2));
            seen.Add((2, 2));

            while (q.Count > 0) {
                var curr = q.Dequeue();
                res.Add(arr2d[curr.r, curr.c]);

                foreach (var d in dir) {
                    var new_dir = (curr.r + d.r, curr.c + d.c);
                    if (new_dir.Item1 >= 0 && new_dir.Item1 < arr2d.GetLength(0) &&
                        new_dir.Item2 >= 0 && new_dir.Item2 < arr2d.GetLength(1) &&
                        !seen.Contains(new_dir)) {
                        seen.Add(new_dir);
                        q.Enqueue(new_dir);
                    }
                }
            }

            return res;
        }

        public static List<int> FlatArray(int[,] arr2d) => FlatArray(arr2d, new(), (0, 0), new());
        private static List<int> FlatArray(int[,] arr2d, HashSet<(int, int)> seen, (int r, int c) current, List<int> res) {
            if (seen.Contains(current) || current.r < 0 || current.r >= arr2d.GetLength(0) || current.c < 0 || current.c >= arr2d.GetLength(1))
                return res;

            seen.Add(current);
            res.Add(arr2d[current.r, current.c]);

            FlatArray(arr2d, seen, (current.r - 1, current.c), res);
            FlatArray(arr2d, seen, (current.r, current.c + 1), res);
            FlatArray(arr2d, seen, (current.r + 1, current.c), res);
            FlatArray(arr2d, seen, (current.r, current.c - 1), res);

            return res;
        }
    }



    static class RottingOranges {
        public static int Solve(int[,] arr2d) {
            var q = new Queue<(int r, int c)>();

            List<(int r, int c)> rotten = FindAllRottenOranges(arr2d);


            rotten.ForEach(r => q.Enqueue(r));

            var res = DestroyOranges(q, arr2d);


            return res;
        }

        static int DestroyOranges(Queue<(int r, int c)> q, int[,] arr2d, int res = 0) {
            if (q.Count == 0) return res;

            var nq = new Queue<(int r, int c)>();
            Console.WriteLine("----Minute----" + res);
            ShowMatrix(arr2d);

            while (q.Count > 0) {
                var cur = q.Dequeue();
                arr2d[cur.r, cur.c] = 2;

                if (IsValid((cur.r - 1, cur.c), arr2d)) { nq.Enqueue((cur.r - 1, cur.c)); }
                if (IsValid((cur.r, cur.c + 1), arr2d)) { nq.Enqueue((cur.r, cur.c + 1)); }
                if (IsValid((cur.r + 1, cur.c), arr2d)) { nq.Enqueue((cur.r + 1, cur.c)); }
                if (IsValid((cur.r, cur.c - 1), arr2d)) { nq.Enqueue((cur.r, cur.c - 1)); }
            }

            var tmp = DestroyOranges(nq, arr2d, res + 1);

            return Math.Max(tmp, res);

        }
        static int DestroyOranges2(Queue<(int r, int c)> q, int[,] arr2d, int res = 0) {
            var length = q.Count;

            while (q.Count > 0) {
                var cur = q.Dequeue();
                arr2d[cur.r, cur.c] = 2;
                length--;
                
                if (IsValid((cur.r - 1, cur.c), arr2d)) { q.Enqueue((cur.r - 1, cur.c)); }
                if (IsValid((cur.r, cur.c + 1), arr2d)) { q.Enqueue((cur.r, cur.c + 1)); }
                if (IsValid((cur.r + 1, cur.c), arr2d)) { q.Enqueue((cur.r + 1, cur.c)); }
                if (IsValid((cur.r, cur.c - 1), arr2d)) { q.Enqueue((cur.r, cur.c - 1)); }

                if (length == 0) { res++; length = q.Count; }
            }

            return res;
        }
        static bool IsValid((int i, int j) p, int[,] arr) {
            if (p.i >= arr.GetLength(0) || p.i < 0
                || p.j >= arr.GetLength(0) || p.j < 0
                || arr[p.i, p.j] == 2 || arr[p.i, p.j] == 0) return false;

            return true;
        }
        private static List<(int r, int c)> FindAllRottenOranges(int[,] arr2d) {
            List<(int r, int c)> rs = new();

            for (int i = 0; i < arr2d.GetLength(0); i++)
                for (int j = 0; j < arr2d.GetLength(1); j++)
                    if (arr2d[i, j] == 2) rs.Add((i, j));

            return rs;
        }
        static void ShowMatrix(int[,] matrx) {

            for (int r = 0; r < matrx.GetLength(0); r++) {
                for (int c = 0; c < matrx.GetLength(0); c++) {

                    if (matrx[r, c] == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (matrx[r, c] == 2) Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (matrx[r, c] == 0) Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(matrx[r, c]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }

}
