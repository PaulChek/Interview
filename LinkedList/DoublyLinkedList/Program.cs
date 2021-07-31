using System;

namespace DoublyLinkedList {
    class Program {

        static void Main(string[] args) {
            var dll = new DLList();
            dll.Add(1);
            dll.Add(2);
            dll.Add(3);
            dll.Add(4);
            dll.Add(5);
            dll.Add(6);
            dll.Add(7);

            var tail = dll.Tail;
            while (tail != null) {
                if (tail.Data == 3) {
                    tail.Child.Add(40);
                    tail.Child.Add(50);
                    tail.Child.Add(60);
                    tail.Child.Add(70);
                }
                if (tail.Data == 5) {
                    tail.Child.Add(51);
                    tail.Child.Add(52);
                    tail.Child.Add(53);
                    tail.Child.Add(54);
                }
                tail = tail.Prev;
            }

            // dll.Print();

            //Console.WriteLine("flatten:");
            
            
            dll.Flat2();

            var c = dll.Head;
            while (c != null) {
                Console.WriteLine(c.Data);
                c = c.Next;
            }


            // dll.Flat2();
        }
    }
    class DLList {
        public Node Head { get; set; } = null;
        public Node Tail { get; set; } = null;

        public void Add(int data) => Add(new Node(data));

        private void Add(Node node) {
            if (Head == null) { Head = node; Tail = node; }
            else {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
        }
        public void Print() => Print(Head);

        private void Print(Node head) {
            if (head == null) return;
            Console.WriteLine(head.Data);
            if (head.Child.Head != null) Print(head.Child.Head);
            Print(head.Next);
        }

        public void Flat() { var l = new DLList(); Flat(Head, l); Head = l.Head; Tail = l.Tail; }
        public void Flat2() { Flat2Best(Head); }

        private void Flat(Node head, DLList l) {
            if (head == null) return;

            l.Add(head.Data);

            if (head.Child.Head != null) Flat(head.Child.Head, l);

            Flat(head.Next, l);

        }
        private void Flat2Best(Node head) {
            if (head == null) return;


            if ( head.Child.Head != null) {

                var middle = new Node(head.Data, head.Prev, head.Child.Head);

                head.Child.Tail.Next = head.Next;

                head.Next.Prev = head.Child.Tail;

                head.Child.Head.Prev = middle;

                head.Prev.Next = middle;


                Flat2Best(head.Child.Head);

                head.Child.Head = null;
            }

            Flat2Best(head.Next);

        }
    }
}
