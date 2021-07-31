using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ValidParentesis {
    class Program {
        static void Main(string[] args) {
            string ps = "(({{{}}})[])";

            bool res = SolutionReg(ps);

            Console.WriteLine(res);
        }

        private static bool Solution(string s) {
            Stack b = new Stack();
            foreach (char p in s) {
                if (p == '{' || p == '(' || p == '[') b.Push(p);
                else {
                    if (b.Count == 0) return false;
                    var poped = (char)b.Pop();
                    if (Math.Abs(p - poped) > 2) return false;
                }
            }
            return b.Count == 0;
        }

        private static bool SolutionReg(string s){ var z = Regex.Replace(s, @"\[\]|\{\}|\(\)", ""); return z == s ? z.Length == 0 : Solution(z);  }
    }
}
