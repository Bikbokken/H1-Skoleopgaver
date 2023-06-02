using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public abstract class Item
    {
        public string Name { get; }
        public byte Amount { get; set; } // Skal kunne blive opdateret af vores Machine - derfor er der en set
        public double Price { get; }

        public Item(string name, byte amount, double price) {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }

    }

    public sealed class Drink : Item
    {
        public double Liters { get; }

        public Drink(string name, byte amount, double price, double Liters) : base(name, amount, price)
        {
            this.Liters = Liters;
        }
    }


    public sealed class Snack : Item
    {
        public string Flavour { get; }

        public Snack(string name, byte amount, double price, string flavour) : base(name, amount, price)
        {
            this.Flavour = flavour;
        }
    }

}
