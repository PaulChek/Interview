using System;
using System.Collections.Generic;
using System.Threading;

namespace _2d_Arrays {
    static class RottingOranges {
        public static int Solve(int[,] arr2d) {
            var q = new Queue<(int r, int c)>();

            List<(int r, int c)> rotten = FindAllRottenOranges(arr2d);


            rotten.ForEach(r => q.Enqueue(r));

            var res = DestroyOranges(q, arr2d);


            return res;
        }

        static int DestroyOranges(Queue<(int r, int c)> q, int[,] arr2d, int res = 0) {
            Thread.Sleep(700);
            if (q.Count == 0) return res;
            Console.Clear();
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
                || p.j >= arr.GetLength(1) || p.j < 0
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
        public static void ShowMatrix(int[,] matrx) {

            for (int r = 0; r < matrx.GetLength(0); r++) {
                for (int c = 0; c < matrx.GetLength(1); c++) {

                    if (matrx[r, c] == 1) Console.ForegroundColor = ConsoleColor.Yellow;
                    if (matrx[r, c] == 2) Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (matrx[r, c] == 0) Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(matrx[r, c]<0?"| ":matrx[r,c]== 0?"* ": matrx[r, c] +" ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }

}
