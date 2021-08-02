namespace QuickSort {
    class FindKth {
       public static int BiggestElement(int[] arr, int k) {
            Program.QuickSort(arr, 0, arr.Length, arr.Length - k);
            return arr[arr.Length - k];
        }
    }
}
