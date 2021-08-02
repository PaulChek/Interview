using System;

namespace Rec {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(FindFactorialTailRecursion(4));
        }
        static int FindFactorial(int n) => _ = n < 2 ? 1 : FindFactorial(n - 1) * n; //recursion space O(n)
        static int FindFactorialTailRecursion(int n, int res = 1) => _ = n == 0 ? res : FindFactorialTailRecursion(n - 1, res * n); //rec space O(1)
    }
}
