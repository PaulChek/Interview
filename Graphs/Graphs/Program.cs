using System;

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
                { 3, 1, 5 }, { 2, 5, -3 }, { 4, 5, 6}, { 1, 4, 2 }, { 4, 2, -4 } };

            TimeToTraverseAllGraph.Solve(times_array2);
        }
    }
}
