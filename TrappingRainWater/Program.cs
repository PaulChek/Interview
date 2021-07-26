using System;

namespace TrappingRainWater {
    class Program {
        static void Main(string[] args) {
            var arr = new int[] { 4, 2, 0, 3, 2, 5 };
            Console.WriteLine(Solution(arr));
            Console.WriteLine(BestSolution(arr));
        }

        private static int BestSolution(int[] arr) {
            int S = 0, maxL = 0, maxR = 0, pL = 0, pR = arr.Length-1;
            while (pL < pR ) {
                if (arr[pL] < arr[pR]) {
                    if (maxL > arr[pL]) S += maxL - arr[pL];
                    else maxL = arr[pL];
                    pL++;
                }
                else {
                    if (maxR > arr[pR]) S += maxR - arr[pR];
                    else maxR = arr[pR];
                    pR--;
                }
            }

            return S;
        }

        private static int Solution(int[] arr) {
            int s = 0,
               maxLh = 0,
               maxRh = 0;


            for (int p = 0; p < arr.Length; p++) {
                var l = p - 1; var r = p + 1;


                while (l >= 0)
                    maxLh = Math.Max(maxLh, arr[l--]);


                while (r < arr.Length)
                    maxRh = Math.Max(maxRh, arr[r++]);



                var habove = Math.Min(maxLh, maxRh) - arr[p];

                s += habove < 0 ? 0 : habove;

                maxLh = 0; maxRh = 0;
            }

            return s;
        }
    }
}
