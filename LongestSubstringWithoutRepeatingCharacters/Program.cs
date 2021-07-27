using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingCharacters {
    class Program {
        static void Main(string[] args) {
            string s1 = "abcbda";
            Console.WriteLine(SlidingWindowSolution(s1));


        }

        private static int SlidingWindowSolution(string s1) {
            int L = 0, R = 0; int max = 1;
            var seen = new Dictionary<char, int>();

            while (R < s1.Length) {
                if (!seen.ContainsKey(s1[R]) || seen[s1[R]] < L) {
                    if (seen.ContainsKey(s1[R])) seen[s1[R]] = R;
                    else seen.Add(s1[R], R);
                    max = Math.Max(max, R - L + 1);
                    R++;
                }
                else {
                    L = seen[s1[R]] + 1;


                    seen[s1[R]] = R;
                    R++;
                }
            }

            return max;
        }



        private static int BruteForce(string s1) {

            if (string.IsNullOrEmpty(s1)) return 0;
            int max = 1;
            HashSet<char> was_before = new HashSet<char>();


            for (int i = 0; i < s1.Length; i++)
                for (int j = i; j < s1.Length; j++) {
                    if (!was_before.Contains(s1[j])) was_before.Add(s1[j]);
                    else {
                        max = Math.Max(max, was_before.Count);
                        was_before.Clear();
                        break;
                    }
                }

            return max;
        }
    }
}
