using System;
using System.Text.RegularExpressions;

namespace AlmostPalindrome {
    class Program {
        static void Main(string[] args) {
            var arrs = new (string, bool)[]{
            ( "aaddaa", true ),
            ( "aadgdaa", true ),
            ("a", true),
            ("abb", true),
            ("abbbc", false),
            ("aaaaba", true),
            ("abaaba", true),
            ("eedede", true), //*
            ("abcba", true),
            ("", true),
            ("a man, a plan, a canal, panama", true),
            ("cdbeeeabddddbaeedebdc",true)
            };

            foreach (var s in arrs)
                Console.WriteLine(s.Item2 == IsAlmostPalindrome(s.Item1) ? 'V' : 'X');





        }
        private static bool IsAlmostPalindrome(string s, int secondChance = 0, int pL = 0, int pR = 0) {

            if (secondChance > 1) return false;

            pR = pR == 0 ? s.Length - 1 : pR;

            while (pL <= pR) {
                if (s[pL] != s[pR])
                    return IsAlmostPalindrome(s, secondChance + 1, pL + 1, pR) || IsAlmostPalindrome(s, secondChance + 1, pL, pR - 1);
                pL++;
                pR--;
            }

            return true;

        }
    }
}
