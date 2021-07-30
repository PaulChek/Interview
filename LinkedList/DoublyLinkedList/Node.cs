namespace DoublyLinkedList {
    class Node {
        public Node(int data, Node prev = null, Node next = null) {
            Data = data;
            Prev = prev;
            Next = next;
            Child = new DLList();
        }

        public int Data { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }
        public DLList Child { get; set; }
    }
}
