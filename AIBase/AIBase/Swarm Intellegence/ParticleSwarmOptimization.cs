using System;

namespace AIBase.Swarm_Intellegence {
    class ParticleSwarmOptimization {
        double[] GlobalBestSolution;
        Particle[] ParticleSwarm;
        int epoch = 0;
        Random RandomGenerator;
        public ParticleSwarmOptimization() {
            GlobalBestSolution = new double[Constants.NUM_DIMENSIONS];
            ParticleSwarm = new Particle[Constants.NUM_PARTICLES];
            RandomGenerator = new Random();
            GenerateRandSolution();

        }
        public void Solve() {

            for (int i = 0; i < Constants.NUM_PARTICLES; i++) {
                var locations = InitializeLocation();
                var velocity = InitializeVelocity();
                ParticleSwarm[i] = new Particle(locations, velocity);
            }

            while (epoch++ <= 10000) {

                foreach (var particle in ParticleSwarm) {
                    //update velocity
                    for (int i = 0; i < particle.Velocity.Length; i++) {
                        var rp = RandomGenerator.NextDouble();
                        var rg = RandomGenerator.NextDouble();
                        particle.Velocity[i] = particle.Velocity[i] * Constants.w +
                            Constants.c1 * rp * (particle.BestCoordinates[i] - particle.Coordinates[i]) +
                            Constants.c2 * rg * (particle.BestCoordinates[i] - particle.Coordinates[i]);
                    }
                    //update the positions
                    for (int i = 0; i < particle.Coordinates.Length; i++) {
                        particle.Coordinates[i] += particle.Velocity[i];
                        if (particle.Coordinates[i] < Constants.MIN) particle.Coordinates[i] = Constants.MIN;
                        if (particle.Coordinates[i] > Constants.MAX) particle.Coordinates[i] = Constants.MAX;
                    }
                    //check on best in particle
                    if (Constants.F(particle.Coordinates) < Constants.F(particle.BestCoordinates)) particle.BestCoordinates = particle.Coordinates;
                    //check on best in global
                    if (Constants.F(particle.BestCoordinates) < Constants.F(GlobalBestSolution)) Array.Copy(particle.BestCoordinates, GlobalBestSolution, particle.BestCoordinates.Length);
                }
            }


            ShowSolution();
        }

        void GenerateRandSolution() {
            for (int i = 0; i < Constants.NUM_DIMENSIONS; i++)
                GlobalBestSolution[i] = random(Constants.MAX, Constants.MIN);
        }

        double random(double max, double min) {
            return RandomGenerator.NextDouble() * (max - min) + min;
        }

        double[] InitializeLocation() {
            var x = random(Constants.MAX, Constants.MIN);
            var y = random(Constants.MAX, Constants.MIN);

            return new[] { x, y };
        }
        double[] InitializeVelocity() {
            var Vx = random(-(Constants.MAX - Constants.MIN), Constants.MAX - Constants.MIN);
            var Vy = random(-(Constants.MAX - Constants.MIN), Constants.MAX - Constants.MIN);

            return new[] { Vx, Vy };
        }
        public void ShowSolution() {
            Console.WriteLine("solution:" + "[x:"+GlobalBestSolution[0]+",y:"+GlobalBestSolution[1]+"]" + "f(best):=" + Constants.F(GlobalBestSolution));
        }
    }
}
