
public class Program
{

    public class Animal
    {
        protected bool Heart { get; set; } = true;
        public virtual bool FetchHeart() { return Heart; }

    }

    public class Dog : Animal
    {
        protected bool Fur { get; set; } = false;
        public int Eyes { get; set; }

        public override bool FetchHeart() { return Fur;  }
    }


    public sealed class Lab : Dog
    {
        public ConsoleColor Color { get; set; }
    }

    // JO mere vi nedarver, jo mere specialisere vi klassen. Jo mindre jo mere generalisere vi


        static void Main(string[] args)
        {
            Animal a = new Dog();
            Console.WriteLine(a.FetchHeart());
        }

    }



// Model: DAL
// Automat Klasse
//
//
// View: GUI
// Indtastning af nummer på produkt. 
// Visning af balance og automat muligheder
// Annullering af valg
//
// Controller: BLL
// Validering hvis produktet er ledigt. 
// Kontakt DAL - CalculateReturns og giv item.
// Giv pengene tilbage til GUI fra DAL
// Hentning af produkter fra DAL tl GUI
// (CheckStock, GetItem, RemoveItem, AddItem, AddMoney, ReturnMoney, CalculateReturns)


// Item: Abstract
// Name: Virtual Public
// Price: Virtual public
// Stock: Virtual public
//   Snack: Abstract 
        // Flavour: Virtual Public
        // Chips Sealed
        // Chocolate Sealed
//   Drink: Abstract
        // Liters: Virtual public
        // Bottle Sealed
        // Plastic Sealed
