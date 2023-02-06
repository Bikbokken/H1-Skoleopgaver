
public class Program {

    public enum Colours
    {
        Red, Yellow, Green
    }

    public class Car
    {
        private int _battery = 100;
        private int _meters;
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

        public void Drive()
        {
            _meters += 20;
            _battery -= 1;
        }

        public void Charge()
        {
            _meters = 0;
            _battery = 100;
        }

        public Car(Colours colour)
        {
            _colour = colour;
        }
    }

    static void Main(string[] args)
    {

        Car car1 = new Car(Colours.Red);
        Car car2 = new Car(Colours.Green);
        int carNumber = 1;
        Car car = car1;
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hvad ville du gøre med bilen nr. " + carNumber);
            Console.WriteLine("1: Kør med bilen");
            Console.WriteLine("2: Oplad bilen");
            Console.WriteLine("3: Skift bil");
            if(Int32.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        if(car.Battery <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har ikke mere strøm til at fortsætte");
                        } else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du har kørt 20 meter med bilen!");
                            car.Drive();
                        }
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Du har nu opladet bilen");
                        car.Charge();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (carNumber == 1)
                        {
                            carNumber = 2;
                            car1 = car;
                            car = car2;
                            Console.WriteLine("Du har nu skiftet bil til " + carNumber);
                        } else if(carNumber == 2) {
                            carNumber = 1;
                            car2 = car;
                            car = car1;
                            Console.WriteLine("Du har nu skiftet bil til " + carNumber);
                        } else
                        {
                            carNumber = 1;
                            car1 = car;
                            car = car1;
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
