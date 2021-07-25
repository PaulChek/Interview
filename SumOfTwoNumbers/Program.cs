using System;
using System.Collections.Generic;
/*
given array [1,3,7,9,2]
find summ of 11 => (3,4)
*/
namespace SumOfTwoNumbers {
    class Program {
        static void Main(string[] args) {
            var summ = 11;
            var arr = new int[] { 1, 3, 7, 9, 2 };

            Console.WriteLine(Solution(arr, summ));
        }
        static (int, int) Solution(int[] arr, int summ) {
            //using hashmapping
            var hash = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++) {
                var looking_for = summ - arr[i];
                if (hash.ContainsKey(looking_for)) return (hash[looking_for], i);
                hash[arr[i]] = i;
            }

            return (-1, -1);
        }
        static  (int, int) BadSolution(int[] arr, int summ) {
            var (p1, p2) = (0,1);

            for (; p1<arr.Length;) {
                if (p2 >= arr.Length) { ++p1; p2 = p1 + 1; }
                var target = summ - arr[p1];
                if (target == arr[p2]) return (p1, p2);
                p2++;
            }

            return (-1, -1);
        }
    }
}
