using System;

namespace LinkedList {
    class Program {
        static void Main(string[] args) {
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);




            list.ReverseListBetweeNodes(2, 5);
            list.Add(9999);
         
            var tmp2 = list.Head;
            while (tmp2 != null) {
                Console.Write(tmp2.Data);
                tmp2 = tmp2.Next;
            }
        }
    }
    class List<T> where T : IComparable {
        public class Node {
            public Node(T data, Node next = null) {
                Data = data;
                Next = next;
            }
            public T Data { get; set; }
            public Node Next { get; set; }
        }


        public Node Head { get; set; } = null;
        public Node Tail { get; set; } = null;

        public void Add(T data) => Add(new Node(data));
        public void Append(T data) => Append(new Node(data));

        private void Append(Node node) {
            if (Head == null && Tail == null) { Head = node; Tail = node; }
            else {
                node.Next = Head;
                Head = node;
            }
        }

        private void Add(Node node) {
            if (Head == null && Tail == null) { Head = node; Tail = node; }
            else {
                Tail.Next = node;
                Tail = Tail.Next;
            }
        }
        public void ReversePrint() => ReversePrint(Head);

        private void ReversePrint(Node head) {
            if (head == null) return;
            ReversePrint(head.Next);
            Console.Write(head.Data);
        }
        public void ReverseList() {
            Node prev = null, current = Head, next = null;

            Tail = current;

            while (current != null) {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }


            Head = prev;
        }
        public void ReverseListRecursive() => Head = ReverseListRecursive(Head);

        private Node ReverseListRecursive(Node head) {
            if (head.Next == null) return head;

            var n = ReverseListRecursive(head.Next);  //ref on next el

            head.Next.Next = head;   //get new ref on next el 
            head.Next = null;        //make current ellement last

            Tail = head;

            return n;
        }

        internal void ReverseTwoNode(T a, T b) {
            var current = Head; Node first = null, second = null;

            while (current.Next != null) {
                if (current.Next.Data.CompareTo(a) == 0) first = current;
                if (b.CompareTo(current.Next.Data) == 0) second = current;
                current = current.Next;
            }

            Console.WriteLine(first.Data);

            var n1 = new Node(a);
            var n2 = new Node(b);
            n2.Next = first.Next.Next;
            first.Next = n2;
            n1.Next = second.Next.Next;
            second.Next = n1;

        }
        bool start = false;
        public void ReverseListBetweeNodes(T a, T b) {
            Node prev = null, current = Head, next = null;
            Node before = null, after = null; Node tmpTail = null;


            while (current != null) {
                if (current.Data.CompareTo(a) == 0) { Tail = current; start = true; }
                if (current.Data.CompareTo(b) == 0) after = current.Next;
                if (current.Next != null && current.Next.Data.CompareTo(a) == 0) before = current;
                if (current.Next == null) tmpTail = current; 
                if (start) {
                    if (current.Data.CompareTo(b) == 0) start = false;
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }
                else current = current.Next;

            }

            before.Next = prev;
            Tail.Next = after;

            Tail = tmpTail;

        }
    }
}
