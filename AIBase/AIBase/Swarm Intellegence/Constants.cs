using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://academo.org/demos/3d-surface-plotter/?expression=exp(-x*x-y*y)*sin(x)&xRange=-2%2C2&yRange=-2%2C2&resolution=25
namespace AIBase.Swarm_Intellegence {
    class Constants {
        private Constants() {
        }
        public static int NUM_DIMENSIONS = 2;
        public static int NUM_PARTICLES = 10;
        public static double MIN = -2;//START POINT OF INTERVAL
        public static double MAX = 2;//END POINT OF INTERVAL
        public static double w = .729;//weight
        public static double c1 = 1.49;//cognitive or local weight
        public static double c2 = 1.49;//global or social weight

        public static double F(params double[] p) {     //!
            (double x, double y) = (p[0], p[1]);
            return Math.Exp(-x * x - y * y) * Math.Sin(x);
        }

    }
}
