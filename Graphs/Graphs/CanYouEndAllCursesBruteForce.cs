using System.Collections.Generic;

namespace Graphs {
    static class CanYouEndAllCursesBruteForce {
        static public bool Solve(int[,] prq, int n) {
            var adjl = new List<List<int>>();

            for (int i = 0; i < n; i++)
                adjl.Add(new());

            for (int i = 0; i < prq.GetLength(0); i++)
                adjl[prq[i, 1]].Add(prq[i, 0]);
           

            var seen = new HashSet<int>();

            for (int i = 0; i < n; i++)
                if (!TraverseBFS(adjl, i)) return false;

            return true;
        }

        private static bool TraverseBFS(List<List<int>> adjl, int v) {
            var q = new Queue<int>();
            var seen = new HashSet<int>();

            adjl[v].ForEach(n => { if (!seen.Contains(n)) q.Enqueue(n); });

            while (q.Count > 0) {
                var curr = q.Dequeue();
                seen.Add(curr);

                if (curr == v) return false;

                adjl[curr].ForEach(n => { if (!seen.Contains(n)) q.Enqueue(n); });
            }

            return true;
        }
    }

}
