using System;

namespace Trees {
    class Program {
        static void Main(string[] args) {
            var tree = new BTree();

            tree.Add(8);
            tree.Add(10);
            tree.Add(5);
            tree.Add(2);
            tree.Add(12);
            tree.Add(13);
            tree.Add(14);
            tree.Add(1);
            tree.Add(0);


            var res = tree.Depth();

            Console.WriteLine(res);
        }
    }
    class BTree {
        public BTree() {
            Root = null;
        }

        public Node Root { get; set; }


        public void Add(int data) => Root = Add(Root, data);

        private Node Add(Node node, int data) {
            if (node == null) return new Node(data);

            if (node.Data < data) node.Right = Add(node.Right, data);
            else node.Left = Add(node.Left, data);

            return node;
        }


        public void InOrder() => InOrder(Root);
        public int Depth() => Depth(Root, 0);

        private void InOrder(Node node) {
            if (node == null) return;

            InOrder(node.Left);
            Console.WriteLine(node.Data);
            InOrder(node.Right);
        }
        private int Depth(Node node, int depth = 0) {
            if (node == null) return depth;
            depth++;

            var l = Depth(node.Left, depth);
            var r = Depth(node.Right, depth);

            return Math.Max(l, r);   //Math.Max(Depth(node.Left, depth), Depth(node.Right, depth));
        }
    }
}
