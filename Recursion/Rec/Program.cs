using System;

namespace Rec {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(FindFactorial(4));
        }
        static int FindFactorial(int n) => _ = n == 0 ? 1 : FindFactorial(n - 1) * n;
    }
}
