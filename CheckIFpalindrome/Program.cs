using System;
using System.Text.RegularExpressions;

namespace CheckIFpalindrome {
    class Program {
        static void Main(string[] args) {
            var arrs = new (string, bool)[]{
            ( "aaddaa", true ),
            ( "aadGdaa", true ),
            ("a", true),
            ("abc", false),
            ("aaaaba", false),
            ("abaaba", true),
            ("abcba", true),
            ("", true),
            ("eedede", true),
            ("A man, a plan, a canal, Panama", true)
            };
            foreach (var s in arrs)
                Console.WriteLine(s.Item2 == IsPalindrome2(s.Item1));

        }

        private static bool IsPalindrome1(string s) {
            s = ClearString(s);
            int pL = 0, pR = s.Length - 1;

            while (pL <= pR)
                if (s[pL++] != s[pR--]) return false;

            return true;
        }        
        private static bool IsPalindrome2(string s) {
            s = ClearString(s);
            if (s.Length <= 1) return true;
            
            int start = s.Length / 2;
            int pL = start - 1, pR = start + ((s.Length&1)==1?1:0);

            while (pL>=0 && pR < s.Length) 
                if (s[pL--] != s[pR++]) return false;
            
            return true;

        }

        private static string ClearString(string s) {
            return Regex.Replace(s, @"[^\w]", "").ToLower();
        }
    }
}
