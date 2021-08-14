using System;
using System.Linq;
using System.Collections.Generic;

namespace Graphs {
    class Program {
        static void Main(string[] args) {
            var graph_adj = new int[9][] {
                new int[] { 1, 3 },
                new int[] { 0 },
                new int[] { 3, 8 },
                new int[] {0, 2, 4, 5 },
                new int[] { 3, 6 },
                new int[] { 3 },
                new int[] { 4, 7 },
                new int[] { 6 },
                new int[] { 2 } };

            var res = BFS.Traverse(graph_adj);
            Console.WriteLine(string.Join(" ", res));

            var res2 = DFS.Traverse(graph_adj, new(), new(), 0);
            Console.WriteLine(string.Join(" ", res2));

            //Time to inform all employ

            var managerlist = new int[] { 2, 2, 4, 6, -1, 4, 4, 5 };
            var time = new int[] { 0, 0, 4, 0, 7, 3, 6, 0 };

            var res3 = TimeToInformAllEmp.Solve(managerlist, time);

            Console.WriteLine($"You need spend {res3} minutes to inform all staff");


            //scheduler task

            var prereq = new int[,] { { 1, 0 }, { 2, 1 }, { 2, 5 }, { 0, 3 }, { 4, 3 }, { 3, 5 }, { 4, 5 } };//6
            var prereq2 = new int[,] { { 1, 0 }, { 2, 1 }, { 0, 3 }, { 4, 5 }, { 5, 6 }, { 6, 4 } }; //7

            var result = CanYouEndAllCursesBruteForce.Solve(prereq, 6);

            Console.WriteLine("Can you end this course: " + result);
            var adjsimple = new int[][] {
                new int[]{3 },
                new int[]{ },
                new int[]{3 },
                new int[]{  },
                new int[]{0,1 },
                new int[]{0 }
            };
            var adjsimple2 = new int[][] {
                new int[]{ 1 },
                new int[]{ 2 },
                new int[]{   },
                new int[]{ 0, 4 },
                new int[]{ },
                new int[]{ 2, 3, 4 }
            };

            TopologicalSort.Sort(adjsimple);




            //graph of network
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nGraph travers time:\n");
            Console.ResetColor();
            var times_array = new int[8, 3] { { 1, 2, 9 }, { 1, 4, 2 }, { 2, 5, 1 },
                { 4, 2, 4 }, { 4, 5, 6 }, { 3, 2, 3 }, { 5, 3, 7 }, { 3, 1, 5 } }; 

            var times_array2 = new int[8, 3] { { 1, 2, 9 }, { 3,2,3 }, { 5,3,7 },
                { 3,1,5 }, { 2, 5, -3 }, { 4, 5, 6}, { 1, 4, 2 }, { 4, 2, -4 } };

            TimeToTraverseAllGraph.Solve(times_array2);
        }
    }
    class Vertex {
        public int Node { get; set; }
        public List<int> Childs { get; set; } = new();
        public List<int> Weights { get; set; } = new();
    }
    static class TimeToTraverseAllGraph {
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
