namespace Trees {
    class Node {
        public Node(int data, Node left = null, Node right = null) {
            Data = data;
            Left = left;
            Right = right;
        }

        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
