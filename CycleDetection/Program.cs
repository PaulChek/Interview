using System;
using System.Collections.Generic;

namespace CycleDetection {
    class Program {
        static void Main(string[] args) {
            var list = new LList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            var _3 = list.Add(3);
            list.Add(4);
            list.Add(5);
            var tail = list.Add(6);

            tail.Next = _3; //create cycle

          


            var cycle = list.CycleDetectFloyd();
            Console.WriteLine(cycle.Data);

            //list.Print();
        }
    }
    class Node {
        public Node(int data, Node next = null) {
            Next = next;
            Data = data;
        }

        public Node Next { get; set; }
        public int Data { get; set; }
    }

    class LList {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public Node Add(int data) => Add(new Node(data));

        private Node Add(Node node) {
            if (Head == null) { Head = node; Tail = node; return node; }
            Tail.Next = node;
            Tail = node;
            return node;
        }
        public Node CycleDetect() {
            var hs = new HashSet<Node>();
            return CycleDetect(Head, hs);
        }

        private Node CycleDetect(Node head, HashSet<Node> hs) {
            if (head.Next != null && hs.Contains(head.Next)) return head;
            hs.Add(head);
            var res = CycleDetect(head.Next, hs);
            return res;
        }
        public Node CycleDetectFloyd() => CycleDetectFloyd(Head);

        private Node CycleDetectFloyd(Node head) {
            var t = head; var h = head;
            while (t != null && h != null) {
                t = t.Next;

                if (h.Next != null) h = h.Next.Next;
                else break;


                if (t == h) {
                    t = head;
                    while (t != h) {
                        h = h.Next;
                        t = t.Next;
                    }
                    return t;
                }
            }

 
            return null;
        }

        public void Print() => Print(Head);

        private void Print(Node head) {
            if (head == null) return;
            Console.WriteLine(head.Data);
            Print(head.Next);
        }
    }
}
