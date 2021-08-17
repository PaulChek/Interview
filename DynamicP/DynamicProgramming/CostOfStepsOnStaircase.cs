using System;

namespace DynamicProgramming {
    static class CostOfStepsOnStaircase {
        public static int SolveRecursion(int[] dt, int[] cost) {
            var res = Recursion(cost, cost.Length - 1, dt);


            Console.WriteLine(res);
            Console.WriteLine("hash:" + string.Join(" ", dt));
            return res;
        }
        public static int SolveIterative(int[] dt, int[] cost) {

            dt[0] = cost[0];
            dt[1] = cost[1]; //cuz i can take 1 or two steps

            int i = 2;

            while (i < cost.Length) {
                dt[i] = cost[i] + Math.Min(dt[i - 1], dt[i - 2]);
                i++;
            }

            Console.WriteLine("hash:" + string.Join(" ", dt));

            return dt[dt.Length - 1];
        }

        private static int Recursion(int[] cost, int i, int[] dt) {
            if (i < 0) return 0;
            if (dt[i] != 0) return dt[i];

            dt[i] = cost[i] + Math.Min(Recursion(cost, i - 1, dt), Recursion(cost, i - 2, dt));

            return dt[i];
        }
    }
}
