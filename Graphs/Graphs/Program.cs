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




        }
    }
}
