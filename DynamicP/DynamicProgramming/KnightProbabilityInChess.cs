using System;

namespace DynamicProgramming {
    static class KnightProbabilityInChess {
        public static void Solve(int steps, int side) {

            var field = new double[steps, side, side];
            (int row, int col) curr = (0, 0);

            var res = KnightMove(curr, field, steps);
            Console.WriteLine(res);
            ShowField(field);

        }

        private static double KnightMove((int row, int col) curr, double[,,] field, int steps) {

            if (steps == 0) return 1;

            if (field[steps - 1, curr.row, curr.col] != 0) return field[steps - 1, curr.row, curr.col];

            var up_r = (curr.row - 2, curr.col + 1);
            var up_l = (curr.row - 2, curr.col - 1);
            var down_l = (curr.row + 2, curr.col - 1);
            var down_r = (curr.row + 2, curr.col + 1);
            var l_up = (curr.row - 1, curr.col - 2);
            var l_down = (curr.row + 1, curr.col - 2);
            var r_up = (curr.row - 1, curr.col + 2);
            var r_down = (curr.row + 1, curr.col + 2);

            var all_move = new (int, int)[] { up_l, up_r, down_l, down_r, l_up, l_down, r_up, r_down };

            double res = 0;

            foreach (var next_move in all_move)
                if (isValid(next_move, field, steps)) { res += KnightMove(next_move, field, steps - 1) / 8; }


            field[steps - 1, curr.row, curr.col] = res;

            return res;

        }

        private static bool isValid((int row, int col) curr, double[,,] field, int steps) {
            if (curr.row < 0 || curr.row >= field.GetLength(1) || curr.col < 0 || curr.col >= field.GetLength(2)) return false;
            return true;
        }

        private static void ShowField(double[,,] field) {
            var res = 0d;

            for (int steps = 0; steps < field.GetLength(0); steps++) {
                for (int r = 0; r < field.GetLength(1); r++) {
                    for (int j = 0; j < field.GetLength(2); j++) {
                        if (steps == field.GetLength(0) - 1) res += field[steps, r, j];
                        Console.Write(field[steps, r, j] + new string(' ', 19 - field[steps, r, j].ToString().Length));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Probability that Knight on the Board:= {res}");
        }
    }
}
