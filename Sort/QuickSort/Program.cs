﻿using System;

namespace QuickSort {
    class Program {
        static void Main(string[] args) {
            var arr = new int[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };

            Console.WriteLine(string.Join(" ", arr));

            QuickSort(arr, 0, arr.Length);

            Console.WriteLine(string.Join(" ", arr));
        }
        static int MovePivot(int[] arr, int start, int end) {
            var p = start;
            for (int i = p + 1; i < end; i++)
                if (arr[p] > arr[i]) {
                    (arr[p + 1], arr[i]) = (arr[i], arr[p + 1]);
                    (arr[p], arr[p + 1]) = (arr[p + 1], arr[p]);
                    p++;
                }
            return p;
        }

        static void QuickSort(int[] arr, int start, int end) {
            if (start == end) return;
            var p = MovePivot(arr, start, end);
            QuickSort(arr, p + 1, end);
            QuickSort(arr, start, p);

        }
    }
}
