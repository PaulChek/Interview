using System;
using System.Collections.Generic;

namespace Graphs {
    static class TimeToInformAllEmp {


        public static int Solve(int[] managers, int[] time) {
            int head = -1;

            var adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < managers.Length; i++)//convert to adj list
                if (managers[i] != -1)
                    if (adjList.ContainsKey(managers[i]))
                        adjList[managers[i]].Add(i);
                    else adjList.Add(managers[i], new() { i });
                else head = i;


            int res = CountMinutesDFS(adjList, time, head, new HashSet<int>(), 0);


            return res;
        }

        private static int CountMinutesDFS(Dictionary<int, List<int>> adjList, int[] time, int id, HashSet<int> seen, int minutes) {

            // if (seen.Contains(id)) return minutes; // cuz one employ cant have two manager, in this task!

            seen.Add(id);

            minutes = minutes + time[id];
            int tmp = 0;

            if (adjList.ContainsKey(id))
                adjList[id].ForEach(i => tmp = CountMinutesDFS(adjList, time, i, seen, minutes));

            return Math.Max(tmp, minutes);
        }


        public static void ShowGraph(Dictionary<int, List<int>> adjList) {
            foreach (var item in adjList) {
                Console.WriteLine(item.Key + ":[ " + string.Join(", ", item.Value) + " ]");
            }
        }
    }
}
