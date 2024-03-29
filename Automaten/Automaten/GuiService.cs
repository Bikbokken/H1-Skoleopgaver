﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    internal class GuiService : IGuiService
    {
        private List<Item> _items { get; set; }

        public void SetItems(List<Item> items)
        {
            _items = items; 
        }

        public void ShowMachineStatus(double money)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("            AUTOMAT");
            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("Der er " + money + " kr. i maskinen!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ShowItems()
        {
            
            foreach (Item item in _items)
            {
                int index = _items.FindIndex(a => a == item); // Which index does the item exist in?
                if(item.Amount > 0) // Is the amount of the item more than one
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("Slot: " + index + "  Navn: " + item.Name + "  Pris: " + item.Price + "kr.  Styk: " + item.Amount);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        
        public void ShowOrder(int selectedItem)
        {
            Console.WriteLine();
            Console.WriteLine("Du har nu købt: ");
            ShowItem(_items[selectedItem]);
            Console.WriteLine();
            Console.WriteLine();
        }

        private bool DoesItemExist(int slot) {
            return _items.Count > slot && _items[slot] != null; // If the index og the item exist and the items count is not greather than the index - then return true
        }


        public void ShowItem(Item item)
        {
            Console.WriteLine();
            Console.WriteLine("Navn: " + item.Name + "  Pris: " + item.Price + "kr.");
            Console.WriteLine();
        }

        public bool ConfirmOrder(int selectedItem)
        {

            Console.Clear();

            bool hasCancelled = false;

            Stopwatch stopwatch = new Stopwatch(); // Create a Stopwatch
            stopwatch.Start(); // Start the stopwatch

            int countdownSeconds = 5;
            while (stopwatch.Elapsed.TotalSeconds < countdownSeconds) // While the total seconds elapsed is less than 5 seconds
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) // If the user presses Space
                {
                    
                    stopwatch.Stop(); // Stop the stopwatch
                    hasCancelled = true;
                    break;
                }

                int remainingSeconds = countdownSeconds - (int)stopwatch.Elapsed.TotalSeconds;
                Console.WriteLine("");
                Console.WriteLine("Du har valgt følgende produkt:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                ShowItem(_items[selectedItem]);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Ordren bliver fuldført om: " + remainingSeconds + " sekunder");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Klik på SPACE for at annullere!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("");

                Thread.Sleep(1000);
                Console.Clear();
            }
            if (!stopwatch.IsRunning) // If the stopwatch is not running anymore
            {
                stopwatch.Stop();
            }
            stopwatch.Stop(); // Stop the stopwatch

            if(hasCancelled)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har annulleret din ordre!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
            return hasCancelled;
        }

        private bool CheckAvailability(int slot)
        {
            return _items[slot].Amount > 0; // Check if the item on the "slot" index has more than 0 items
        }

        public int PromptOrder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Skriv slot tallet på produktet du ønsker at købe: ");
            Console.WriteLine();
            int myid;
            string input = Console.ReadLine(); // Read the input of the user
            bool isInt = int.TryParse(input, out myid);
            if (isInt) // Validate that the input is a int
            {
                bool doesItemExist = DoesItemExist(myid); // Does the item even exist?
                bool isItemAvaliable = CheckAvailability(myid); // Is the item even avaliable?
                if (doesItemExist && isItemAvaliable)
                {
                    Console.WriteLine("Du har valgt " + myid);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return myid;
                }

                if(!isItemAvaliable)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Der er ikke flere tilbage af dette produkt!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return -1;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du har valgt et produkt som ikke findes");
            Console.ForegroundColor = ConsoleColor.Gray;
            return -1;


        }
    }
}
