using System.Collections.Generic;

namespace AIBase {
    static class AllCities {
        public static List<City> Cities { get; set; } = new List<City>();
        public static void AddCity(City c) => Cities.Add(c);
        public static City GetCityByInd(int i) => Cities[i];
        public static int HowManyCities() => Cities.Count;
    }
}
