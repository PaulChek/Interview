using System;
using System.Collections.Generic;

namespace Graphs {
    static class TopologicalSort {
        class Vertex {
            public int name { get; set; }
            public List<int> Childs { get; set; } = new List<int>();
            public int Degree { get; set; } = 0;
        }
        static public void Sort(int[][] adjsmpl) {
            var adj = new Dictionary<int, Vertex>();

            var toporder = new List<int>();
            //convert ot dictionary
            for (int i = 0; i < adjsmpl.Length; i++) {
                var vertx = new Vertex();
                vertx.Childs.AddRange(adjsmpl[i]);
                vertx.name = i;
                adj.Add(i, vertx);
            }
            //make degree
            foreach (var item in adj)
                item.Value.Childs.ForEach(v => adj[v].Degree++);

            var stack = new Stack<Vertex>();

            foreach (var item in adj)
                if (item.Value.Degree == 0)
                    stack.Push(item.Value);


            var count = 0;

            while (stack.Count > 0) {
                var curr = stack.Pop();
                count++;
                toporder.Add(curr.name);
                curr.Childs.ForEach(c => {
                    adj[c].Degree--;
                    if (adj[c].Degree == 0) stack.Push(adj[c]);
                });
            }


            Console.WriteLine(string.Join(" ", toporder));


            if (count != adjsmpl.Length) Console.WriteLine("Cycle Detected");

        }
    }
}
