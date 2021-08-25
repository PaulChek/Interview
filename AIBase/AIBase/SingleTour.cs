using System;
using System.Collections.Generic;
using System.Linq;

namespace AIBase {
    class SingleTour {
        public SingleTour(List<City> tour) {
            Tour = new List<City>();
            Tour.AddRange(tour);
        }
        public SingleTour() {
            Tour = new List<City>();
            //for (int i = 0; i < AllCities.HowManyCities(); i++)
            //    Tour.Add(null);
            Tour.AddRange(AllCities.Cities);
        }

        public List<City> Tour { get; set; }

        private double _distanse;

        public double Distance {
            get {
                double tmp = 0;

                for (int i = 0; i < Tour.Count; i++)
                    tmp += Tour[i].DistanceTo(Tour[(i + 1) % Tour.Count]);

                _distanse = tmp;

                return _distanse;
            }
            set { _distanse = value; }
        }



        public void GenerateTour() {
            Tour.AddRange(AllCities.Cities);
            Tour = Tour.OrderBy(v => new Random().Next()).ToList();
        }

        public override string ToString() {
            return string.Join("->", Tour);
        }
    }
}
