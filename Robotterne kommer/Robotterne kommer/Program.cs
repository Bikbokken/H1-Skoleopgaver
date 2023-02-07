
public class Program
{

    public enum Chips
    {
        RX54667,
        QT8339
    }

    public enum Types
    {
        Small,
        Large,
        Medium
    }

    public enum Kinds
    {
        WindowsCleaner,
        WheelChanger,
        FloorSweeper,
    }

    public class Feature
    {
        private string _name;   

        public string Name { get { return _name; } }

        public Feature(string name)
        {
            _name = name;
        }
    }

    
    //Inherit the Feature Class with a soap class
    public class Soap : Feature
    {
        private float _capacity; // Using float as 32 bit is more than enough
        public float Capacity { get { return _capacity; } }
        public Soap(string name) : base(name)
        {
            _capacity = 2.3f;
        }
    }

    public class Robot {

        private string _colour = "White";
        private Chips _chip;
        private bool _wifi;
        private byte _batteryCapacity;
        private byte _wheels;
        private Types _type;
        private Kinds _kind;
        private List<Feature> _features = new List<Feature>();


        // "Default constructor"
        public Robot(Chips chip, bool wifi, Kinds kind, Types type)
        {
            _chip = chip;
            _wifi = wifi;
            _kind = kind;
            _type = type;
        }

        //First argument can be colour -> Then there is no battery capacity
        public Robot(string colour, Chips chip, bool wifi, Kinds kind, Types type) :this(chip, wifi,kind, type)
        {
            _colour = colour;
            _batteryCapacity = 0;
            if (kind == Kinds.WindowsCleaner || kind == Kinds.FloorSweeper)
            {
                _features.Add(new Soap("Dispensor"));
            }

        }

        //There is no colour (this should be the first argument) - then type the battery capacity of the robot.
        public Robot(byte batteryCap, Chips chip, bool wifi, Kinds kind, Types type) : this(chip, wifi, kind, type)
        {
            _batteryCapacity = batteryCap;
        }

        //No colour, but type and wheels
        public Robot(byte batteryCap, Chips chip, bool wifi, Kinds kind, Types type, byte wheels) : this(batteryCap, chip, wifi, kind, type)
        {
            _wheels = type == Types.Small ? (byte)0 : (byte)wheels;
        }

        // A colour, with wheels
         public Robot(string colour, Chips chip, bool wifi, Kinds kind, Types type, byte wheels) :this(colour, chip, wifi,kind, type)
        {
            _wheels = type == Types.Small ? (byte)0 : (byte)wheels;
        }





        public override string ToString()
        {
            string joined = "Colour: " + _colour + "\n";
            joined += "Chip: " + _chip + "\n";
            joined += "Wifi: " + _wifi + "\n";
            joined += "Battery: " + _batteryCapacity + "\n";
            joined += "Wheels: " + _wheels + "\n";
            joined += "Kind: " + _kind + "\n";
            joined += "Type: " + _type + "\n";
            if(_features.Count > 0)
            {
                foreach(Feature feature in _features)
                {
                    joined += "Feature: " + feature.Name + "\n";
                }
            }
            return joined;
        }

    }


    static void Main(string[] args)
    {

        Robot robot1 = new Robot("Red", Chips.QT8339, true, Kinds.FloorSweeper, Types.Medium, 4);
        Console.WriteLine(robot1.ToString());

        Robot robot2 = new Robot(100, Chips.QT8339, true, Kinds.WheelChanger, Types.Small);
        Console.WriteLine(robot2.ToString());

        Robot robot3 = new Robot("Red", Chips.QT8339, false, Kinds.FloorSweeper, Types.Small, 4); // Ignores the fact that this is a small robot, therefore the wheels should be 0
        Console.WriteLine(robot3.ToString());



    }
}