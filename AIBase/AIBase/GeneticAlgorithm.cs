using System;
using System.Linq;

namespace AIBase {
    class GeneticAlgorithm {
        static int[] SOLUTION_SEQ = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static double CROSSOVER_RATE = .6;
        static double MUTATION_RATE = .2;
        static int TOURNAMENT_SIZE = 5;
        static int CHROMOSOME_LENGTH = SOLUTION_SEQ.Length;
        public static int MAX_FITNESS = 10;

        //indidual representation of one solution
        public class Variation {
            private int _fitness;

            public Variation() {
                Genes = new int[CHROMOSOME_LENGTH];
                RandomGenerator = new Random();
            }

            public int[] Genes { get; set; }
            public void SetGene(int i, int value) => Genes[i] = value;
            public int Fitness {
                get {
                    _fitness = 0;
                    for (int i = 0; i < CHROMOSOME_LENGTH; i++)
                        if (Genes[i] == SOLUTION_SEQ[i]) _fitness++;
                    return _fitness;
                }
            }
            public Random RandomGenerator { get; set; }

            public void GenerateVariation() {
                for (int i = 0; i < CHROMOSOME_LENGTH; i++)
                    Genes[i] = RandomGenerator.Next(0, CHROMOSOME_LENGTH);
            }
            public override string ToString() {
                return $"[ {string.Join(", ", this.Genes)} ]";
            }
        }

        //Population

        public class Population {
            public Population(int populationSize) {
                Variations = new Variation[populationSize];

                for (int i = 0; i < populationSize; i++) {
                    Variations[i] = new();
                    Variations[i].GenerateVariation();
                }
            }

            public Variation[] Variations { get; set; }
            public Variation GetFittest() => Variations.OrderByDescending(v => v.Fitness).FirstOrDefault();

        }


        //Main  Solution

        public Random RandomGenerator { get; set; } = new Random();

        public Population Evolve(Population population) {

            var newPopulation = new Population(population.Variations.Length);

            //crossover
            for (int i = 0; i < population.Variations.Length; i++) {

                Variation firstVariation = RandomSelection(population);
                Variation secondVariation = RandomSelection(population);

                Variation newVariation = CrossOver(firstVariation, secondVariation);

                newPopulation.Variations[i] = newVariation;
            }
            //mutate
            for (int j = 0; j < population.Variations.Length; j++)
                Mutate(newPopulation.Variations[j]);

            return newPopulation;

        }

        private void Mutate(Variation variation) {
            for (int i = 0; i < CHROMOSOME_LENGTH; i++)
                if (RandomGenerator.NextDouble() <= MUTATION_RATE)
                    variation.SetGene(i, RandomGenerator.Next(0, CHROMOSOME_LENGTH));
        }

        private Variation CrossOver(Variation firstVariation, Variation secondVariation) {
            var newVar = new Variation();

            for (int i = 0; i < CHROMOSOME_LENGTH; i++) {
                if (RandomGenerator.NextDouble() <= CROSSOVER_RATE)
                    newVar.SetGene(i, firstVariation.Genes[i]);
                else newVar.SetGene(i, secondVariation.Genes[i]);
            }

            return newVar;
        }

        private Variation RandomSelection(Population population) {
            var newPop = new Population(TOURNAMENT_SIZE);

            for (int i = 0; i < TOURNAMENT_SIZE; i++) {
                var rnd_i = RandomGenerator.Next(0, population.Variations.Length);
                newPop.Variations[i] = population.Variations[rnd_i];
            }

            var fittest = newPop.GetFittest();

            return fittest;
        }
    }
}
