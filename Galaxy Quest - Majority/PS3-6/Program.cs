using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PS3_6
{
    class Program
    {

        static float diameter = 0;
        static int total = 0;

        static void Main(string[] args)
        {
            long d;
            int k;
            string[] firstLine = Console.ReadLine().Split(null);
            long.TryParse(firstLine[0], out d);
            int.TryParse(firstLine[1], out k);
            diameter = d;

            List<Planet> planets = new List<Planet>(k);

            for (int i = 0; i < k; i++) {
                long x, y;
                string[] line = Console.ReadLine().Split(null);
                long.TryParse(line[0], out x);
                long.TryParse(line[1], out y);

                planets.Add(new Planet(x, y));
            }

            Planet planet = findMajority(planets);
            if (planet != null) {
                Console.WriteLine(total);
            } else {
                Console.WriteLine("NO");
            }

        }

        static Planet findMajority(List<Planet> planets) {
            if (planets.Count == 0) {
                return null;

            } else if (planets.Count == 1) {
                return planets[0];
            } 

            int mid = planets.Count / 2;
            List<Planet> lo = planets.GetRange(0, mid);
            List<Planet> hi = planets.GetRange(mid, planets.Count- mid);

            Planet leftMajority = findMajority(lo);
            Planet rightMajority = findMajority(hi);

            if (leftMajority == null && rightMajority == null) {
                return null;

            } else if (leftMajority == null) {
                total = CheckWhole(rightMajority, planets);
                return  total > mid ? rightMajority : null; 

            } else if (rightMajority == null) {
                total = CheckWhole(leftMajority, planets);
                return  total > mid ? leftMajority : null;


            } else {
                int leftCount = CheckWhole(leftMajority, planets);
                int rightCount = CheckWhole(rightMajority, planets);
                total = leftCount > mid ? leftCount : rightCount > mid ? rightCount : 0;

                return total == leftCount ? leftMajority : total == rightCount ? rightMajority : null;
            }

        }

        static int CheckWhole(Planet planet, List<Planet> planets) {
            return planets.FindAll((p) => p.IsInGalaxy(planet)).Count;

        }

        class Planet {
            public float x;
            public float y;

            public Planet(float x, float y) {
                this.x = x;
                this.y = y; 
            }

            public bool IsInGalaxy(Planet planet) {
                return (Math.Pow((planet.x - this.x), 2) + Math.Pow((planet.y - this.y), 2) <= Math.Pow(diameter, 2));
            }
        }

    }
}
