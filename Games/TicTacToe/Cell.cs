namespace TicTacToe {
    class Cell {
        public Cell((int row, int col) coordinatres) {
            Coordinatres = coordinatres;
        }

        public (int row, int col) Coordinatres { get; set; }
        public int MiniMaxVal { get; set; } //0 tie, -1-loose, 1 -win
        public override string ToString() {
            return Coordinatres + ":" + MiniMaxVal;
        }
    }
}
