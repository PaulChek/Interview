using System;

namespace AIBase {
    class Program {
        static void Main(string[] args) {
            Func<double, double> f = x => Math.Pow((x - 0.3), 3) - 5 * x + x * x - 2; //y(x) http://fooplot.com/


            new Annealing().FindOptimum();

            Console.WriteLine(f(1.2561231270693818));


            for (int i = 0; i < 100; i++) {
                AllCities.AddCity(new City());
            }

            // new AnnealingSalesMan().Simulation();



            //Genetic
            //GeneticAlgorithm.Population population = new GeneticAlgorithm.Population(100);
            //int epoch = 0;
            //var genAlg = new GeneticAlgorithm();

            //while ( population.GetFittest().Fitness != GeneticAlgorithm.MAX_FITNESS) {
            //    epoch++;
            //    Console.WriteLine($"epoch:{epoch} fittest:{population.GetFittest().Fitness}");
            //    Console.WriteLine(population.GetFittest());
            //   population =  genAlg.Evolve(population);
            //}
            //    Console.WriteLine(population.GetFittest());



            //Swarm intellegence
            //var n = new Swarm_Intellegence.ParticleSwarmOptimization();

            //n.Solve();
            var str = "123";
          string res =  EvenOrOdd(str);
            Console.WriteLine(res);


        }

        public static string EvenOrOdd(string str) {
            int odd = 0, even = 0, tmp = 0;
            Array.ForEach(str.ToCharArray(), v => _= ((tmp = int.Parse(v + "") )& 1) == 1 ? odd+=tmp : even+=tmp);
            return even>odd? "Even is greater than Odd":even==odd? "Even and Odd are the same" : "Odd is greater than Even";
        }
    }
}
