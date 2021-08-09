using System.Collections.Generic;

namespace _2d_Arrays {
    static class SolveTaskWithShortestPathIn2dArray {
        public static List<int> AmountOfSteps(int[,] arr2d) {

            List<(int r, int c)> starts = FindStartsPoints(arr2d);

            List<int> res = new();

            starts.ForEach(s => res.Add(FindPathLength(arr2d, s)));



            return res;
        }

        private static int FindPathLength(int[,] arr2d, (int r, int c) p) {
            bool[,] seen = new bool[arr2d.GetLength(0), arr2d.GetLength(1)];

            (int r, int c, int s) pointer = (p.r, p.c, 0);

            var queue = new Queue<(int r, int c, int d)>();

            queue.Enqueue(pointer);


            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                if (arr2d[cur.r, cur.c] == 1) return cur.d;

                /*up*/
                if (isValid((cur.r - 1, cur.c, cur.d), seen, arr2d)) {
                    seen[cur.r, cur.c] = true; queue.Enqueue((cur.r - 1, cur.c, cur.d + 1));
                }

                /*right*/
                if (isValid((cur.r, cur.c + 1, cur.d), seen, arr2d)) {
                    seen[cur.r, cur.c] = true; queue.Enqueue((cur.r, cur.c + 1, cur.d + 1));
                }
                /*down*/
                if (isValid((cur.r + 1, cur.c, cur.d), seen, arr2d)) {
                    seen[cur.r, cur.c] = true; queue.Enqueue((cur.r + 1, cur.c, cur.d + 1));
                }
                /*left*/
                if (isValid((cur.r, cur.c - 1, cur.d), seen, arr2d)) {
                    seen[cur.r, cur.c] = true; queue.Enqueue((cur.r, cur.c - 1, cur.d + 1));
                }
            }


            return -1;
        }

        private static bool isValid((int r, int c, int d) cur, bool[,] seen, int[,] arr2d) {
            if (cur.c < 0 || cur.r < 0 || cur.c >= arr2d.GetLength(1)
                || cur.r >= arr2d.GetLength(0) || arr2d[cur.r, cur.c] == 3 || seen[cur.r, cur.c])
                return false;

            return true;
        }

        private static List<(int r, int c)> FindStartsPoints(int[,] arr2d) {
            List<(int r, int c)> res = new();
            for (int r = 0; r < arr2d.GetLength(0); r++)
                for (int c = 0; c < arr2d.GetLength(1); c++)
                    if (arr2d[r, c] == 2) res.Add((r, c));

            return res;
        }
    }
}
