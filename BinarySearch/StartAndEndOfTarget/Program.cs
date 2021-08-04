using System;
using System.Collections.Generic;
using System.Linq;

namespace StartAndEndOfTarget {
    class Program {
        static void Main(string[] args) {
            var arr = new int[] { 1,2,3,4,5 };
            //Array.Fill(arr, 5);
            
            int[] res = new int[2] { 999, -1 };
            FindRange(arr, 5, res);
            Console.WriteLine(string.Join(" ", res));
        }

        static void FindRange(int[] arr, int val, int[] res, int skip = 0) {

            var tmpC = BinarySearch(arr, val);

            if (tmpC != -1) { res[0] = Math.Min(res[0], tmpC + skip); res[1] = Math.Max(res[1], tmpC + skip); }
            else return;

            FindRange(arr.Take(tmpC).ToArray(), val, res);
            FindRange(arr.Skip(tmpC + 1).ToArray(), val, res, tmpC + 1);
        }

        private static int BinarySearch(int[] arr, int val) {
            int start = 0,
                end = arr.Length,
                m = FindMiddle(start, end);

            while (m <= end - 1) {
                if (arr[m] == val) return m;
                if (arr[m] < val) { start = m + 1; m = FindMiddle(start, end); }
                else { end = m - 1; m = FindMiddle(start, end); }

            }
            return -1;
        }

        private static int FindMiddle(int start, int end) {
            return (start + end) / 2;
        }
    }
}
