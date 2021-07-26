using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TypedOutStrings {
    class Program {
        static void Main(string[] args) {
            string s1 = "nzp#o#g";
            string s2 = "b#nzp#o#g";

            Console.WriteLine(Solution(s1, s2));
        }

        private static bool Solution(string s1, string s2) {
            int p1 = s1.Length - 1, p2 = s2.Length - 1;
            int hash_acc2 = 0, hash_acc1 = 0;
           
            while(p2 >= 0 || p1>=0 ) {
                while (p2>=0) {
                    if ( s2[p2] != '#') 
                        if (hash_acc2 > 0) hash_acc2--;
                        else break;
                    else hash_acc2++;
                    p2--;
                }  

                while (p1>=0) {
                    if ( s1[p1] != '#') 
                        if (hash_acc1 > 0) hash_acc1--;
                        else break;
                    else hash_acc1++;
                    p1--;
                }

                

                if(p2>=0 && p1>=0 && s2[p2] != s1[p1]) return false;

                p2--;p1--;
            }
            Console.WriteLine((p1,p2));
          

            return p1==p2;

        }

        private static string RemHsh(string s) {
            var res2 = new List<char>();
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '#') { if (res2.Count - 1 >= 0) res2.RemoveAt(res2.Count - 1); continue; }
                res2.Add(s[i]);
            }
            return string.Join('\0', res2);
        }

    }

}
