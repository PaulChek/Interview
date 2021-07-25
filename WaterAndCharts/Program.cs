using System;
using System.Collections.Generic;
/*
[1,8,6,2,9,4]
find  biggest container!
^
|               
|              |
|     |        |
|     |        |
|     |  |     |
|     |  |     |    
|     |  |     |  |
|     |  |     |  |
|     |  |  |  |  |
|__|__|__|__|__|__|___>
   1  8  6  2  9  4
*/
namespace WaterAndCharts {
    class Program {
        static void Main(string[] args) {
            var bars = new int[] { 6, 9, 3, 4, 5, 8 };
            Console.WriteLine(string.Join("\n", OptimizeSolution(bars)));

        }

        static int OptimizeSolution(int[] arr) {
            //shifting pointers area = min(a,b) * (bj - ai);
            var max = 0;

            for (int i = 0, j = arr.Length - 1; j > i;)
                if (arr[i] < arr[j]) { max = Math.Max(max, arr[i] * (j - i)); i++; }
                else { max = Math.Max(max, arr[j] * (j - i)); j--; };



            return max;
        }

        static int BruteSolution(int[] arr) {
            var v = 0;
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    v = Math.Max(v, Math.Min(arr[i], arr[j]) * (j - i));

            return v;
        }
    }
}
