using System;
//https://academo.org/demos/3d-surface-plotter/?expression=exp(-x*x-y*y)*sin(x)&xRange=-2%2C2&yRange=-2%2C2&resolution=25
namespace AIBase.Swarm_Intellegence {
    class Particle {
        public double[] Coordinates { get; set; }
        public double[] Velocity { get; set; }
        public double[] BestCoordinates { get; set; }

        public Particle(double[] coordinates, double[] velocity) {
            Coordinates = new double[Constants.NUM_DIMENSIONS];
            Velocity = new double[Constants.NUM_DIMENSIONS];
            BestCoordinates = new double[Constants.NUM_DIMENSIONS];
            Array.Copy(coordinates, Coordinates, coordinates.Length);
            Array.Copy(velocity, Velocity, velocity.Length);
        }
        public override string ToString() {
            return $"BestPosition->{string.Join(":", BestCoordinates)}";
        }

        public void BestCheck(double[] globalBest) {
            if (Constants.F(BestCoordinates) < Constants.F(globalBest)) globalBest = BestCoordinates;
        }
    }
}
