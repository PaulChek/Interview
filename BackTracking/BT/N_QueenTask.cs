namespace BT {
    class N_QueenTask {
        public static bool Solve(int[,] board, int c = 0) {

            if (c >= board.GetLength(1)) return true;



            for (int r = 0; r < board.GetLength(1); r++) {
                if (IsValidPosition(board, (r, c))) {
                    board[r, c] = 1;
                    if (Solve(board, c + 1)) return true;
                    else board[r, c] = 0;
                }
            }

            return false;
        }

        private static bool IsValidPosition(int[,] board, (int r, int c) p) {
            for (int c = 0; c < p.c; c++)
                if (board[p.r, c] == 1) return false;

            for (int i = p.r, j = p.c; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1) return false;

            for (int i = p.r, j = p.c; i < board.GetLength(0) && j >= 0; i++, j--)
                if (board[i, j] == 1) return false;

            return true;
        }
    }
}
