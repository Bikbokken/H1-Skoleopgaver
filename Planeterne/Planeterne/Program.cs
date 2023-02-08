public class Program
{

    public class Planet
    {
        private string _name;
        private double _mass;
        private double _diameter;
        private double _density;
        private double _gravity;
        private double _rotationperiod;
        private double _lengthofdays;
        private double _distancefromsun;
        private double _orbitialperiod;
        private double _orbitialvelocity;
        private double _meantemp;
        private byte _numberofmoons;
        private bool _ringsystem;

        public string Name { get { return _name; } }
        public double Diameter { get { return _diameter; } }
        public double MeanTemperature { get { return _meantemp; } }

        public Planet(string name, double mass, double diameter, double density, double gravity, double rotationperiod, double lengthofdays, double distancefromsun, double orbitialperiod, double orbitialvelocity, double meantemp, byte numberofmoons, bool ringsystem)
        {
            _name = name;
            _mass = mass;
            _diameter = diameter;
            _density = density;
            _gravity = gravity;
            _rotationperiod = rotationperiod;
            _lengthofdays = lengthofdays;
            _distancefromsun = distancefromsun;
            _orbitialperiod = orbitialperiod;
            _orbitialvelocity = orbitialvelocity;
            _meantemp = meantemp;
            _numberofmoons = numberofmoons;
            _ringsystem = ringsystem;
        }
        public override string ToString()
        {
            string joined = "";
            joined += _name + "\n";
            joined += _mass + "\n";
            joined += _diameter + "\n";
            joined += _density + "\n";
            joined += _gravity + "\n";
            joined += _rotationperiod + "\n";
            joined += _lengthofdays + "\n";
            joined += _distancefromsun + "\n";
            joined += _orbitialperiod + "\n";
            joined += _orbitialvelocity + "\n";
            joined += _meantemp + "\n";
            joined += _numberofmoons + "\n";
            joined += _ringsystem + "\n";
            return joined;
    }
    }

    static void Main(string[] args)
    {
        List<Planet> planets = new List<Planet>();

        planets.Add(new Planet("Mercury", 0.333, 4879, 5427, 3.7, 1407.6, 4222.6, 57.9, 88, 47.4, 167, 0, false));
        planets.Add(new Planet("Earth", 5.97, 12756, 5514, 9.8, 23.9, 24, 149.6, 365.2, 29.8, 15, 1, false));
        planets.Add(new Planet("Mars", 0.642, 6792, 3933, 3.7, 24.6, 24.7, 227.9, 687, 24.1, -65, 2, false));
        planets.Add(new Planet("Jupiter", 1898, 142984, 1326, 23.1, 9.9, 9.9, 778.6, 4331, 13.1, -110, 76, true));
        planets.Add(new Planet("Saturn", 568, 120536, 687, 9, 10.7, 10.7, 1433.5, 10.747, 9.7, -140, 62, true));
        planets.Add(new Planet("Uranus", 86.8, 51118, 1271, 8.7, -17.2, 17.2, 2872.5, 30.589, 6.8, -195, 27, true));
        planets.Add(new Planet("Neptune", 102, 49528, 1638, 11, 16.1, 16.1, 4495.1, 59.8, 2.5, -200, 14, true));
        planets.Add(new Planet("Pluto", 0.0146, 2470, 2095, 0.7, -153.3, 153.3, 5906.4, 90.56, 4.7, -225, 5, false));
        Console.WriteLine();
        Console.WriteLine("______________________");
        Console.WriteLine();
        
        //3:
        
        /*
                foreach (Planet planet in planets)
                {
                    Console.WriteLine(planet.ToString());
                }
        */
        
        // 4 & 5:

                planets.Insert(1, new Planet("Venus", 4.87, 12104, 5243, 8.9, -5832.5, 2802, 108.2, 224.7, 35, 464, 0, false));
        /*
                foreach (Planet planet in planets)
                {
                    Console.WriteLine(planet.ToString());
                }
        */

        // 6:

        /*planets.RemoveAll(x => x.Name == "Pluto");
        foreach (Planet planet in planets)
        {
            Console.WriteLine(planet.ToString());
        }*/

        
        // 7:

        /*
        planets.Add(new Planet("Pluto", 0.0146, 2470, 2095, 0.7, -153.3, 153.3, 5906.4, 90.56, 4.7, -225, 5, false));
        */

        //8:

        /*
        Console.WriteLine(planets.Count());
        */

        //9:

        /*
        List<Planet> new_planets = new List<Planet>();
        new_planets = planets.Where(x => x.MeanTemperature < 0).ToList();
        */

        // 10:

        /*
        List<Planet> new_planets = new List<Planet>();
        new_planets = planets.Where(x => x.Diameter > 10000 && x.Diameter < 50000).ToList();
        */



        // 11:
        /*
        planets.Clear();
        */

    }


}


