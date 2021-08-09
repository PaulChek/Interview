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
            List<int> flat = FlatArray(arr2d);

            List<int> flat2 = FlatArray2(arr2d);



            //solving task about steps
            var steps = SolveTaskWithShortestPathIn2dArray.AmountOfSteps(arr2d);

            Console.WriteLine(string.Join(" ", steps));
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
}
