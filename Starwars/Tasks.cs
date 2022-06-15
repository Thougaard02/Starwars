using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    public class Tasks
    {
        private void Opgave1(List<Planet> planets)
        {
            var planetNames = planets.Where(x => x.Name.StartsWith("M")).ToList();

            foreach (Planet planet in planetNames)
            {
                Console.WriteLine(planet.Name);
            }
        }

        private void Opgave2(List<Planet> planets)
        {
            var planetNames = planets.Where(x => x.Name.Contains("y") || x.Name.Contains("Y"));

            foreach (Planet planet in planetNames)
            {
                Console.WriteLine(planet.Name);
            }
        }

        private void Opgave3(List<Planet> planets)
        {
            var planetNames = planets.Where(x => x.Name.Count() > 9 && x.Name.Count() < 15);

            foreach (Planet planet in planetNames)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave4(List<Planet> planets)
        {
            var planetNames = planets.Where(x => x.Name.EndsWith("e") && x.Name.Substring(0, 5).Contains("a"));

            foreach (Planet planet in planetNames)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave5(List<Planet> planets)
        {
            var planetRotationPeriod = planets.Where(x => x.RotationPeriod > 40).OrderBy(x => x.RotationPeriod);

            foreach (Planet planet in planetRotationPeriod)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave6(List<Planet> planets)
        {
            var planetRotationPeriod = planets.Where(x => x.RotationPeriod > 10 && x.RotationPeriod < 20).OrderBy(x => x.Name);

            foreach (Planet planet in planetRotationPeriod)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave7(List<Planet> planets)
        {
            var planetRotationPeriod = planets.Where(x => x.RotationPeriod > 30).OrderBy(x => x.Name).ThenBy(x => x.RotationPeriod);

            foreach (Planet planet in planetRotationPeriod)
            {
                Console.WriteLine(planet.Name);
            }
        }

        private void Opgave8(List<Planet> planets)
        {
            var planetRotationPeriod = planets.Where(x => (x.RotationPeriod < 30 || x.SurfaceWater > 50) && x.Name.Contains("ba")).OrderBy(x => x.Name).ThenBy(x => x.SurfaceWater).ThenBy(x => x.RotationPeriod);

            foreach (Planet planet in planetRotationPeriod)
            {
                Console.WriteLine(planet.Name);
            }
        }

        private void Opgave9(List<Planet> planets)
        {
            var planetSurfacewater = planets.Where(x => x.SurfaceWater > 0).OrderByDescending(x => x.SurfaceWater);

            foreach (Planet planet in planetSurfacewater)
            {
                Console.WriteLine(planet.Name);
            }
        }
        #region Opgave10

        private double SurfaceArea(int diameter, long population)
        {
            return (4 * Math.PI * Math.Pow(diameter / 2, 2)) / population;
        }
        private void Opgave10(List<Planet> planets)
        {

            var planetAvailability = planets.Where(x => x.Diameter != 0 && x.Population > 0).OrderBy(x => SurfaceArea(x.Diameter, x.Population));

            foreach (Planet planet in planetAvailability)
            {
                Console.WriteLine(planet.Name);
            }
        }
        #endregion

        private void Opgave11(List<Planet> planets)
        {
            var planetRotationPeriod = planets.Where(x => x.RotationPeriod > 0);

            var onlyPlanet = planets.Except(planetRotationPeriod, new NameComparer());

            foreach (Planet planet in onlyPlanet)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave12(List<Planet> planets)
        {
            var planetName = planets.Where(x => x.Name.StartsWith("A") || x.Name.EndsWith("s"));

            var planetTerrain = planets.Where(x => x.Terrain != null && x.Terrain.Contains("rainforests")).ToList();

            var allUnion = planetName.Union(planetTerrain, new NameComparer());

            foreach (Planet planet in allUnion)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave13(List<Planet> planets)
        {
            var findAllPlanetDesert = planets.Where(x => x.Terrain != null && x.Terrain.Contains("deserts"));

            foreach (var planet in findAllPlanetDesert)
            {
                Console.WriteLine(planet.Name);
            }
        }
        private void Opgave14(List<Planet> planets)
        {
            var findAllPlanetDesertAndSwamp = planets.Where(x => x.Terrain != null && x.Terrain.Contains("swamps")).OrderBy(x => x.RotationPeriod).ThenBy(x => x.Name);
            foreach (var planet in findAllPlanetDesertAndSwamp)
            {
                Console.WriteLine(planet.Name);
            }
        }
        #region opgave 15
        private bool CheckForDoubleVowels(string name)
        {
            Regex regex = new Regex("[a]{2,}|[e]{2,}|[o]{2,}|[i]{2,}|[o]{2,}|[y]{2,}");
            var match = regex.Match(name);
            return match.Length > 0;
        }
        private void Opgave15(List<Planet> planets)
        {
            var findPlanetsWithDoubleVocals = planets.Where(x => CheckForDoubleVowels(x.Name));

            foreach (Planet planet in findPlanetsWithDoubleVocals)
            {
                Console.WriteLine(planet.Name);
            }
        }
        #endregion

        #region opgave 16
        private bool CheckForDoubleConsonant(string name)
        {
            Regex regex = new Regex("[k]{2,}|[l]{2,}|[r]{2,}|[n]{2,}");
            var match = regex.Match(name);
            return match.Length > 0;
        }
        private void Opgave16(List<Planet> planets)
        {
            var findPlanetsWithDoubleVocals = planets.Where(x => CheckForDoubleConsonant(x.Name)).OrderByDescending(x => x.Name);

            foreach (Planet planet in findPlanetsWithDoubleVocals)
            {
                Console.WriteLine(planet.Name);
            }
        }
        #endregion

        public void RunAllTasks(List<Planet> planets)
        {
            Console.WriteLine($"Opgave 1");
            Opgave1(planets);
            Console.WriteLine();

            Console.WriteLine($"Opgave 2");
            Opgave2(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 3");
            Opgave3(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 4");
            Opgave4(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 5");
            Opgave5(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 6");
            Opgave6(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 7");
            Opgave7(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 8");
            Opgave8(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 9");
            Opgave9(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 10");
            Opgave10(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 11");
            Opgave11(planets);
            Console.WriteLine();
            
            Console.WriteLine($"Opgave 12");
            Opgave12(planets);
            Console.WriteLine();

            Console.WriteLine($"Opgave 13");
            Opgave13(planets);
            Console.WriteLine();

            Console.WriteLine($"Opgave 14");
            Opgave14(planets);
            Console.WriteLine();

            Console.WriteLine($"Opgave 15");
            Opgave15(planets);
            Console.WriteLine();

            Console.WriteLine($"Opgave 16");
            Opgave16(planets);
            Console.WriteLine();
        }
    }
}
