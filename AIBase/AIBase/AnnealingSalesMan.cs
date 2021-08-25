using System;

namespace AIBase {
    class AnnealingSalesMan {
        SingleTour Best { get; set; }
        public void Simulation() {
            double temp = 10000;
            double coolRate = .003;

            var curSolution = new SingleTour();

            curSolution.GenerateTour();

            Console.WriteLine( curSolution);
            Console.WriteLine($"initial solution distance { curSolution.Distance }");

            Best = new SingleTour(curSolution.Tour);

            while (temp > 1) {

                var nextSoution = new SingleTour(curSolution.Tour);

                int index = new Random().Next(0, nextSoution.Tour.Count);
                int index2 = new Random().Next(0, nextSoution.Tour.Count);

                //swap two random cities
                (nextSoution.Tour[index], nextSoution.Tour[index2]) = (nextSoution.Tour[index2], nextSoution.Tour[index]);


                double energy = curSolution.Distance;

                double nEnergy = nextSoution.Distance;


                if (acceptanceProbability(energy, nEnergy, temp) > new Random().NextDouble()) {
                    curSolution = new SingleTour(nextSoution.Tour);
                }
                if (curSolution.Distance < Best.Distance) Best = nextSoution;

                temp *= 1 - coolRate;
            }
            Console.WriteLine("\nBEST result->>>" + Best.Distance);
        }

        private double acceptanceProbability(double curEnergy, double nEnergy, double temperature) {
            return curEnergy > nEnergy ? 1 : Math.Exp((curEnergy - nEnergy) / temperature);
        }
    }
}
