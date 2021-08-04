using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trees {
    class Program {
        static void Main(string[] args) {
            var tree = new BTree();

            tree.Add(8);
            tree.Add(-1);
            tree.Add(-5);
            tree.Add(-2);
            tree.Add(10);
            tree.Add(5);
            tree.Add(2);
            tree.Add(6);
            tree.Add(7);
            tree.Add(3);
            tree.Add(12);
            tree.Add(15);
            tree.Add(1);
            tree.Add(0);

            var res = new List<int[]>();


            tree.LevelOrder(res);

            foreach (var item in res)
                Console.WriteLine($"[ {string.Join(", ", item)} ]");


            var res2 = tree.LevelOrder2();


            Console.WriteLine("--------Good My InDepth---------");


            foreach (var item in res2)
                Console.WriteLine($"[ {string.Join(", ", item)} ]");

            Console.WriteLine("*********Good Bread First not my*********");

            var res3 = tree.LevelOrder3();

            foreach (var item in res3)
                Console.WriteLine($"[ {string.Join(", ", item)} ]");
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
        public void LevelOrder(List<int[]> ret, Queue<Node> q = null) {

            var res = new List<Node>();

            if (q == null) {
                q = new Queue<Node>();
                q.Enqueue(Root);
            }

            while (q.Count > 0) {
                var curr = q.Dequeue();
                if (curr != null) res.Add(curr);
            }


            foreach (var node in res) {
                if (node.Left != null) q.Enqueue(node.Left);
                if (node.Right != null) q.Enqueue(node.Right);
            }

            if (res.Count > 0) ret.Add(res.Select(n => n.Data).ToArray()); // for get result 

            Console.WriteLine(string.Join(" ", res.Select(n => n.Data))); // justt for demonstration

            if (res.Count > 0) LevelOrder(ret, q);

        }
        public List<List<int>> LevelOrder2() => LevelOrder2(Root, new());
        private List<List<int>> LevelOrder2(Node node, List<List<int>> res, int depth = 0) {
            if (node == null) return res;

            if (res.ElementAtOrDefault(depth) != null) res[depth].Add(node.Data);
            else res.Add(new List<int>() { node.Data });


            depth++;

            LevelOrder2(node.Left, res, depth);
            LevelOrder2(node.Right, res, depth);

            return res;
        }

        public List<List<int>> LevelOrder3() {

            var q = new Queue<Node>();
            var levelArr = new List<int>();
            var res = new List<List<int>>();

            q.Enqueue(Root);

            int l = q.Count, processed = 0;


            while (q.Count > 0) {

                var curr = q.Dequeue();

                processed++;

                levelArr.Add(curr.Data);

                if (curr.Left != null) q.Enqueue(curr.Left);
                if (curr.Right != null) q.Enqueue(curr.Right);

                if (processed == l) { l = q.Count; processed = 0; res.Add(levelArr); levelArr = new List<int>(); }

            }
            return res;
        }
    }
}
