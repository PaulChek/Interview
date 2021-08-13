using System;
using System.Collections.Generic;

namespace Graphs {
    static class DFS {
        public static List<int> Traverse(int[][] adjL, HashSet<int> seen, List<int> res, int vertex = 0) {
            if (seen.Contains(vertex)) return res;

            seen.Add(vertex);
            res.Add(vertex);

            Array.ForEach(adjL[vertex], v => Traverse(adjL, seen, res, v));

            return res;
        }

    }
}
