using System;
using System.Collections.Generic;

namespace Graphs {
    static class BFS {
        public static List<int> Traverse(int[][] adj_graph) {
            var res = new List<int>();
            var seen = new HashSet<int>();
            var q = new Queue<int>();
            seen.Add(0);
            q.Enqueue(0);


            while (q.Count > 0) {
                var v = q.Dequeue();
                res.Add(v);
                seen.Add(v);
                Array.ForEach(adj_graph[v], n => {
                    if (!seen.Contains(n)) q.Enqueue(n);
                });
            }



            return res;
        }

    }
}
