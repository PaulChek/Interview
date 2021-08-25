using System;

namespace AIBase {
    class Annealing {
        static class Constants {
            public static double MIN_COORDINATE = -2;
            public static double MAX_COORDINATE = 2;
            public static double MIN_TEMP = 1;
            public static double MAX_TEMP = 100;
            public static double COOLING_RATE = 0.02;
        }
        public Annealing() {
            Random = new Random();
        }

        Random Random { get; set; }
        double CurrentX { get; set; }
        double NextX { get; set; }
        double BestX { get; set; }
        double f(double x) => Math.Pow((x - 0.3), 3) - 5 * x + x * x - 2;
        double GetEnergy(double x) => f(x);
        double GetNextX() => Random.NextDouble() * (Constants.MAX_COORDINATE - Constants.MIN_COORDINATE) + Constants.MIN_COORDINATE;
        double AcceptanceProbability(double energy, double neigborEnergy, double temperature) {
            if (energy > neigborEnergy) return 1; //for finding global minimum
            return Math.Exp((energy - neigborEnergy) / temperature);
        }
        /// <summary>
        /// Minimum of function y(x)
        /// </summary>
        public void FindOptimum() {
            var temperature = Constants.MAX_TEMP;

            while (temperature > Constants.MIN_TEMP) {
                NextX = GetNextX();
                var energy = GetEnergy(CurrentX);
                var neighbrEnergy = GetEnergy(NextX);

                var acceptence = AcceptanceProbability(energy, neighbrEnergy, temperature);

                if (acceptence > Random.NextDouble()) CurrentX = NextX;


                if (GetEnergy(CurrentX) < GetEnergy(BestX)) BestX = CurrentX;


                temperature *= 1 - Constants.COOLING_RATE;
            }

            Console.WriteLine(BestX);
        }
    }
}
