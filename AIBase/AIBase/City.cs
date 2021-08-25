using System;

namespace AIBase {
    class City {
        public City() {
            X = (int)(new Random().NextDouble() * 100);
            Y = (int)(new Random().NextDouble() * 100);
        }

        public City(int x, int y) {
            X = x;
            Y = y;
        }

        int X { get; set; }
        int Y { get; set; }

        public double DistanceTo(City Next) {
            var x = Math.Abs(X - Next.X);
            var y = Math.Abs(Y - Next.Y);
            return Math.Sqrt(x * x + y * y);
        }

        public override string ToString() {
            return $"[{X},{Y}]";
        }
    }
}
