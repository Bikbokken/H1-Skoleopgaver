using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class Machine : IMachine, IMachineAdmin
    {
        
        private List<Item> items { get; set; } = new List<Item>();

        public List<Item> GetAllItems()
        {
            return items;
        }

        public void RemoveOneAmount(int slot)
        {
            items[slot].Amount = (byte)(items[slot].Amount - Convert.ToByte(1));
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public Item ReadItem(byte slot) { 
            return items[slot]; 
        }

        public void UpdateItem(byte slot, Item item)
        {
            items[slot] = item;
        } 

        public void DeleteItem(byte slot)
        {
            items.RemoveAt(slot);
        }

        public void UpdateAmount(byte slot, byte amount) {
            items[slot].Amount = amount;
        }

        public Machine()
        {
            items.Add(new Drink("Coca Cola", 1, 19.20, 0.1));
            items.Add(new Drink("Fanta", 6, 10.20, 0.1));
            items.Add(new Drink("Faxe Kondi", 10, 2.20, 0.5));
            items.Add(new Drink("DR Pepper", 3, 7.20, 0.4));
            items.Add(new Drink("Fanta Lime", 0, 4.20, 0.3));
            items.Add(new Snack("Kims Chips SC", 2, 9.20, "Sour Cream"));
            items.Add(new Snack("Lays Salt", 2, 20.20, "Salt"));
            items.Add(new Snack("Kims Snack Chips", 2, 30.20, "Snack Chips"));

        }
    }
}
