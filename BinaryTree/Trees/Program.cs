using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trees {
    class Program {
        static void Main(string[] args) {
            var tree = new BTree();

            tree.Add(10);
            tree.Add(5);
            tree.Add(1);
            tree.Add(0);
            tree.Add(8);
            tree.Add(7);
            tree.Add(9);
            tree.Add(2);
            tree.Add(15);
            tree.Add(11);
            tree.Add(25);

            var res = new List<int[]>();


            tree.LevelOrder(res);

            foreach (var item in res)
                Console.WriteLine($"[ {string.Join(", ", item)} ]");


            var res2 = tree.LevelOrder2();


            Console.WriteLine("--------Good My DFS---------");


            foreach (var item in res2)
                Console.WriteLine($"[ {string.Join(", ", item)} ]");

            Console.WriteLine("*********Good BFS not my*********");

            var res3 = tree.LevelOrder3();

            foreach (var item in res3)
                Console.WriteLine($"[ {string.Join(", ", item)} ]");



            Console.WriteLine("---------------Right View DFS----------------");

            var res4 = tree.RightView();


            Console.WriteLine("[" + string.Join(", ", res4) + "]");

            Console.WriteLine("---------------Right View BFS----------------");

            var res5 = tree.RightViewBrfs();


            Console.WriteLine("[" + string.Join(", ", res5) + "]");


            Console.WriteLine("---------------Amount of nodes----------------");
            var total = tree.AmountOfNodesInCompleteTree();
            Console.WriteLine(">>>>>>>> (" + total + ") <<<<<<<");




            Console.WriteLine("---------------Is BST----------------");
            Console.WriteLine(tree.Root.Right.Left.Data);
            Console.WriteLine(tree.IsBST());



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

        public bool IsBST() => IsBST(Root);

        private bool IsBST(Node curNode, bool res = false, int min = int.MinValue, int max = int.MaxValue) {
            if (curNode == null) return res;

            if (curNode.Data <= min || curNode.Data >= max) return false;

          

            if (curNode.Left != null) if(!IsBST(curNode.Left, res, min, curNode.Data)) return false;

            if (curNode.Right != null) if (!IsBST(curNode.Right, res, curNode.Data, max)) return false;  

            return true;
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
        public List<int> RightView() => RightView(Root, new List<int>());
        public List<int> RightViewBrfs() => RightViewBrfs(new List<int>());

        private List<int> RightViewBrfs(List<int> list) {
            var q = new Queue<Node>();
            q.Enqueue(Root);
            int qL = q.Count;

            while (q.Count > 0) {
                var cur = q.Dequeue();
                qL--;

                if (cur.Left != null) q.Enqueue(cur.Left);
                if (cur.Right != null) q.Enqueue(cur.Right);

                if (qL == 0) { list.Add(cur.Data); qL = q.Count; }
            }


            return list;
        }

        private List<int> RightView(Node node, List<int> res, int depth = 0) {

            if (node == null) return res;

            if (res.Count <= depth) res.Add(node.Data);

            depth++;

            RightView(node.Right, res, depth);
            RightView(node.Left, res, depth);

            return res;

        }
        private List<int> RightViewMy(Node node, List<int> res, int depth = 0) {
            if (node == null) return res;

            if (res.Count > depth) res[depth] = node.Data;
            else res.Add(node.Data);

            depth++;

            RightViewMy(node.Left, res, depth);
            RightViewMy(node.Right, res, depth);


            return res;

        }

        public int AmountOfNodesInCompleteTree() {
            if (Root == null) return 0;

            var height = GetHeightOfFullTree(Root);

            if (height == 0) return 1;

            int beforeLastRowNodesCount = (int)Math.Pow(2, height) - 1;

            int l = 0, r = beforeLastRowNodesCount;

            while (l < r) {
                var indexToFind = (int)Math.Ceiling((decimal)(l + r) / 2);

                if (NodeExist(Root, indexToFind, height)) l = indexToFind;
                else r = indexToFind - 1;

            }


            return beforeLastRowNodesCount + l + 1/*or r*/;
        }

        private bool NodeExist(Node node, int indexToFind, int height) {
            int l = 0,
                r = (int)Math.Pow(2, height) - 1;

            while (height-- > 0) {
                var middle = (int)Math.Ceiling((double)(l + r) / 2);

                if (indexToFind < middle) { r = middle - 1; node = node.Left; }
                else { l = middle; node = node.Right; }
            }

            return node != null;
        }

        private static int GetHeightOfFullTree(Node node, int depth = 0) {
            if (node.Left == null) return depth;
            var d = GetHeightOfFullTree(node.Left, depth + 1);
            return d;
        }
    }
}
