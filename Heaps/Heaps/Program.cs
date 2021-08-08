using System;
using System.Collections.Generic;
using System.Linq;

namespace Heaps {
    class Program {
        static void Main(string[] args) {
            var heap = new MaxHeap();
            heap.Add(50);
            heap.Add(40);
            heap.Add(25);
            heap.Add(20);
            heap.Add(35);
            heap.Add(10);
            heap.Add(15);
            heap.Add(45);
            heap.Add(75);



            Console.WriteLine(string.Join(" ", heap.PriorityQueue));


            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());


            //Console.WriteLine(string.Join(" ", heap.PriorityQueue));

        }
    }

    class MaxHeap {
        public MaxHeap() {
            PriorityQueue = new();
        }

        public List<int> PriorityQueue { get; set; }

        public int Add(int data) {
            PriorityQueue.Add(data);
            int ChildIndex = PriorityQueue.Count - 1;
            int ParentIndex = -1;
            if (ChildIndex == 0) return ChildIndex;


            while (ParentIndex != 0 && data > PriorityQueue[ParentIndex = (ChildIndex - 1) / 2]) {
                PriorityQueue[ChildIndex] = PriorityQueue[ParentIndex];
                ChildIndex = ParentIndex;
            }

            PriorityQueue[ChildIndex] = data;

            return ChildIndex;
        }

        public int? Dequeue() {

            if (PriorityQueue.Count == 0) return null;

            var res = PriorityQueue[0];

            PriorityQueue[0] = PriorityQueue[PriorityQueue.Count - 1];

            PriorityQueue.RemoveAt(PriorityQueue.Count - 1);

            if (PriorityQueue.Count == 0) return res;

            int curr = PriorityQueue[0];
            int p = 0, lc = -1, rc = -1;

            while ((p * 2 + 1 < PriorityQueue.Count && curr < PriorityQueue[lc = 2 * p + 1]) | (p * 2 + 2 < PriorityQueue.Count && curr < PriorityQueue[rc = 2 * p + 2])) {
                if (PriorityQueue[lc] > PriorityQueue[rc]) { PriorityQueue[p] = PriorityQueue[lc]; p = lc; }
                else { PriorityQueue[p] = PriorityQueue[rc]; p = rc; }
            }
            PriorityQueue[p] = curr;
            return res;
        }
    }
}
