using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rec {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine(FindFactorialTailRecursion(4));
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 123, 222, 333, 444, 555, 666, 777 };

            //int[] posibleSteps = new int[] { 2, 4, 5, 8 };

            //var res = BinarySearch(arr, 0, arr.Length - 1, 777);
            //Console.WriteLine(res);

            //var posRes =  Possibilities(posibleSteps, 10);
            //  var str = "FB(TAIHJK(NZZCGDZXKF(SYMBLACQ)SBJMRFM)PRTRX(JCLYCOXIMOKGGIE)MWIOIJDCLXDSQFHK)WLVYSMNNHIGKR(MOIZLOT(RWMAVXSJQROHJ(GZURPPOQJVMYCE(VCPXSHXQ)LETIEWE(CBC)AAHEEO)NZHIGXBSJATXV)BSBYCMKFFAFZIK(KECNRQ)PIIQZGIDMLNQRQS)VGXXBYD";

            //var coord =  FindDepth(str);

            //  Console.WriteLine(string.Join( " ", coord));

            string[] s = new[] { "turns", "out", "random", "test", "cases", "are", "easier", "than", "writing", "out", "basic", "ones" };
            Array.Sort(s, (a, b) => a.Aggregate(0,(a,b)=>a+b) > b.Aggregate(0, (a, b) => a + b)?1:-1);
           

            var ns = Regex.Replace(s[0], @"\w(?=[^$])", "$&***");
            Console.WriteLine(ns);
        }

        private static IEnumerable<string> FindDepth(string s) {
            var res = new List<(int, int, int)>();
            int cDepth = 0, max = 0; (int d, int l, int r) c = (0, 0, 0);
            for (int i = 0; i < s.Length; i++) {
                max = Math.Max(cDepth, max);
                if (s[i] == '(') { cDepth++; c.d = cDepth; c.l = i; };
                if (s[i] == ')') {
                    cDepth--;
                    c.r = i;
                    if (cDepth + 1 == max) res.Add(c);
                }
            }
            return res.Where(v => v.Item1 == max).Select(v => s.Substring(v.Item2 + 1, v.Item3 - v.Item2 - 1)).ToList();
        }

        private static int Possibilities(int[] posibleSteps, int stairs) {
            if (stairs == 0) return 1;
            if (stairs < 0) return 0;
            int res = 0;
            foreach (var step in posibleSteps) {
                res += Possibilities(posibleSteps, stairs - step);
            }
            return res;
        }

        static int BinarySearch(int[] arr, int l, int r, int v) {

            int m = (l + r) / 2;

            if (l > r) return -1;
            if (arr[m] == v) return m;

            if (arr[m] < v) return BinarySearch(arr, m + 1, r, v);
            else return BinarySearch(arr, l, m - 1, v);
        }

        static int FindFactorial(int n) => _ = n < 2 ? 1 : FindFactorial(n - 1) * n; //recursion space O(n)
        static int FindFactorialTailRecursion(int n, int res = 1) => _ = n == 0 ? res : FindFactorialTailRecursion(n - 1, res * n); //rec space O(1)
    }
}
