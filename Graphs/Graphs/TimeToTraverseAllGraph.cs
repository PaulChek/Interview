using System;
using System.Linq;
using System.Collections.Generic;

namespace Graphs {
    static class TimeToTraverseAllGraph {
    class Vertex {
        public int Node { get; set; }
        public List<int> Childs { get; set; } = new();
        public List<int> Weights { get; set; } = new();
    }
        static public void Solve(int[,] arr) {
            var adj = new Dictionary<int, Vertex>();
            int start = 1;
            int end = 3;
            for (int i = 0; i < arr.GetLength(0); i++) {
                (int n, int c, int w) = (arr[i, 0], arr[i, 1], arr[i, 2]);
                var v = adj.ContainsKey(n) ? adj[n] : new Vertex();
                v.Childs.Add(c);
                v.Node = n;
                v.Weights.Add(w);
                adj[n] = v;
            }

            var timeTable = new Dictionary<int, int>();
            var pathTable = new Dictionary<int, int>();
            var seen = new HashSet<int>();

            //foreach (var item in adj)
            //    if (start == item.Key) timeTable[item.Key] = 0;
            //    else timeTable[item.Key] = int.MaxValue;

            // FillTimeTableDfs(adj,  seen, timeTable, pathTable );


            //Console.WriteLine("Time:");
            //foreach (var item in timeTable)
            //    Console.WriteLine(item);

            //Console.WriteLine("Path:");
            //foreach (var item in pathTable)
            //    Console.WriteLine(item);


            BelManFordAlgorithm(adj, start, arr);

            //Console.WriteLine("(" + item.Key + $") c:[{string.Join(", ", item.Value.Childs)}] w:[{string.Join(", ", item.Value.Weights)}]");

        }

        private static void FillTimeTableDijksta(Dictionary<int, Vertex> adj,  HashSet<int> seen, Dictionary<int, int> timeTable, Dictionary<int, int> pathTable) {
            //took smallest time int timeTable
            
            (int curr_val, _) =  timeTable.Where(v => !seen.Contains(v.Key)).OrderBy(v=>v.Value).FirstOrDefault(); // or use priority Queue
            if (curr_val == 0) return;
            seen.Add(curr_val);
            
            //travers via his childs
            int i = 0;
            
            adj[curr_val].Childs.ForEach(c => {
                var curT = timeTable[c];
                timeTable[c] = Math.Min(timeTable[c], adj[curr_val].Weights[i] + timeTable[curr_val]);
                if (curT != timeTable[c]) pathTable[c] = curr_val;
                i++;
            });
             
            FillTimeTableDijksta(adj, seen, timeTable, pathTable);
        }

        private static void BelManFordAlgorithm(Dictionary<int, Vertex> adj, int start, int[,] arr) {
            var timeTable = new Dictionary<int, int>();
            foreach (var item in adj) 
                if (item.Key == start) timeTable[item.Key] = 0;
                else timeTable[item.Key] = 9999999;

            var iterations = timeTable.Count;
            bool changed = true;

            while (iterations>0 && changed) {
                var countChanges = 0;
                for (int i = 0; i < arr.GetLength(0); i++) {
                    (int n, int c, int w) = (arr[i,0], arr[i,1], arr[i,2]);
                    var prevTime = timeTable[c];
                    timeTable[c] = Math.Min(timeTable[c], w + timeTable[n]);
                    if (prevTime != timeTable[c]) countChanges++;
                }
                if (countChanges == 0) changed = false; 
                iterations--;
            }
            
            
            foreach (var item in timeTable)
                Console.WriteLine(item);

        }
    }
}
