
public class Program {

    /// <summary>
    /// Enum <c>Colours</c> represents the options of colours
    /// </summary>
    public enum Colours
    {
        Red, Yellow, Green
    }

    /// <summary>
    /// Class <c>Car</c> models a car.
    /// </summary>
    public class Car
    {
        // The amount of battery in the car.
        private int _battery = 100;
        // The amount of meters driven in the car.
        private int _meters = 0;
        // The colour of the car.
        private Colours _colour;


        public Colours Colour
        {
            get { return _colour; }
            private set { _colour = value; }
        }

        public int Battery
        {
            get { return _battery; }
            private set { }
        }


        public int Meters
        {
            get { return _meters; }
            private set { }
        }

        // Drive method, adding 20 to meters and removing one percent from battery.
        public void Drive()
        {
            if(_battery > 0)
            {
                _meters += 20;
                _battery -= 1;
            }

        }

        // Charging the car, setting meters to 0 and the battery percent to 100.

        public void Charge()
        {
            _meters = 0;
            _battery = 100;
        }

        //Constructor
        public Car(Colours colour)
        {
            _colour = colour;
        }
    }

    static void Main(string[] args)
    {
        // Intialize two cars
        Car car1 = new Car(Colours.Red);
        Car car2 = new Car(Colours.Green);
        // Default car
        int carNumber = 1;
        Car car = car1;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hvad ville du gøre med bilen nr. " + carNumber);
            Console.WriteLine("1: Kør med bilen");
            Console.WriteLine("2: Oplad bilen");
            Console.WriteLine("3: Skift bil");
            if(Int32.TryParse(Console.ReadLine(), out int choice)) // Try parse the console readline as an int, if success, out in choice
            {
                switch (choice)
                {
                    case 1:
                        if(car.Battery <= 0) // If the car has less or equal than 0 percent of battery left
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har ikke mere strøm til at fortsætte");
                        } else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du har kørt 20 meter med bilen!");
                            car.Drive(); // Drive the car
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Du har nu opladet bilen");
                        car.Charge(); // Charge the car
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (carNumber == 1) // If the current car is 1
                        {
                            carNumber = 2; // Set the current car to 2
                            car1 = car; // Set car1 object to the current car object
                            car = car2; // Set the current car object to car2
                            Console.WriteLine("Du har nu skiftet bil til " + carNumber);
                        } else if(carNumber == 2) {
                            carNumber = 1; // Set the current car to 1
                            car2 = car; // Set car2 object to the current car object
                            car = car1; // Set the current car object to car1
                            Console.WriteLine("Du har nu skiftet bil til " + carNumber);
                        } else // Just some protection
                        {
                            carNumber = 1; // Set the current car to 1
                            car2 = car; //Set car2 object to the current car object
                            car = car1; // Set the current car object to car1
                            Console.WriteLine("Du har nu skiftet bil til " + carNumber);
                        }
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("BIL NR: " + carNumber);
            Console.WriteLine("BATTERI: " + car.Battery);
            Console.WriteLine("METER KØRT: " + car.Meters);
            Console.WriteLine();
        }

    }
}
