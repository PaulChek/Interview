using System;

namespace QuickSort {
    class Program {
        static void Main(string[] args) {
            var arr = new int[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };

            Console.WriteLine(string.Join(" ", arr));




            //Console.WriteLine(FindKth.BiggestElement(arr, 3));

            Console.WriteLine(QuickSelect(arr, 3));

            Console.WriteLine(string.Join(" ", arr));

        }
        static int MovePivot(int[] arr, int start, int end) {
            var p = start; // choose First by default
            for (int i = p + 1; i < end; i++)
                if (arr[p] > arr[i]) {
                    (arr[p + 1], arr[i]) = (arr[i], arr[p + 1]);
                    (arr[p], arr[p + 1]) = (arr[p + 1], arr[p]);
                    p++;
                }
            return p;
        }
        static int MovePivot2(int[] arr, int start, int end) {
            int i = start, j = i;

            while (j < end)
                if (arr[end - 1] > arr[j]) { (arr[i], arr[j]) = (arr[j], arr[i]); i++; j++; }
                else j++;

            (arr[i], arr[end - 1]) = (arr[end - 1], arr[i]);

            return i;
        }

        public static void QuickSort(int[] arr, int start, int end, int k = 0) { // k modified for k-th biggest element
            if (start == end) return;

            var p = MovePivot2(arr, start, end);

            QuickSort(arr, p + 1, end); //right part

            QuickSort(arr, start, p); //left part of array

        }
        static int QuickSelect(int[] arr, int k) => QuickSelect(arr, 0, arr.Length, arr.Length - k);
        static int QuickSelect(int[] arr, int start, int end, int k) {
            int i = start; int j = i;

            while (j < end)
                if (arr[end - 1] > arr[j]) { (arr[i], arr[j]) = (arr[j], arr[i]); i++; j++; }
                else j++;

            (arr[i], arr[end - 1]) = (arr[end - 1], arr[i]);

            if (i == k) return arr[i];
            if (i < k) return QuickSelect(arr, i + 1, end, k);
            else return QuickSelect(arr, start, i, k);


        }
    }
}
